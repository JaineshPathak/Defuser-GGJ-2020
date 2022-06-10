using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform targetToFollow;
    public Vector3 offset;
    public float smoothness = 0.2f;

    private Vector3 vel;

    private void Update()
    {
        Vector3 pos = targetToFollow.transform.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref vel, smoothness);
        transform.LookAt(targetToFollow);
    }
}
