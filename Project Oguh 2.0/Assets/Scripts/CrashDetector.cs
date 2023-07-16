using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashExplosion;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] float loadDelay = 4f;

    Animator planeAnimator;
    Player playerScript;

    bool crashFunctionCalled = false;

    void Start() 
    {
        planeAnimator = GetComponent<Animator>();
        playerScript = GetComponent<Player>();
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(crashFunctionCalled)
        {
            return;
        }

        PlaneHasCrashed();
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(crashFunctionCalled)
        {
            return;
        }

        if (other.tag == "MainCamera")
        {
            PlaneHasCrashed();
        }
    }

    void PlaneHasCrashed()
    {
        playerScript.DisableControllers();
        crashExplosion.Play();
        GetComponent<AudioSource>().PlayOneShot(crashSFX);
        crashFunctionCalled = true;

        planeAnimator.SetTrigger("planeCrashed");
        Invoke("ReloadScene", loadDelay);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}