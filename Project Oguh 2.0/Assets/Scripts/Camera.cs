using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] float baseSpeed = 4f;

    void Update()
    {

    }

    public void CameraMovement()
    {
        transform.Translate(baseSpeed * Time.deltaTime, 0, 0);
    }
}
