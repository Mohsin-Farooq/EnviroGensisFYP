using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EnviroGenesis
{
  

    [CreateAssetMenu(fileName = "Action", menuName = "EnviroGenesis/Actions/Storage", order = 50)]
    public class ActionStorage : AAction
    {
        public override void DoAction(PlayerCharacter character, Selectable select)
        {
            Storage storage = select.GetComponent<Storage>();
            if (storage != null)
            {
                storage.OpenStorage(character);
            }
        }

        public override bool CanDoAction(PlayerCharacter character, Selectable select)
        {
            return select.GetComponent<Storage>() != null;
        }
    }

}
