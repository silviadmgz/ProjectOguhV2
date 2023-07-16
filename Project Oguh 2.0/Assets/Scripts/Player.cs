using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float baseSpeed = 4f;
    [SerializeField] float boostSpeed = 8f;
    bool canMove = true;
    CameraScript cameraScript;

    void Start() 
    {
        cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
    }

    void Update()
    {
        if (canMove)
        {
            cameraScript.CameraMovement();
            BaseSpeedPlayer();
            PlayerControls();
        }
    }

    public void BaseSpeedPlayer()
    {
        transform.Translate(baseSpeed * Time.deltaTime, 0, 0);
    }

    void PlayerControls()
    {             
        //up and down
        float yMovement = Input.GetAxis("Vertical") * boostSpeed * Time.deltaTime;
        transform.Translate(new Vector2(0, yMovement));

        //right and left
        float xMovement = Input.GetAxis("Horizontal") * boostSpeed * Time.deltaTime;
        transform.Translate(new Vector2(xMovement, 0));
    }

    public void UpdateControllers()
    {
        canMove = !canMove;
    }
}
