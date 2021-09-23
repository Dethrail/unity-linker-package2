#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.UnityLinker;
using UnityEngine;

namespace Test.Editor
{
    public class TestGenerateLinkXML : IUnityLinkerProcessor
    {
        public string GenerateAdditionalLinkXmlFile(BuildReport report, UnityLinkerBuildPipelineData data)
        {
            CopyLinks();
            Debug.Log("GenerateAdditionalLinkXmlFile");
            // Path?
            var xmlPath = data.inputDirectory;
            return xmlPath;
        }

        public void OnBeforeRun(BuildReport report, UnityLinkerBuildPipelineData data)
        {
          
            Debug.Log("OnBeforeRun");
        }

        public void OnAfterRun(BuildReport report, UnityLinkerBuildPipelineData data)
        {
            Debug.Log("OnAfterRun");
        }

        private static void CopyLinks()
        {
            var req = UnityEditor.PackageManager.Client.List(true);
            while (!req.IsCompleted)
            {
                continue;
            }

            var linkPaths = new List<(string, string)>();
            var collection = req.Result;
            foreach (var p in collection)
            {
                CollectLinks(linkPaths, p.resolvedPath, p.resolvedPath);
                CollectLinks(linkPaths, p.resolvedPath, p.resolvedPath);
            }

            if (linkPaths.Count > 0)
            {
                foreach (var (absPath, relPath) in linkPaths)
                {
                    var destPath = $"{Application.dataPath}/PackageLinks/{relPath}";

                    Debug.Log($"Copying {absPath} to {destPath}...");

                    Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                    File.Copy(absPath, destPath);
                }
            }
            else
            {
                Debug.Log("No package links found.");
            }
        }

        private static void CollectLinks(List<(string, string)> linkPaths, string rootPath, string path)
        {
            // check files
            var files = Directory.GetFiles(path, "link.xml");
            foreach (var file in files)
            {
                linkPaths.Add((file, file.Replace(rootPath, "")));
            }

            // check directories
            var directories = Directory.GetDirectories(path);
            foreach (var dir in directories)
            {
                CollectLinks(linkPaths, rootPath, dir);
            }
        }

        public int callbackOrder { get; }
    }
}
#endif
