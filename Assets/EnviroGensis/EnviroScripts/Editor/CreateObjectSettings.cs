﻿using System.Collections;
using UnityEngine;

namespace EnviroGenesis.EditorTool
{
  
    
    [CreateAssetMenu(fileName = "CreateObjectSettings", menuName = "EnviroGenesis/CreateObjectSettings", order = 100)]
    public class CreateObjectSettings : ScriptableObject
    {

        [Header("Save Folders")]
        public string prefab_folder = "SurvivalEngine/Prefabs";
        public string prefab_equip_folder = "SurvivalEngine/Prefabs/Equip";
        public string items_folder = "SurvivalEngine/Resources/Items";
        public string constructions_folder = "SurvivalEngine/Resources/Constructions";
        public string plants_folder = "SurvivalEngine/Resources/Plants";
        public string characters_folder = "SurvivalEngine/Resources/Characters";

        [Header("Default Values")]
        public Material outline;
        public GameObject death_fx;
        public AudioClip craft_audio;
        public GameObject take_fx;
        public AudioClip take_audio;
        public AudioClip attack_audio;
        public AudioClip build_audio;
        public GameObject build_fx;
        public SAction[] item_actions;
        public SAction equip_action;
        public SAction eat_action;

    }

}