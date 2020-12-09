using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float duration = 0.5f;
    private void OnEnable()
    {
        StartCoroutine("deactivateSkill");
    }

    IEnumerator deactivateSkill()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
