using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperFunctions : MonoBehaviour
{
    public bool isSelfDestructable = false;
    public float destroyDelay = 1.5f;
    private void Start()
    {
        if (isSelfDestructable)
        {
            Destroy(gameObject, destroyDelay);
        }
    }
}
