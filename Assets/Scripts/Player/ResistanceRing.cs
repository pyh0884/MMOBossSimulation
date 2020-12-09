using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistanceRing : MonoBehaviour
{
    public float duration = 1.5f;
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
