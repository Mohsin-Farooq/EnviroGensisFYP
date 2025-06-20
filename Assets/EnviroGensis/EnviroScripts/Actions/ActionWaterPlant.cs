using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{



    [CreateAssetMenu(fileName = "Action", menuName = "EnviroGenesis/Actions/WaterPlant", order = 50)]
    public class ActionWaterPlant : AAction
    {
        public GroupData required_item;

        public override void DoAction(PlayerCharacter character, Selectable select)
        {
            InventoryItemData item = character.EquipData.GetFirstItemInGroup(required_item);
            ItemData idata = ItemData.Get(item?.item_id);
            Plant plant = select.GetComponent<Plant>();
            if (idata != null && plant != null)
            {
                //Remove water
                if (idata.durability_type == DurabilityType.UsageCount)
                    item.durability -= 1f;
                else
                    character.Inventory.RemoveEquipItem(idata.equip_slot);

                //Water plant
                plant.Water();

                string animation = character.Animation ? character.Animation.water_anim : "";
                character.TriggerAnim(animation, plant.transform.position, 1f);
                character.TriggerProgressBusy(1f);
            }
        }

        public override bool CanDoAction(PlayerCharacter character, Selectable select)
        {
            Plant plant = select.GetComponent<Plant>();
            return plant != null && character.EquipData.HasItemInGroup(required_item);
        }
    }

}
