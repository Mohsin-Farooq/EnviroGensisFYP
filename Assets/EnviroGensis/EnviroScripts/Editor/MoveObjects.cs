﻿using UnityEngine;
using System.Collections;
using UnityEditor;

namespace EnviroGenesis.EditorTool
{
  

    public class MoveObjects : ScriptableWizard
    {
        public Vector3 move;
        public Vector3 rotate;

        [MenuItem("EnviroGenesis/Transform Group", priority = 300)]
        static void ScriptableWizardMenu()
        {
            ScriptableWizard.DisplayWizard<MoveObjects>("Transform Group", "Transform Group");
        }

        void MoveObject(Transform obj, Vector3 move_vect)
        {
            obj.position += move_vect;
            obj.rotation = obj.rotation * Quaternion.Euler(rotate);
        }

        void OnWizardCreate()
        {
            Undo.RegisterCompleteObjectUndo(Selection.transforms, "move objects");
            foreach (Transform transform in Selection.transforms)
            {
                MoveObject(transform, move);
            }
        }

        void OnWizardUpdate()
        {
            helpString = "Use this tool to move all selected objects by an exact value.";
        }
    }

}