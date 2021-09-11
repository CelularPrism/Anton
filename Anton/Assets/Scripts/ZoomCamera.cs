using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField] private Transform scene;
    private Touch touch;

    float minZoom = 25f;
    float maxZoom = 80f;
    float speed = 0.01f;

    void Update()
    {
        if (Input.touchCount == 1) {
            float sceneScaleX = scene.localScale.x / 2;
            float sceneScaleZ = scene.localScale.z / 2;
            touch = Input.GetTouch(0);

            float posX = transform.position.x - touch.deltaPosition.x * speed;
            float posZ = transform.position.z - touch.deltaPosition.y * speed;

            posX = Mathf.Clamp(posX, -sceneScaleX, sceneScaleX);
            posZ = Mathf.Clamp(posZ, -sceneScaleZ, sceneScaleZ); ;

            transform.position = new Vector3(posX, transform.position.y, posZ);

        } else if (Input.touchCount == 2) {

            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroLastPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOneLastPos = touchOne.position - touchOne.deltaPosition;

            float distTouch = (touchZeroLastPos - touchOneLastPos).magnitude;
            float currentDistTouch = (touchZero.position - touchOne.position).magnitude;

            float difference = currentDistTouch - distTouch;
            Zoom(difference * 0.01f);
        }
    }

    void Zoom(float increment)
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - increment, minZoom, maxZoom);
    }
}
