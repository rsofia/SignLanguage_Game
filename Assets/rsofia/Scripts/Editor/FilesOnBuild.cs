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
        //Agrega todos los gestos guardados en el path al build
        string path = Path.GetDirectoryName(pathToBuiltProject) + "/" + Path.GetFileNameWithoutExtension(pathToBuiltProject) + "_Data/Archivos";
        FileUtil.CopyFileOrDirectory(Application.dataPath + "/Archivos", path);
    }
}
