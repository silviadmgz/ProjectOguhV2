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

    bool crashFunctionCalled = false;

    void Start() 
    {
        planeAnimator = GetComponent<Animator>();   
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(crashFunctionCalled)
        {
            return;
        }

        PlaneHasCrashed();
        Debug.Log("Crashed with ground");
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
            Debug.Log("Went out of the camera");
        }
    }

    void PlaneHasCrashed()
    {
        gameObject.GetComponent<Player>().DisableControllers();
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