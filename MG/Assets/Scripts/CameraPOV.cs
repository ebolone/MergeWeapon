using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPOV : MonoBehaviour
{

    public Transform target;
    public float zDistance;
    public float yDistance;
    public Camera mainCamera;


    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = new Vector3 (target.position.x , target.position.y + yDistance, target.position.z - zDistance);
    }
}
