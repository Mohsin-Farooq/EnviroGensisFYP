using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UnityEditor.SceneManagement;

namespace EnviroGenesis.EditorTool
{

   

    public class ClearUIDs : ScriptableWizard
    {

        [MenuItem("EnviroGenesis/Clear UIDs", priority = 201)]
        static void ScriptableWizardMenu()
        {
            ScriptableWizard.DisplayWizard<ClearUIDs>("Clear Unique IDs", "Clear All UIDs");
        }

        void OnWizardCreate()
        {
            UniqueID.ClearAll(GameObject.FindObjectsOfType<UniqueID>());

            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        void OnWizardUpdate()
        {
            helpString = "Clear all UIDs in the scene. Warning: this will make previous save files incompatible.";
        }
    }

}