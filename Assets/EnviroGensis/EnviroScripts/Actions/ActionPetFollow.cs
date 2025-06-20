using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{

   

    [CreateAssetMenu(fileName = "Action", menuName = "EnviroGenesis/Actions/PetFollow", order = 50)]
    public class ActionPetFollow : SAction
    {
        public override void DoAction(PlayerCharacter character, Selectable select)
        {
            Pet pet = select.GetComponent<Pet>();
            pet.Follow();
        }

        public override bool CanDoAction(PlayerCharacter character, Selectable select)
        {
            Pet pet = select.GetComponent<Pet>();
            return pet != null && pet.GetMaster() == character && !pet.IsFollow();
        }
    }

}
