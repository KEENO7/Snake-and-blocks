using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public SnakeTail Target;
    public Vector3 CameraOffset;

    private void Start()
    {

    }

    private void Update()
    {
        Vector3 targetPosition = Target.transform.position + CameraOffset;
        transform.position = targetPosition;

    }
}
