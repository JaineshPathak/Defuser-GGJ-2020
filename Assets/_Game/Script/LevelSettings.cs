using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] int keysCount;
    [SerializeField] float levelTime;

    public int KeysCount{ get => keysCount;}
    public float LevelTime{ get => levelTime;}
}
