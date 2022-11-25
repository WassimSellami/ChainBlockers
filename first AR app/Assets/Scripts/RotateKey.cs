using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateKey : MonoBehaviour
{
    private float rotateSpeed = 100f;

    void Update()
    {
        transform.Rotate(0.0f, 0.0f, rotateSpeed * Time.deltaTime);
    }
}
