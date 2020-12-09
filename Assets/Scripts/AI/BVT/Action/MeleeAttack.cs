using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MMO_WorkSpace
{
    public class MeleeAttack : Action
    {
        // Melee target
        public SharedTransform meleeTarget;

        public override TaskStatus OnUpdate()
        {
            // #Todo: if the boss dead, return TaskStatus.Success

            if (!meleeTarget.Value)
            {
                return TaskStatus.Failure;
            }

            GameObject meleeSkill = meleeTarget.Value.GetComponentInChildren<Melee>().gameObject;

            if (!meleeSkill)
            {
                return TaskStatus.Failure;
            }

            meleeSkill.SetActive(true);

            return TaskStatus.Running;
        }
    }

}
