using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace EnviroGenesis.EditorTool
{


    public class GenerateUIDs : ScriptableWizard
    {
        [MenuItem("EnviroGenesis/Generate UIDs", priority = 200)]
        static void ScriptableWizardMenu()
        {
            ScriptableWizard.DisplayWizard<GenerateUIDs>("Generate Unique IDs", "Generate All UIDs");
        }

        void OnWizardCreate()
        {
            UniqueID.GenerateAll(GameObject.FindObjectsOfType<UniqueID>());

            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        void OnWizardUpdate()
        {
            helpString = "Fill all empty UID in the scene with a random UID.";
        }
    }

}