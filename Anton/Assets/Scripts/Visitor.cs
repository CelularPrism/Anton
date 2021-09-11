using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trash", menuName = "Game/Visitor/Type")]
public class Visitor : ScriptableObject
{
    public string TypeVisitor = "";
    public float ChanceDrop = 0;
    public float MaxKolvoTrash = 0;
}
