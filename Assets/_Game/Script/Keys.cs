using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keys : MonoBehaviour
{
    [SerializeField] Objectives ob;
    [SerializeField] GameObject Gate;
    [SerializeField] int obectiveIndex;


    public void ToDestroy()
    {
        ob.ChangeText(obectiveIndex);
        Destroy(Gate);
        Destroy(transform.parent.gameObject);
    }

    public void LevelChange()
    {
        SceneManager.LoadScene(1);
    }
}
