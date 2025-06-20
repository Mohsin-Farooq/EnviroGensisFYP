using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{
  
    
    public abstract class AAction : SAction
    {
       
        public override void DoAction(PlayerCharacter character, Selectable select)
        {

        }

       
        public override void DoAction(PlayerCharacter character, ItemSlot slot)
        {

        }

        
        public virtual void DoSelectAction(PlayerCharacter character, ItemSlot slot)
        {

        }

        
        public override bool CanDoAction(PlayerCharacter character, Selectable select)
        {
            return true; 
        }

        
        public override bool CanDoAction(PlayerCharacter character, ItemSlot slot)
        {
            return true;
        }
    }

}