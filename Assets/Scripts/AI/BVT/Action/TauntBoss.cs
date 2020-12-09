using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MMO_WorkSpace
{
    public class TauntBoss : Action
    {
        // Taunt target
        public SharedTransform tauntTarget;

        public override TaskStatus OnUpdate()
        {
            // #Todo: if the boss dead, return TaskStatus.Success

            if (!tauntTarget.Value)
            {
                return TaskStatus.Failure;
            }

            GameObject tauntSkill = tauntTarget.Value.GetComponentInChildren<Taunt>().gameObject;

            if (!tauntSkill)
            {
                return TaskStatus.Failure;
            }

            tauntSkill.SetActive(true);

            return TaskStatus.Running;
        }
    }

}
