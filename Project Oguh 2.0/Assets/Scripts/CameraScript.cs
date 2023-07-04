using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] float baseSpeed = 4f;

    public void CameraMovement()
    {
        transform.Translate(baseSpeed * Time.deltaTime, 0, 0);
    }
}
