using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMagazine : MonoBehaviour
{
    [SerializeField] private SceneController controller;
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform bus;

    public void EnabledPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void DisabledPanel(Transform button)
    {
        button.parent.gameObject.SetActive(false);
    }

    public void SetVolunteers()
    {
        if (controller.PlayerRespect >= 100)
        {
            Transform scene = GameObject.FindGameObjectWithTag("Scene").transform;
            GameObject volunteer = Player;
            Instantiate(volunteer, bus.position, scene.rotation, scene);
            controller.PlayerRespect -= 100;
        }
    }

    public void TabListener(GameObject panel)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Panel");
        foreach (var i in gameObjects)
            i.SetActive(false);

        panel.SetActive(true);
    }
}
