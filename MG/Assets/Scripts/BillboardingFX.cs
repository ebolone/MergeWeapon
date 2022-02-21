using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardingFX : MonoBehaviour
{

    Transform camera;

    private void Awake()
    {
        camera = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.forward = camera.forward;
    }
}
