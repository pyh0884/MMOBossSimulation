using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public GameObject AutoATK;
    public float AutoATKCD = 0.5f;
    private float AutoTimer = 0.0f;
    public float BulletSpeed = 5.0f;
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
            AutoTimer += Time.deltaTime;
            if (AutoTimer >= AutoATKCD)
            {
                AutoTimer -= AutoATKCD;
                var bullet = Instantiate(AutoATK, rb.position, rb.rotation, null);
                bullet.GetComponent<Rigidbody>().velocity = new Vector3(direction.x, 0, direction.z) * BulletSpeed;
                bullet.GetComponent<Damage>().targetLayer = 9;
            }
            if ((direction.x * direction.x + direction.z * direction.z) < 40.0f)
            {
                rb.velocity = -direction.normalized * movementSpeed;
            }
        }
    }
}
