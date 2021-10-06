using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOutsideButton : MonoBehaviour
{
    Animator animator;
    // AudioSource audioSource;

    public GameObject roomAsset;
    public int buildingNumberOfFloors;
    // public AudioClip elevatorButton;
    // public AudioClip elevatorDing;
    // public AudioClip elevatorDoor;
    
    float elevatorWaitTime;
        
    void Start() {
        animator = roomAsset.GetComponent<Animator>();
        // audioSource = GetComponent<AudioSource>();
        float randomMax = (float)((buildingNumberOfFloors + 1) * 1.5F);
        Debug.Log(randomMax);
        Debug.Log("hoi");
        float elevatorWaitTime = Random.Range(0, randomMax);
        Debug.Log(elevatorWaitTime);
    }

    public void callElevator() {
        // audioSource.PlayOneShot(elevatorButton);
        StartCoroutine(waitOnElevator());
        buildingNumberOfFloors = 1;
    }

    IEnumerator waitOnElevator() {
        yield return new WaitForSeconds(elevatorWaitTime);
        Debug.Log("opening");
        // audioSource.PlayOneShot(elevatorDing);
        animator.SetTrigger("open");

        yield return new WaitForSeconds(5);
        // audioSource.PlayOneShot(elevatorDoor);
        animator.SetTrigger("close");

    }
}
