using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{
  

    [CreateAssetMenu(fileName = "Action", menuName = "EnviroGenesis/Actions/Attack", order = 50)]
    public class ActionAttack : SAction
    {
        public override void DoAction(PlayerCharacter character, Selectable select)
        {
            if (select.Destructible)
            {
                character.Attack(select.Destructible);
            }
        }
    }

}