using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnviroGenesis
{
 

    [CreateAssetMenu(fileName = "Action", menuName = "EnviroGenesis/Actions/CutPlant", order = 50)]
    public class ActionCutPlant : AAction
    {
        public override void DoAction(PlayerCharacter character, Selectable select)
        {
            Plant plant = select.GetComponent<Plant>();
            if (plant != null)
            {
                string animation = character.Animation ? character.Animation.take_anim : "";
                character.TriggerAnim(animation, plant.transform.position);
                character.TriggerBusy(0.5f, () =>
                {
                    plant.GrowPlant(0);

                    Destructible destruct = plant.GetDestructible();
                    TheAudio.Get().PlaySFX("destruct", destruct.death_sound);

                    destruct.SpawnLoots();
                });
            }
        }

        public override bool CanDoAction(PlayerCharacter character, Selectable select)
        {
            return select.GetComponent<Plant>();
        }
    }

}