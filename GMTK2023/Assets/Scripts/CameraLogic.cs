using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public Vector3 offset;
    public float orthoSize = 5f;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = orthoSize;
    }

    void LateUpdate()
    {
        transform.position = target.position + offset;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
