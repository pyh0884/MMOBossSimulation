using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 movement;
    public float MoveSpeed;
    public float initSpeed;
    private bool isJumping;
    public Transform ThrowCheck;
    public LayerMask GroundLayer;
    public LayerMask ObstacleLayer;
    public GameObject dummy;
    public GameObject food;
    private Camera camera;
    public float
        clampMarginMinX = 0.0f,
        clampMarginMaxX = 0.0f,
        clampMarginMinY = 0.0f,
        clampMarginMaxY = 0.0f;
    private float
        clampMinX,
        clampMaxX,
        clampMinY,
        clampMaxY;
    //冲刺相关
    public bool inShop = false;
    public bool isPushing;
    //音效相关
    private AudioSource asrc;
    public AudioSource steps;
    public AudioClip throwFood;
    //输入相关
    public int playerID = 10;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        initSpeed = MoveSpeed;
        camera = FindObjectOfType<Camera>();
        asrc = GetComponent<AudioSource>();
  
    }
    //获取屏幕边界坐标
    public void getScreenData()
    {
        Ray MinX = camera.ScreenPointToRay(new Vector2(0 + clampMarginMinX, 0 + clampMarginMinY));
        Ray MaxX = camera.ScreenPointToRay(new Vector2(Screen.width - clampMarginMaxX, Screen.height - clampMarginMaxY));
        RaycastHit hit;
        if (Physics.Raycast(MinX, out hit,Mathf.Infinity,GroundLayer))
        {
            clampMinX = hit.point.x;
            clampMinY = hit.point.z;
        }
        if (Physics.Raycast(MaxX, out hit, Mathf.Infinity, GroundLayer))
        {
            clampMaxX = hit.point.x;
            clampMaxY = hit.point.z;
        }
    }

    //扔食物
    public void Throw() 
    {
        Instantiate(food, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, null);
        asrc.PlayOneShot(throwFood);
    }
    // 所有关于物理的运算全部放在FixedUpdate中
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        if (rb.velocity.y == 0)
            isJumping = false;
        ///修改速度精确位移
        if (isJumping && rb.velocity.y < 0)///下降
        {
            rb.velocity = new Vector3(0, Mathf.Clamp(rb.velocity.y * 1.2f, -25, 0), 0);
        }
        else if (isJumping && rb.velocity.y < 5 && rb.velocity.y > 0)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

        if (rb.position.x < clampMinX && camera.fieldOfView == 30)
        {
            Debug.Log(clampMinX);
            movement.x = Mathf.Clamp(movement.x, 0, 1);
        }
        else if (rb.position.x > clampMaxX && camera.fieldOfView == 30)
        {
            Debug.Log(clampMaxX);
            movement.x = Mathf.Clamp(movement.x, -1, 0);
        }
        if (rb.position.z < clampMinY && camera.fieldOfView == 30)
        {
            Debug.Log(clampMinY);
            movement.z = Mathf.Clamp(movement.z, 0, 1);
        }
        else if (rb.position.z > clampMaxY && camera.fieldOfView == 30)
        {
            Debug.Log(clampMaxY);
            movement.z = Mathf.Clamp(movement.z, -1, 0);
        }
        ///修改坐标精确位移，可能会出现穿模
        rb.position = (rb.position + movement.normalized * MoveSpeed * Time.fixedDeltaTime);
        transform.LookAt(transform.position + movement);

        // Mute steps when not moving;
        if (movement.x == 0 && movement.z == 0)
        {
            steps.mute = true;
            anim.SetBool("running", false);
        } else
        {
            steps.mute = false;
            anim.SetBool("running", true);
        }
        //rb.position = new Vector3(Mathf.Clamp(rb.position.x, clampMinX, clampMaxX), rb.position.y, Mathf.Clamp(rb.position.z, clampMinY, clampMaxY));
        
        //rb.AddForce(movement * MoveSpeed * Time.fixedDeltaTime); ---带有惯性的移动
    }
    private void LateUpdate()
    {
        getScreenData();
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
    private void OnDestroy()
    {
        //var targetGroup = FindObjectOfType<CinemachineTargetGroup>();
        //if (targetGroup)
        //{
        //    targetGroup.RemoveMember(gameObject.transform);
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
            isPushing = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 9)
            isPushing = false;
    }
}
