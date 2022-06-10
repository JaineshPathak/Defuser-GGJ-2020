using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    //[SerializeField] KillPlayer kp;
    [SerializeField] GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.GetChild(0).gameObject.SetActive(true);
            UIScript.UIS.GameOver();
            //kp.GameOver();
        }
    }
}
