using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] List<Vector3> camPos;
    [SerializeField] List<Vector3> camAngle;
    int posIndex = 0;
    int angleIndex = 0;

    private void Start()
    {
        cam.transform.position = camPos[0];
        cam.transform.rotation = Quaternion.Euler(camAngle[0]);

    }

    public void RotateRight()
    {
        posIndex++;
        angleIndex++;
        if (posIndex>3)
        {
            posIndex = 0;
            angleIndex = 0;
        }
        
        cam.transform.position = camPos[posIndex];
        cam.transform.rotation = Quaternion.Euler(camAngle[angleIndex]);
    }
    
    public void RotateLeft()
    {
        posIndex--;
        angleIndex--;
        if (posIndex < 0)
        {
            posIndex = 3;
            angleIndex = 3;
        }
        cam.transform.position = camPos[posIndex];
        cam.transform.rotation = Quaternion.Euler(camAngle[angleIndex]);
    }
}
