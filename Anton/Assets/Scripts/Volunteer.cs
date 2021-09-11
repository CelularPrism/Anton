using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volunteer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AliveVolunteer());
    }

    IEnumerator AliveVolunteer()
    {
        yield return new WaitForSeconds(20);

        if (Random.Range(0, 100) < 80)
            Destroy(transform.gameObject);
        else
            transform.GetComponent<Renderer>().material.color = Color.cyan;
    }
}
