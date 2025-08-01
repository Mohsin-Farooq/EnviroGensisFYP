﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{

    
    [CreateAssetMenu(fileName = "Action", menuName = "EnviroGenesis/Actions/Build", order = 50)]
    public class ActionBuild : SAction
    {
        public override void DoAction(PlayerCharacter character, ItemSlot slot)
        {
            ItemData item = slot.GetItem();
            InventoryData inventory = slot.GetInventory();
            if (item != null)
            {
                character.Crafting.BuildItemBuildMode(inventory, slot.index);
            }
        }

        public override bool CanDoAction(PlayerCharacter character, ItemSlot slot)
        {
            ItemData item = slot.GetItem();
            return item != null;
        }
    }

}
