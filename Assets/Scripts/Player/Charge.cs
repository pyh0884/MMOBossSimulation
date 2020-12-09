using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public float duration = 1.5f;
    public float speed = 7.0f;
    private void OnEnable()
    {
        GetComponentInParent<PlayerMovement>().controllable = false;
        GetComponentInParent<PlayerMovement>().movement = GetComponentInParent<PlayerMovement>().gameObject.transform.forward;
        GetComponentInParent<PlayerMovement>().isCharging = true;
        StartCoroutine("deactivateSkill");
    }

    IEnumerator deactivateSkill()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
        GetComponentInParent<PlayerMovement>().controllable = true;
        GetComponentInParent<PlayerMovement>().movement = Vector3.zero;
        GetComponentInParent<PlayerMovement>().isCharging = false;
    }
}
