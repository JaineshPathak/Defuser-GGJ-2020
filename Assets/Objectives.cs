using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
    [SerializeField] List<string> obectives;
    [SerializeField] Text obText;

    public void ChangeText(int index)
    {
        obText.text = obectives[index];
    }
}
