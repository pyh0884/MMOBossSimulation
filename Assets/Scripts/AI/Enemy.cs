using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected PlayerMovement player;
    protected Rigidbody rb;
    protected Vector3 playerPos;
    protected Vector3 direction;
    public float movementSpeed = 5.0f;
    // Start is called before the first frame update
    public virtual void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        playerPos = player.transform.position;
        rb = GetComponent<Rigidbody>();
        StartFunc();
    }

    protected abstract void StartFunc();
    // Update is called once per frame
    void Update()
    {
        
    }
}
