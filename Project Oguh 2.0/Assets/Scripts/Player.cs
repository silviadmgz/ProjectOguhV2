using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float baseSpeed = 4f;
    [SerializeField] float boostSpeed = 8f;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, boostSpeed * Time.deltaTime, 0);
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -boostSpeed * Time.deltaTime, 0);
        }

        //right and left
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(boostSpeed * Time.deltaTime, 0, 0);
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-boostSpeed * Time.deltaTime, 0, 0);
        }
    }

}
