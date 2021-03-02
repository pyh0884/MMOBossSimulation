using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danmuku : MonoBehaviour
{
    private PlayerMovement pm;
    private Rigidbody rb;
    private bool isCasting = false;
    private float timer = 0.0f;
    private float throwTimer = 1.0f;
    public float throwGap = 0.3f;
    public float castTime = 3.0f;
    public GameObject bullet;
    public Transform EmitPoint;
    [Range(1, 3)]
    public int ControlMode = 1;
    private Quaternion targetDirection;
    private float targetDegree;
    public float rotationSpeed = 15.0f;
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        #region timer
        if (isCasting)
        {
            timer += Time.deltaTime;
            pm.enabled = false;
            Throw(throwGap);
        }
        else
        {
            pm.enabled = true;
        }
        if (timer >= castTime)
        {
            timer = 0.0f;
            isCasting = false;
        }
        if (Input.GetMouseButtonDown(0) && isCasting == false) 
        {
            isCasting = true;
            targetDirection = transform.rotation;
            targetDegree = rb.rotation.y;
        }
        #endregion
        if (!isCasting) return;
        switch (ControlMode) 
        {
            case 1://180度一秒的WASD转向
                rb.rotation = Quaternion.Lerp(transform.rotation, targetDirection, Time.deltaTime * rotationSpeed);
                Vector2 rotationAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
                targetDirection = Quaternion.Euler(0, 90 - Mathf.Atan2(rotationAxis.y, rotationAxis.x) * Mathf.Rad2Deg, 0);
                break;
            case 2://AD键控制缓慢旋转
                targetDegree += Input.GetAxisRaw("Horizontal") * Time.deltaTime * rotationSpeed * 25;
                Debug.Log(targetDegree);
                rb.rotation = Quaternion.Euler(0, targetDegree, 0);
                break;
            case 3://鼠标的缓慢转向
                rb.rotation = Quaternion.Lerp(transform.rotation, targetDirection, Time.deltaTime * rotationSpeed);
                Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                targetDirection = Quaternion.Euler(0, 90 - Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, 0);
                break;
        }
//         dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
//         angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
// 
//         //Rotation
//         rb.rotation = Quaternion.Euler(0, 90 - angle, 0);
    }
    public void Throw(float throwGap)
    {
        throwTimer += Time.deltaTime;
        if (throwTimer >= throwGap)
        {
            Vector3 forwardDirection = transform.forward;
            var bullet1 = Instantiate(bullet, EmitPoint.position, Quaternion.identity, null);
            bullet1.GetComponent<Rigidbody>().velocity = new Vector3(forwardDirection.x - 0.30f, 0, forwardDirection.z) * 15.0f;

            var bullet2 = Instantiate(bullet, EmitPoint.position, Quaternion.identity, null);
            bullet2.GetComponent<Rigidbody>().velocity = new Vector3(forwardDirection.x - 0.15f, 0, forwardDirection.z) * 15.0f;

            var bullet3 = Instantiate(bullet, EmitPoint.position, Quaternion.identity, null);
            bullet3.GetComponent<Rigidbody>().velocity = forwardDirection * 15.0f;

            var bullet4 = Instantiate(bullet, EmitPoint.position, Quaternion.identity, null);
            bullet4.GetComponent<Rigidbody>().velocity = new Vector3(forwardDirection.x + 0.15f, 0, forwardDirection.z) * 15.0f;
            throwTimer = 0.0f;
        }
    }
}
