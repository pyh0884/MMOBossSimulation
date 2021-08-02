using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerEnemy : Enemy
{
    protected override void StartFunc()
    {
    }

    void Update()
    {
        //PathFinding
        playerPos = player.transform.position;
        direction = playerPos - rb.transform.position;
        direction.y = 0.0f;
        rb.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
        if ((direction.x * direction.x + direction.z * direction.z) > 70.0f)
        {
            rb.velocity = direction.normalized * movementSpeed;
        }
        else
        {
            if ((direction.x * direction.x + direction.z * direction.z) < 40.0f)
            {
                rb.velocity = -direction.normalized * movementSpeed;
            }
        }
    }
}
