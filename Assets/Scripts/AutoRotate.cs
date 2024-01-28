using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Vector3 rotationAngles = new Vector3(0.0f, 50.0f, 0.0f);

    private void Update()
    {
        transform.Rotate(rotationAngles * Time.deltaTime);
    }
}
