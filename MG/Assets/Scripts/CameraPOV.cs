using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPOV : MonoBehaviour
{

    public Transform target;
    private float zDistance = 3f;
    private float yDistance = 7f;
    public Camera mainCamera;


    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = new Vector3 (target.position.x , target.position.y + yDistance, target.position.z - zDistance);
    }
}
