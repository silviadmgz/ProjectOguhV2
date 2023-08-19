using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
Animator planeAnimator;
Player playerScript;

[SerializeField] float loadDelay = 4f;

void Start() 
{
    playerScript = FindObjectOfType<Player>();
    planeAnimator = playerScript.GetComponent<Animator>();
}

void OnTriggerEnter2D(Collider2D other) 
{
    if (other.tag == "Player")
    {
        playerScript.UpdateControllers();
        planeAnimator.SetTrigger("endGame");
        Invoke("LoadNextScene", loadDelay);
    }
}

void LoadNextScene()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
}
}
