using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    float smoothSpeed = 0.25f;
    Vector3 offset = new Vector3(5, 10, 0);
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

        transform.LookAt(target);

    }

}
