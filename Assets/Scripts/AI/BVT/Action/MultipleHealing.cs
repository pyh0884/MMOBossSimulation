using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MMO_WorkSpace
{
    public class MultipleHealing : Action
    {
        // Healing targets
        private GameObject[] healingTargets;

        public float timeLimit;

        public float healingAmount;

        private float timer = 0;

        public override float GetPriority()
        {
            return healingAmount * healingTargets.Length;
        }

        public override void OnAwake()
        {
            healingTargets = GameObject.FindGameObjectsWithTag("Enemy");
        }

        public override TaskStatus OnUpdate()
        {
            // #Todo: if the player dead, return TaskStatus.Success

            if (timer > timeLimit)
            {
                timer = 0;
                foreach (var healingTarget in healingTargets)
                {
                    healingTarget.GetComponent<Health>()?.TakeDamege(-healingAmount);
                }

                Debug.Log("Multiple Healing");
            }

            return TaskStatus.Running;
        }

        public override void OnFixedUpdate()
        {
            timer += Time.deltaTime;
        }
    }
}