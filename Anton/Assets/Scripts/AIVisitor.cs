using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVisitor : MonoBehaviour
{
    public Visitor visitor;

    private GameObject[] Trashes;
    void Start()
    {
        Trashes = Resources.LoadAll<GameObject>("PrefabsTrash");
        if (Random.Range(0f, 100f) < visitor.ChanceDrop)
        {
            for (int i = 0; i <= Random.Range(1, visitor.MaxKolvoTrash); i++)
            {
                GameObject Trash = Trashes[Random.Range(0, Trashes.Length)];

                Vector3 coorTrash = transform.position;
                coorTrash.x = transform.position.x + Random.Range(-5f, 5f);
                coorTrash.z = transform.position.z + Random.Range(-5f, 5f);

                Instantiate(Trash, coorTrash, transform.rotation, transform);
            }
        }

        float TimeDeath = Random.Range(30f, 90f);
        Destroy(transform.gameObject, TimeDeath);
    }

    void FixedUpdate()
    {
        
    }
}
