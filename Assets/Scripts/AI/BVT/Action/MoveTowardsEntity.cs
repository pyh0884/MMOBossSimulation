using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MMO_WorkSpace
{
    public class MoveTowardsEntity : Action
    {
        // Aiming entity
        public SharedTransform AimingTransform;

        // Moving Speed
        public float MovingSpeed = 0;

        private Rigidbody rb;

        private Vector3 aimingDirection;

        private float aimingAngle = 0;

        public override void OnStart()
        {
            rb = GetComponent<Rigidbody>();
        }

        public override TaskStatus OnUpdate()
        {
            aimingDirection = AimingTransform.Value.position - transform.position;
            aimingAngle = Mathf.Atan2(aimingDirection.y, aimingDirection.x) * Mathf.Rad2Deg;
            return TaskStatus.Running;
        }

        public override void OnFixedUpdate()
        {
            if (rb)
            {
                rb.position = (rb.position + aimingDirection.normalized * MovingSpeed * Time.fixedDeltaTime);
            }
        }
    }
}