using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MMO_WorkSpace
{
    public class SingleHealing : Action
    {
        // Healing skill
        // public Skills healingSkill;

        // Healing target
        public SharedTransform healingTarget;

        public override TaskStatus OnUpdate()
        {
            // #Todo: if the player dead, return TaskStatus.Success

            if(!healingTarget.Value)
            {
                return TaskStatus.Failure;
            }

            EntityStats stats = healingTarget.Value.GetComponent<EntityStats>();

            if(!stats)
            {
                return TaskStatus.Failure;
            }

            stats.AddHealthPoint(10);
            stats.AddMagicPoint(-5);

            return TaskStatus.Running;
        }
    }
}