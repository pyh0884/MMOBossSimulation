using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public GameObject AutoATK;
    public float AutoATKCD = 0.5f;
    private float AutoTimer = 0.0f;
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
        if ((direction.x * direction.x + direction.z * direction.z) < 4.0f)
        {
            AutoTimer += Time.deltaTime;
            if (AutoTimer >= AutoATKCD)
            {
                AutoTimer -= AutoATKCD;
                AutoATK.SetActive(true);
            }
        }
        else
        {
            rb.velocity = direction.normalized * movementSpeed;
        }
    }
}
