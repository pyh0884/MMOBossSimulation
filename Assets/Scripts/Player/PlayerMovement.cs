using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    public float MoveSpeed;
    public float JumpSpeed;
    private bool isJumping;
    public float fallMultiplier;
    public LayerMask GroundLayer;
    public Transform[] groundChecks;
    private Vector3 dir;
    private float angle;
    public float deadHeight = -5.0f;
    //private Animator anim;
    void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    bool isGrounded()
    {
        foreach (Transform trans in groundChecks)
        {
            if (Physics.Raycast(trans.position, Vector3.down, 0.25f, GroundLayer))
            {
                return true;
            }
            Debug.DrawLine(trans.position, trans.position + Vector3.down * 0.25f, Color.blue);
        }
        return false;
    }
    private void Update()
    {
        //Movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //Rotation
        rb.transform.eulerAngles = new Vector3(0, 90 - angle, 0);

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector3(0, JumpSpeed, 0);
            isJumping = true;
        }

        //Reset if fall
        if (transform.position.y < deadHeight)
        {
            transform.position = new Vector3(0, 0.5f, 0);
        }
    }

    // 所有关于物理的运算全部放在FixedUpdate中
    void FixedUpdate()
    {
        if (rb.velocity.y <= 0 && isGrounded())
        {
            rb.velocity = Vector3.zero;
            isJumping = false;
        }
        ///修改速度精确位移
        if (isJumping && rb.velocity.y < 0)///下降
        {
            rb.velocity = new Vector3(0, Mathf.Clamp(rb.velocity.y * fallMultiplier, -25, 0), 0);
        }
        ///修改坐标精确位移，可能会出现穿模
        rb.position = (rb.position + movement.normalized * MoveSpeed * Time.fixedDeltaTime);
        //rb.velocity = movement.normalized * MoveSpeed;

        //if (movement.x == 0 && movement.z == 0)
        //{
        //    anim.SetBool("running", false);
        //}
        //else
        //{
        //    anim.SetBool("running", true);
        //}
    }

    //public void createDummy(Vector3 pos)
    //{
    //    var dum = Instantiate(dummy, transform.position, Quaternion.identity);
    //    if (dum)
    //    {
    //        dum.GetComponent<DummyAI>().destination = pos;
    //        dum.transform.parent = null;
    //        var targetGroup = FindObjectOfType<CinemachineTargetGroup>();
    //        if (targetGroup)
    //        {
    //            targetGroup.AddMember(dum.transform, 1, 0);
    //        }
    //    }
    //}

    //private void OnDestroy()
    //{
    //    var targetGroup = FindObjectOfType<CinemachineTargetGroup>();
    //    if (targetGroup)
    //    {
    //        targetGroup.RemoveMember(gameObject.transform);
    //    }
    //}
}
