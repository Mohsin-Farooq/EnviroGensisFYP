using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{

    

    [CreateAssetMenu(fileName = "Action", menuName = "EnviroGenesis/Actions/ReadImage", order = 50)]
    public class ActionReadImage : SAction
    {
        public Sprite image;

        public override void DoAction(PlayerCharacter character, ItemSlot slot)
        {
            ItemData item = slot.GetItem();
            if (item != null)
            {
                ReadPanel.Get(1).ShowPanel(item.title, image);
            }
        }

        public override bool CanDoAction(PlayerCharacter character, ItemSlot slot)
        {
            return true;
        }
    }

}