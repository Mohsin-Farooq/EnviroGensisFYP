﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{

    
    [CreateAssetMenu(fileName = "Action", menuName = "EnviroGenesis/Actions/ActivateTrap", order = 50)]
    public class ActionSetTrap : SAction
    {
        public override void DoAction(PlayerCharacter character, Selectable select)
        {
            Trap trap = select.GetComponent<Trap>();
            if (trap != null)
                trap.Activate();
        }

        public override bool CanDoAction(PlayerCharacter character, Selectable select)
        {
            Trap trap = select.GetComponent<Trap>();
            if (trap != null)
                return !trap.IsActive();
            return false;
        }
    }

}