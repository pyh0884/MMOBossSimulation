using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class MoveTowardsEntity : Action
{
    // Aiming entity
    public Transform AimingEntity;
    
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
        if(!AimingEntity)
        {
            AimingEntity = GameObject.FindGameObjectWithTag("Player").transform;
        }
        aimingDirection = AimingEntity.position - transform.position;
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
