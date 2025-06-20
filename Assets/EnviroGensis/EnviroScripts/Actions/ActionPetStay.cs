using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{

   

    [CreateAssetMenu(fileName = "Action", menuName = "EnviroGenesis/Actions/PetStay", order = 50)]
    public class ActionPetStay : SAction
    {
        public override void DoAction(PlayerCharacter character, Selectable select)
        {
            Pet pet = select.GetComponent<Pet>();
            pet.StopFollow();
        }

        public override bool CanDoAction(PlayerCharacter character, Selectable select)
        {
            Pet pet = select.GetComponent<Pet>();
            return pet != null && pet.GetMaster() == character && pet.IsFollow();
        }
    }

}
