using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

public class ProjectStructureSafeExporter : EditorWindow
{
    private string outputFilePath = "ProjectStructure.txt";

    [MenuItem("Tools/Export Safe Project Structure")]
    public static void ShowWindow()
    {
        GetWindow<ProjectStructureSafeExporter>("Safe Project Exporter");
    }

    private void OnGUI()
    {
        GUILayout.Label("Safe Project Structure Exporter", EditorStyles.boldLabel);
        outputFilePath = EditorGUILayout.TextField("Output File Path", outputFilePath);

        if (GUILayout.Button("Export"))
        {
            ExportProjectStructure();
        }
    }

    private void ExportProjectStructure()
    {
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            writer.WriteLine("# ==========================================");
            writer.WriteLine("# 유니티 프로젝트 구조 + 현재 씬 Hierarchy (안전 버전)");
            writer.WriteLine("# ==========================================\n");

            // ---------- Scripts 폴더 ----------
            writer.WriteLine("[Scripts]");
            string scriptsRoot = Application.dataPath + "/Scripts";
            if (Directory.Exists(scriptsRoot))
            {
                foreach (string folder in Directory.GetDirectories(scriptsRoot))
                {
                    string folderName = "Scripts" + folder.Replace(scriptsRoot, "").Replace("\\", "/");
                    writer.WriteLine($"\n# {folderName}");
                    string[] scripts = Directory.GetFiles(folder, "*.cs", SearchOption.TopDirectoryOnly);
                    foreach (string script in scripts)
                    {
                        writer.WriteLine($"    {Path.GetFileName(script)}");
                    }
                }
            }
            else
            {
                writer.WriteLine("Scripts 폴더가 존재하지 않음.");
            }

            // ---------- Prefabs 폴더 ----------
            writer.WriteLine("\n[Prefabs]");
            string prefabsRoot = Application.dataPath + "/Prefabs";
            if (Directory.Exists(prefabsRoot))
            {
                string[] prefabs = Directory.GetFiles(prefabsRoot, "*.prefab", SearchOption.TopDirectoryOnly);
                foreach (string prefab in prefabs)
                {
                    writer.WriteLine($"{Path.GetFileName(prefab)}");
                }
            }
            else
            {
                writer.WriteLine("Prefabs 폴더가 존재하지 않음.");
            }

            // ---------- 현재 씬 Hierarchy ----------
            writer.WriteLine("\n# ---------- 현재 씬 Hierarchy ----------");
            var scene = EditorSceneManager.GetActiveScene();
            writer.WriteLine($"Scene: {scene.name}");

            foreach (GameObject rootObj in scene.GetRootGameObjects())
            {
                WriteHierarchy(writer, rootObj, 0);
            }

            writer.WriteLine("\n# ==========================================");
            writer.WriteLine("# 완료!");
        }

        Debug.Log($"Safe Project Structure exported to {outputFilePath}");
    }

    private void WriteHierarchy(StreamWriter writer, GameObject obj, int indent)
    {
        string indentation = new string(' ', indent * 4);
        string line = $"{indentation}- {obj.name}";
        writer.WriteLine(line);

        foreach (Transform child in obj.transform)
        {
            WriteHierarchy(writer, child.gameObject, indent + 1);
        }
    }
}
