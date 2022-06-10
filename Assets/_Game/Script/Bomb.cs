using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] Story story;
    
    [SerializeField] GameObject blastParticle;
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject player;
    [SerializeField] GameObject locator;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            button1.SetActive(true);
            button2.SetActive(true); 
            PlayerControllerGame.GAMEOVER = true;
        }
    }


    public void Button1()
    {
        //Defuse
        button1.SetActive(false);
        button2.SetActive(false);
        locator.SetActive(false);
        story.EndStory(1);

    }
    public void Button2()
    {
        //Blast
        blastParticle.SetActive(true);
        locator.SetActive(false);
        player.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        story.EndStory(2);

    }
}
