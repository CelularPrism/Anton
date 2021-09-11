using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trash", menuName = "Game/Trash/Item")]
public class Item : ScriptableObject
{
    public string Name = null;

    public float price = 0f;
    public float charm = 0f;
    public float respect = 0f;
    public int mass = 0;
}
