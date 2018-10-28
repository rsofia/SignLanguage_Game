using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

using System;
using System.IO;
using System.Collections.Generic;

public static class FilesOnBuild
{
    [PostProcessBuild]
    static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        string path = Path.GetDirectoryName(pathToBuiltProject) + "/" + Path.GetFileNameWithoutExtension(pathToBuiltProject) + "_Data/Archivos";
        FileUtil.CopyFileOrDirectory(Application.dataPath + "/Archivos", path);
    }
}

//using UnityEditor;
//using UnityEditor.Build;
//using UnityEngine;
//using System.IO;

//class FilesOnBuild : IPostprocessBuild
//{
//    public int callbackOrder { get { return 0; } }
//    public void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
//    {
//        Debug.Log("MyCustomBuildProcessor.OnPostprocessBuild for target " + target + " at path " + pathToBuiltProject);
//        string path = Path.GetDirectoryName(pathToBuiltProject) + "/" + Path.GetFileNameWithoutExtension(pathToBuiltProject) + "_Data";
//        FileUtil.CopyFileOrDirectory("Assets/Archivos", path);
//    }
//}