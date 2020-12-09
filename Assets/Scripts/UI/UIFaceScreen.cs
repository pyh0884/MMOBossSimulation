using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFaceScreen : MonoBehaviour
{
    private void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
