using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LightTrigger : MonoBehaviour
{
    public Light myLight; // Assign your light in the Inspector
    public AudioSource audioSource;

    private void Start()
    {
        // Optional: start with the light off
        if (myLight != null)
        {
            myLight.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the entering object is the player (optional, but recommended)
        if (other.CompareTag("Player"))
        {
            myLight.enabled = true; // Turn on the light
            audioSource.Play();
        }
    }

    // // Optional: Turn off the light when exiting the trigger
    // void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         myLight.enabled = false; // Turn off the light
    //     }
    // }
}