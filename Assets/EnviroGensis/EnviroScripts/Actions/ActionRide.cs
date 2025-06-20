using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{


    [CreateAssetMenu(fileName = "Action", menuName = "EnviroGenesis/Actions/Ride", order = 50)]
    public class ActionRide : SAction
    {
        public override void DoAction(PlayerCharacter character, Selectable select)
        {
            AnimalRide ride = select.GetComponent<AnimalRide>();
            if (ride != null)
            {
                character.Riding.RideAnimal(ride);
            }
        }

        public override bool CanDoAction(PlayerCharacter character, Selectable select)
        {
            AnimalRide ride = select.GetComponent<AnimalRide>();
            return ride != null && !ride.IsDead() && character.Riding != null;
        }
    }

}