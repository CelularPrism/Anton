using System.Collections;
using System.Runtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Text Respect;
    [SerializeField] private Text Money;

    [SerializeField] private GameObject[] visitors;

    private Item Trash;

    public int MaxMassDump = 50;
    public int MaxMassPlayer = 5;
    
    public float PlayerMoney = 0f;
    public float PlayerRespect = 0f;
    public float SceneCharm;

    void FixedUpdate()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Trash");
        SceneCharm = 0f;

        foreach (var i in gameObjects)
        {
            TrashDisplay item = i.GetComponent<TrashDisplay>();
            SceneCharm += item.Trash.charm;
        }

        Respect.text = "Respect: " + PlayerRespect.ToString();
        Money.text = "Money: " + PlayerMoney.ToString();

        CheckedCharm();
    }

    public float Distance(Transform playerTransform, Transform trashTransform)
    {
        Trash = trashTransform.gameObject.GetComponent<TrashDisplay>().Trash;
        trashTransform.gameObject.GetComponent<TrashDisplay>().Delete();

        PlayerMoney += Trash.price;
        PlayerRespect += Trash.respect;
        return Trash.mass;
    }

    private void CheckedCharm()
    {
        int i = 0;

        if (GameObject.FindGameObjectsWithTag("Visitor").Length <= 10)
        {
            if (SceneCharm > -500 && SceneCharm < 10000000000)
            {
                while (i < visitors.Length && visitors[i].GetComponent<AIVisitor>().visitor.TypeVisitor != "Third")
                    i++;
                Spawn(visitors[i]);

            } else if (SceneCharm > -1000 && SceneCharm < -50)
            {
                while (i < visitors.Length && visitors[i].GetComponent<AIVisitor>().visitor.TypeVisitor != "Second")
                    i++;
                Spawn(visitors[i]);

            } else if (SceneCharm > -1000000 && SceneCharm < -500)
            {
                while (i < visitors.Length && visitors[i].GetComponent<AIVisitor>().visitor.TypeVisitor != "First")
                    i++;
                Spawn(visitors[i]);
            }
        }
    }

    private void Spawn(GameObject gameObject)
    {
        Vector3 position = new Vector3(0, 1.5f, 0);
        position.x = Random.Range(-40f, 40f);
        position.z = Random.Range(-40f, 40f);

        Instantiate(gameObject, position, transform.rotation, transform);
    }
}
