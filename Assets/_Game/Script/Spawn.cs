using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject objective;
    [SerializeField] GameObject locator;
    [SerializeField] GameObject timeMachine;
    [SerializeField] GameObject camera;


    private void Start()
    {
        StartCoroutine(InitialSpawner());
    }

    IEnumerator InitialSpawner()
    {
        yield return new WaitForSeconds(3f);
        timeMachine.SetActive(true);
        yield return new WaitForSeconds(3f);
        player.SetActive(true);
        locator.SetActive(true);
        yield return new WaitForSeconds(3f);
        objective.SetActive(true);
        //camera.transform.parent = player.transform;

        StopCoroutine(InitialSpawner());
    }
}
