using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    [SerializeField] Text overlayText;
    [SerializeField] GameObject obj;
    [SerializeField] List<string> storyText;
    public int toDisplay;

    private void Start()
    {
        StartCoroutine(StoryDisplay());
    }

    IEnumerator StoryDisplay()
    {
        
        yield return new WaitForSeconds(1f);
        overlayText.fontSize = 30;
        overlayText.text = storyText[toDisplay];
        yield return new WaitForSeconds(8f);
        overlayText.fontSize = 50;
        overlayText.gameObject.transform.parent.gameObject.SetActive(false);
    }

    public void EndStory(int index)
    {
        obj.SetActive(false);
        overlayText.gameObject.transform.parent.gameObject.SetActive(true);
        overlayText.fontSize = 30;
        if (index == 1)
        {
            overlayText.text = "Bomb has been Defused";
        }
        else
        {
            overlayText.text = "Nuclear Bomb Blast";
        }

        StartCoroutine(StoryDisplayEnd(index));
    }

    IEnumerator StoryDisplayEnd(int index)
    {
        overlayText.text = storyText[index];
        //Time.timeScale = 0;
        yield return new WaitForSeconds(7f);
        overlayText.text = storyText[4];
        yield return new WaitForSeconds(7f);
        overlayText.text = "Made By \n\n Prorammer: Saurya Saurav \n Artist: Jainesh Pathak \n \n A Game For Global Game Jam 2020 \n\n Thanks For Playing";
        yield return new WaitForSeconds(6f);
        overlayText.gameObject.transform.parent.gameObject.GetComponent<Image>().color = Color.black;
        overlayText.text = "";

        //yield return new WaitForSeconds(8f);
        //overlayText.fontSize = 50;
        //overlayText.gameObject.transform.parent.gameObject.SetActive(false);
    }
}
