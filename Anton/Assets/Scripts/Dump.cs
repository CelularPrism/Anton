using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dump : MonoBehaviour
{
    [SerializeField] private RectTransform image;
    [SerializeField] private SceneController controller;
    [SerializeField] private Camera camera;

    public float Mass;
    void Start()
    {
        Mass = controller.MaxMassDump;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mass <= 0)
        {
            Vector3 pos = transform.position;

            image.gameObject.SetActive(true);
            image.position = camera.WorldToScreenPoint(pos + transform.localScale);

            transform.gameObject.tag = "Untagged";
        }
        else
            image.gameObject.SetActive(false);
    }

    public void FullDump()
    {
        transform.gameObject.tag = "Dump";
        Mass = controller.MaxMassDump;
    }
}
