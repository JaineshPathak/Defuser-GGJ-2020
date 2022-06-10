using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerControllerGame : MonoBehaviour
{
    [SerializeField] LevelController lc;

    [SerializeField] Camera camera;
    [SerializeField] AudioSource click;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject locationPointer;

    public static bool GAMEOVER = false;
    
    //GameObject oldArrow;
    GameObject currArrow;
    private void Start()
    {
        GAMEOVER = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GAMEOVER)
        {
            var mousepos = Input.mousePosition;
            Ray ray = camera.ScreenPointToRay(mousepos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.CompareTag("Platform"))
            {
                click.Play(0);
                print("xx");
                Vector3 objPos = hit.point;
                objPos.y = 15;
                agent.SetDestination(objPos);
                //currArrow = Instantiate(locationPointer, objPos, Quaternion.identity);
                locationPointer.transform.position = objPos;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Key2"))
        {
            lc.LevelFinish();
            other.gameObject.GetComponent<Keys>().LevelChange();
        }
        if (other.gameObject.CompareTag("Key1"))
        {
            lc.KeysFound = 1;
            other.gameObject.GetComponent<Keys>().ToDestroy();
            //Destroy(other.gameObject);
        }

        //if (other.gameObject.CompareTag("Enemy"))
        //{
        //    print("From Here");
        //}
    }
}
