﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

namespace EnviroGenesis.EditorTool
{
   

    public class DeleteSave : ScriptableWizard
    {
        [MenuItem("EnviroGenesis/Delete Save File", priority = 350)]
        static void ScriptableWizardMenu()
        {
            ScriptableWizard.DisplayWizard<DeleteSave>("Delete Save File", "Delete");
        }

        void OnWizardCreate()
        {
            PlayerData.Delete(PlayerData.GetLastSave());
        }

        void OnWizardUpdate()
        {
            helpString = "Use this tool to delete the latest save file.";
        }
    }
}