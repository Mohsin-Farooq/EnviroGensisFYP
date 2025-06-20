using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{

  
    public abstract class SAction : ScriptableObject
    {
        public string title;

        public virtual void DoAction(PlayerCharacter character, Selectable select)
        {

        }

        
        public virtual void DoAction(PlayerCharacter character, ItemSlot slot)
        {

        }

        
        public virtual bool CanDoAction(PlayerCharacter character, Selectable select)
        {
            return true; 
        }

       
        public virtual bool CanDoAction(PlayerCharacter character, ItemSlot slot)
        {
            return true;
        }

        public bool IsAuto() { return (this is AAction); }
        public bool IsMerge() { return (this is MAction); }
    }

}