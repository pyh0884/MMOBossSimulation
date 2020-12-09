using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class EnemyRunAway : Conditional
{
    public SharedTransform AimingAimingTransform;

    public float minDist = 0;

    public override TaskStatus OnUpdate()
    {
        Health stats = GetComponent<Health>();
        if(stats)
        {
            float currentHealth = stats.currentHealth;
            float maxHealth = stats.maxHealth;
            if(currentHealth <= maxHealth * 0.2f)
            {
                return TaskStatus.Success;
            }
        }

        if (!AimingAimingTransform.Value)
        {
            return TaskStatus.Failure;
        }

        float dist = Vector3.Distance(transform.position, AimingAimingTransform.Value.position);

        if (dist < minDist)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
