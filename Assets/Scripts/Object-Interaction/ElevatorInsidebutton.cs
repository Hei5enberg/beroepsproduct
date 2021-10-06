using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorInsidebutton : MonoBehaviour
{
    Animator animator;
    // AudioSource audioSource;

    public GameObject roomAsset;
    public int sceneIndex;
    public int targetFloor;

    // public AudioClip elevatorButton;
    // public AudiClip elevatorMoving;
    // public AudiClip elevatorDing;

    float elevatorTravelTime;

    void Start() {
        animator = roomAsset.GetComponent<Animator>();
        // audioSource = GetComponent<AudioSource>();
        float elevatorTravelTime = (float)(targetFloor * 2);
    }

    public void elevatorGo() {
        // audioSource.PlayOneShot(elevatorButton);
        StartCoroutine(elevatorTravel());
    }

    IEnumerator elevatorTravel() {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(2);
        
        // audioSource.Play(elevatorMoving);
        yield return new WaitForSeconds(elevatorTravelTime);
        // audioSource.PlayOneShot(elevatorDing);
        // audioSource.Stop(elevatorMoving);
       
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneIndex);
    }
}
