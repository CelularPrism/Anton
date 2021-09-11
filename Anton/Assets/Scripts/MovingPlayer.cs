using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    [SerializeField] private SceneController controller;
    private GameObject Trash;
    private GameObject[] ListObjects;


    private float minDistance = 1000f;
    private float speed = 5f;
    private float mass = 0f;

    void Start()
    {
        if (controller == null)
            controller = FindObjectOfType<SceneController>();
    }

    void Update()
    {
        if (mass < controller.MaxMassPlayer)
            ListObjects = GameObject.FindGameObjectsWithTag("Trash");
        else
            ListObjects = GameObject.FindGameObjectsWithTag("Dump");

        if (ListObjects.Length > 0)
        {
            foreach (var i in ListObjects)
            {
                float Distance = Vector3.Distance(transform.position, i.gameObject.transform.position);

                if (Distance < minDistance)
                {
                    minDistance = Distance;
                    Trash = i.gameObject;
                }
            }

            minDistance = 1000f;

            if (Vector3.Distance(transform.position, Trash.transform.position) >= 1.5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, Trash.transform.position, speed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
            }
            else if (mass < controller.MaxMassPlayer)
            {
                mass += controller.Distance(transform, Trash.transform);
            }
            else
            {
                float massDump = Trash.GetComponent<Dump>().Mass;
                if (massDump - mass < 0)
                {
                    mass -= massDump;
                    Trash.GetComponent<Dump>().Mass -= massDump;
                } else {
                    Trash.GetComponent<Dump>().Mass -= mass;
                    mass = 0;
                }
            }
        }
    }
}
