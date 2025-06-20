using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{
    

    public class EquipAttach : MonoBehaviour
    {
        public EquipSlot slot;
        public EquipSide side;
        public float scale = 1f;

        private PlayerCharacter character;

        private void Awake()
        {
            character = GetComponentInParent<PlayerCharacter>();
        }

        public PlayerCharacter GetCharacter()
        {
            return character;
        }

    }

}