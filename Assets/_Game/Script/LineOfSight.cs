using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    [SerializeField] float fieldOfViewAngle = 120;
    [SerializeField] float radius;
    [SerializeField] GameObject player;
    [SerializeField] KillPlayer kp;
    bool playerInsight;
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInsight = false;

            Vector3 dir = other.transform.position - transform.position;
            float angle = Vector3.Angle(dir, transform.forward);

            if (angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;

                    Debug.DrawRay(transform.position + transform.forward, dir.normalized, Color.blue);
                if (Physics.Raycast(transform.position + transform.forward, dir.normalized, out hit, radius))
                {
                    print("Check1" + hit.collider.name);
                    if (hit.collider.gameObject.CompareTag("Player")/* == player*/)
                    {
                        playerInsight = true;
                        kp.Kill();
                        print("GameOver: Player Found");
                    }
                }
            }
        }
    }
}
