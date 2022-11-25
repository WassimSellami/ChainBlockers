using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTheCamera : MonoBehaviour
{
    private Transform cam;
    Vector3 targetAngle = Vector3.zero;

    private void Start()
    {
        cam = Camera.main.transform;
    }
    void Update()
    {
        transform.LookAt(cam);
        targetAngle = transform.localEulerAngles;
        targetAngle.x = 0;
        targetAngle.y = 0;
        targetAngle.z += 90;
        transform.localEulerAngles = targetAngle;
    }
}
