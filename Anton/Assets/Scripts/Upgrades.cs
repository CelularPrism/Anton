using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private SceneController controller;

    public void GarbageBag(GameObject button)
    {
        if (controller.PlayerMoney >= 1)
        {
            controller.MaxMassDump += 200;
            controller.MaxMassPlayer += 15;

            controller.PlayerMoney -= 1;
            Destroy(button);
        }
    }
}
