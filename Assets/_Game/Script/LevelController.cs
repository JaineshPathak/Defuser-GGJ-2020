using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] LevelSettings ls;
    int keysCount;
    float levelTime;
    int keysFound = 0;
    bool foundAllkeys;

    public int KeysFound 
    {
        set
        {
            keysFound += value;
            ValidateKeys();
        }
        get => keysFound; 
    }
    public float LevelTime { get => levelTime; }
    public bool FoundAllKeys { private set => foundAllkeys = value;  get => foundAllkeys; }

    void Start()
    {
        Time.timeScale = 1;
        keysCount = ls.KeysCount;
        levelTime = ls.LevelTime;
    }

    private void ValidateKeys()
    {
        if (keysFound == keysCount)
        {
            print("Found All keys");
            FoundAllKeys = true;
        }
    }

    public void LevelFinish()
    {
        if (FoundAllKeys)
        {
            print("Level Finish");
        }
        else
        {
            print("Keys Collected:" + KeysFound + "/" + keysCount +" Collect All Keys");
        }
    }

    public void GameStop()
    {
        Time.timeScale = 0;
    }


}
