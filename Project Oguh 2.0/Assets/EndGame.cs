using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
Player playerScript;

[SerializeField] float loadDelay = 4f;

void Start() 
{
    playerScript = FindObjectOfType<Player>();
}

void OnTriggerEnter2D(Collider2D other) 
{
    if (other.tag == "Player")
    {
        playerScript.UpdateControllers();
        Invoke("LoadNextScene", loadDelay);
    }
}

void LoadNextScene()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
}
}
