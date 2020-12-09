using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MMO_WorkSpace
{
    public class SingleHealing : Action
    {
        // Healing target
        private Transform healingTarget;

        public float timeLimit;

        public float healingAmount;

        private float timer = 0;

        public override float GetPriority()
        {
            return healingAmount;
        }

        public override TaskStatus OnUpdate()
        {
            // #Todo: if the player dead, return TaskStatus.Success

            if (timer > timeLimit)
            {
                timer = 0;

                float minHealth = float.MaxValue;
                foreach (var target in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    if (target.GetComponent<Health>().currentHealth < minHealth)
                    {
                        healingTarget = target.transform;
                    }
                }

                if (!healingTarget)
                {
                    return TaskStatus.Failure;
                }

                healingTarget.GetComponent<Health>().TakeDamege(-healingAmount);

                Debug.Log("Single Healing: " + healingTarget.name);
            }

            return TaskStatus.Running;
        }

        public override void OnFixedUpdate()
        {
            timer += Time.deltaTime;
        }
    }
}