using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashExplosion;
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        gameObject.GetComponent<Player>().PlaneHasCrashed();
        crashExplosion.Play();
        Debug.Log("Crashed with ground");
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "MainCamera")
        {
            
            gameObject.GetComponent<Player>().PlaneHasCrashed();crashExplosion.Play();
            Debug.Log("Went out of the camera");
        }
    }
}