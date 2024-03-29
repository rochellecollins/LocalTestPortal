﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LocalTestPortal
{
    /// <summary>
    /// Reading of test dll to pull out all available tests
    /// </summary>
    internal class TestReader
    {
        private List<string> _DllFileNames;
        private List<string> _TestsSimple;
        private List<Test> _Tests;
        private Type[] _CoreTestTypes;
        private Type _CheckType;
        private Type _TestDescriptionType;
        private Type _TestIgnoreType;
        private PropertyInfo _TestDescriptionPropertyInfo;

        public readonly string TestPath;
        public readonly string TempPath;
        public List<string> TestsSimple => _TestsSimple;
        public List<Test> Tests => _Tests;
        public List<string> DllFileNames => _DllFileNames;

        public TestReader(string testsPath, string tempDllPath)
        {
            if(string.IsNullOrWhiteSpace(testsPath))
            {
                throw new ArgumentNullException(nameof(testsPath));
            }

            if (!Directory.Exists(testsPath))
            {
                throw new DirectoryNotFoundException($"Tests path is invalid: {testsPath}");
            }

            TestPath = testsPath;
            TempPath = tempDllPath;
            _DllFileNames = new List<string>();
            _TestsSimple = new List<string>();
            _Tests = new List<Test>();

            var coreDll = Path.Combine(TestPath, "PX.QA.Tools.dll");
            if (!File.Exists(coreDll))
            {
                throw new FileNotFoundException("Unable to load Core.dll");
            }

            _CoreTestTypes = GetTestFileTypes(coreDll);
            _CheckType = _CoreTestTypes.Where(t => t.FullName == "Core.TestExecution.Check").FirstOrDefault();
            _TestDescriptionType = _CoreTestTypes.Where(t => t.FullName == "Core.Attributes.TestDescription").FirstOrDefault();
            _TestIgnoreType = _CoreTestTypes.Where(t => t.FullName == "Core.Attributes.TestIgnoreAttribute").FirstOrDefault();
            if(_TestDescriptionType != null)
            {
                _TestDescriptionPropertyInfo =  _TestDescriptionType.GetProperty("Description", typeof(string));
            }
        }

        private string FormatDllFileName(string fileName)
        {
            if(string.IsNullOrWhiteSpace(fileName))
            {
                return null;
            }

            if(fileName.Contains("dll"))
            {
                return fileName.Trim();
            }

            return $"{fileName.Trim()}.dll";
        }

        private bool IsTestClass(Type item)
        {
            return item.IsSubclassOf(_CheckType);
        }

        private bool IsTestIgnore(Type item)
        {
            return item.CustomAttributes.Where(x => x.AttributeType.FullName == _TestIgnoreType.FullName).Any();
        }

        private Type[] GetTestFileTypes(string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException(file);
            }

            return GetTestFileTypes(Assembly.LoadFrom(file));
        }

        private Type[] GetTestFileTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                if (e.LoaderExceptions != null)
                {
                    var files = new List<string>();
                    var sb = new System.Text.StringBuilder();
                    sb.AppendLine($"Unable to load one or more of the requested types in file '{assembly.FullName}'");
                    var msgHashSet = new HashSet<string>();
                    foreach (var ex in e.LoaderExceptions)
                    {
                        if (msgHashSet.Add(ex.Message))
                        {
                            var fileNoteFoundEx = ex as FileNotFoundException;
                            if (fileNoteFoundEx?.FileName != null)
                            {
                                var fileName = fileNoteFoundEx.FileName.Contains(',') 
                                    ? fileNoteFoundEx.FileName.Split(',').FirstOrDefault()
                                    : fileNoteFoundEx.FileName;
                                files.Add(fileName);
                            }

                            sb.AppendLine(ex.Message);
                        }
                    }

                    if (msgHashSet.Count > 0)
                    {
                        throw new Exception(sb.ToString(), e);
                    }
                }
                throw;
            }
        }

        private string GetTestDescription(Type item)
        {
            var att = item.GetCustomAttributes().FirstOrDefault(x => x.GetType() == _TestDescriptionType);
            if(att == null || _TestDescriptionPropertyInfo == null)
            {
                return string.Empty;
            }

            return (string)_TestDescriptionPropertyInfo.GetValue(att) ?? string.Empty;
        }

        private string GetTestModule(Type item)
        {
            foreach(var att in item.GetCustomAttributes())
            {
                var attType = att.GetType();
                if(attType.Namespace.StartsWith("Acumatica"))
                {
                    return attType.Name.Replace("Attribute","");
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Convert a test <see cref="Type"/> to custom <see cref="Test"/> object
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Test TypeToTest(Type item)
        {
            return new Test
            {
                Name = item.Name,
                FullName = item.FullName,
                Description = GetTestDescription(item),
                Module = GetTestModule(item)
            };
        }

        public void LoadTestDll(string dllFileName)
        {
            if(string.IsNullOrWhiteSpace(dllFileName))
            {
                throw new ArgumentNullException(nameof(dllFileName));
            }

            var formatedDllFileName = FormatDllFileName(dllFileName);
            var testDllFile = Path.Combine(TestPath, formatedDllFileName);
            if (!File.Exists(testDllFile))
            {
                throw new FileNotFoundException($"Test dll file is invalid: {testDllFile}");
            }

            //copy the dll to a temp folder so the original doesn't stay locked
            formatedDllFileName = CopyDllFile(TestPath, TempPath, dllFileName);
            testDllFile = Path.Combine(TempPath, formatedDllFileName);
            if (!File.Exists(testDllFile))
            {
                throw new FileNotFoundException($"Copy of Dll is missing: {testDllFile}");
            }

            _DllFileNames.Add(formatedDllFileName);

            foreach (var item in GetTestFileTypes(testDllFile))
            {
                if(item.IsAbstract || !IsTestClass(item) || IsTestIgnore(item))
                {
                    continue;
                }

                _TestsSimple.Add(item.Name);
                _Tests.Add(TypeToTest(item));
            }
        }

        public string CopyDllFile(string testPath, string tempPath, string dllFileName)
        {
            //Create temp folder and copy over required files
            CopyDependancies(testPath, tempPath);

            bool copied = false;
            int dllID = 0;
            string newCopiedDLL = "";
            while(copied == false)
            {
                newCopiedDLL = FormatDllFileName(dllFileName + dllID);
                var copiedDllPath = Path.Combine(tempPath, newCopiedDLL);
                if(File.Exists(copiedDllPath))
                {
                    dllID += 1;
                    continue;
                }
                File.Copy(Path.Combine(testPath, FormatDllFileName(dllFileName)), copiedDllPath);
                copied = true;
            }
            return newCopiedDLL;
        }

        private void CopyDependancies(string testPath, string tempPath)
        {
            System.IO.Directory.CreateDirectory(tempPath);
            var requiredDlls = new List<string>()
            {
                "PX.QA.Internals.dll",
                "GeneratedWrappers.ArenaProductLifeCycle.dll",
                "GeneratedWrappers.Acumatica.dll",
                "Core.dll",
                "TestsBase.dll"
            };
            foreach (var requiredDll in requiredDlls)
            {
                var dllDestination = Path.Combine(tempPath, requiredDll);
                if (!File.Exists(dllDestination))
                {
                    var dllSource = Path.Combine(testPath, requiredDll);
                    if (!File.Exists(dllSource))
                    {
                        Debug.WriteLine($"File Not Found: {dllSource}");
                        continue;
                    }
                    File.Copy(dllSource, dllDestination);
                }
            }
        }

        public class Test
        {
            public string Name;
            public string FullName;
            public string Description;
            public string Module;
        }
    }
}
