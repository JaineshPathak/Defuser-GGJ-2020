using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public static UIScript UIS;
    [SerializeField] LevelController lc;
    [SerializeField] GameObject overlay;
    [SerializeField] GameObject locator;
    [SerializeField] Text overlayText;
    [SerializeField] Button restart;

    private void Awake()
    {
        if (UIS == null)
            UIS = this;
    }

    public void GameOver()
    {
        overlay.SetActive(true);
        overlayText.text = "You Were Caught";
        restart.gameObject.SetActive(true);
        locator.gameObject.SetActive(false);
        PlayerControllerGame.GAMEOVER = true;
        StartCoroutine(WaitForGO());
    }

    IEnumerator WaitForGO()
    {
        yield return new WaitForSeconds(1.5f);
        lc.GameStop();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
