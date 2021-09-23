// #if UNITY_EDITOR
// using System;
// using System.IO;
// using System.Xml.Linq;
// using UnityEditor.Build;
// using UnityEditor.Build.Reporting;
// using UnityEditor.UnityLinker;
// using UnityEngine;
//
// namespace Test.Editor
// {
//     public class TestGenerateLinkXML : IUnityLinkerProcessor
//     {
//         private string xmlPath;
//
//         public int callbackOrder { get; }
//
//         public string GenerateAdditionalLinkXmlFile(BuildReport report, UnityLinkerBuildPipelineData data)
//         {
//             Debug.Log("GenerateAdditionalLinkXmlFile");
//             // Path?
//             xmlPath = data.inputDirectory;
//             PatchLinkXml(xmlPath);
//             return "";
//         }
//
//         public void OnBeforeRun(BuildReport report, UnityLinkerBuildPipelineData data)
//         {
//             Debug.Log("OnBeforeRun");
//         }
//
//         public void OnAfterRun(BuildReport report, UnityLinkerBuildPipelineData data)
//         {
//             Debug.Log("OnAfterRun");
//         }
//
//         protected void PatchLinkXml(string path)
//         {
//             PatchLink(path, (rootElement) =>
//             {
//                 foreach (var xElement in rootElement.Elements())
//                 {
//                     if (xElement.FirstAttribute.Value == "unityexample.createparenttool")
//                     {
//                         xElement.RemoveAll();
//                         var assemblyAttribute = new XAttribute("fullname", "unityexample.createparenttool");
//                         xElement.Add(assemblyAttribute);
//                         
//                         var preserveAssemblies = new string[]
//                         {
//                             "*"
//                         };
//                         
//                         foreach (var preserveAssembly in preserveAssemblies)
//                         {
//                             var type = new XElement("type");
//                             var typeAttribute = new XAttribute("fullname", preserveAssembly);
//                             var preserveAttribute = new XAttribute("preserve", "all");
//                             
//                             type.Add(typeAttribute);
//                             type.Add(preserveAttribute);
//                             
//                             xElement.Add(type);
//                         }
//                     }
//                 }
//             });
//         }
//
//         protected void PatchLink(string path, Action<XElement> action)
//         {
//             var linkPath = path + "/TypesInScenes.xml";
//             // var linkXml = new XDocument();
//             var linkXml = XDocument.Load(linkPath);
//             Debug.Log(linkPath);
//
//             action(linkXml.Element("linker"));
//
//             linkXml.Save(linkPath);
//         }
//     }
// }
// #endif
