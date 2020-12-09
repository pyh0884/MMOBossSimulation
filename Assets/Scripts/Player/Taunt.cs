using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taunt : MonoBehaviour
{
    public float duration = 5.0f;
    private void OnEnable()
    {
        StartCoroutine("deactivateSkill");
        FindObjectOfType<PlayerMovement>().Taunted(transform, 5.0f);
    }

    IEnumerator deactivateSkill()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
