using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationPointer : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);        
    }
}
