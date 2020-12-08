using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;
    public float duration;

    private void OnEnable()
    {
        StartCoroutine("deactivateCollider");        
    }

    IEnumerator deactivateCollider()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10) //10 = 勇者
        {
            //TODO: deal damage
        }
    }
}
