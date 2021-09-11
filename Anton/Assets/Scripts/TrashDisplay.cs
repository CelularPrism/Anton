using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDisplay : MonoBehaviour
{
    public Item Trash;
    public void Delete()
    {
        Destroy(transform.gameObject);
    }
}
