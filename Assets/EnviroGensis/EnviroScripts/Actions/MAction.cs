using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{

    

    public abstract class MAction : SAction
    {
        public GroupData merge_target;

    
        public virtual void DoAction(PlayerCharacter character, ItemSlot slot, ItemSlot slot_other)
        {

        }

       
        public virtual void DoAction(PlayerCharacter character, ItemSlot slot, Selectable select)
        {

        }

        
        public virtual bool CanDoAction(PlayerCharacter character, ItemSlot slot, ItemSlot slot_target) 
        {
            ItemData item = slot_target.GetItem();
            if (item == null) return false;
            return merge_target == null || item.HasGroup(merge_target);
        }


        public virtual bool CanDoAction(PlayerCharacter character, ItemSlot slot, Selectable select)
        {
            if (select == null) return false;
            return merge_target == null || select.HasGroup(merge_target);
        }


        
        public override void DoAction(PlayerCharacter character, ItemSlot slot)
        {
            Selectable select = Selectable.GetNearestGroup(merge_target, character.transform.position);
            if (select != null)
            {
                DoAction(character, slot, select);
            }
        }

        public override bool CanDoAction(PlayerCharacter character, ItemSlot slot)
        {
            Selectable select = Selectable.GetNearestGroup(merge_target, character.transform.position);
            if (select != null && select.IsInUseRange(character))
            {
                return CanDoAction(character, slot, select);
            }
            return false;
        }

    }

}