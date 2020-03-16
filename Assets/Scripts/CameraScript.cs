using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float distanceFromTarget = 4;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
