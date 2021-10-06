using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorsToOtherScene : MonoBehaviour
{  
    Animator animator;
    AudioSource audioSource;

    // public AudiClip openSound;
    public int sceneIndex;


    void Start() {
        animator = GetComponent<Animator>();
        // audioSource = GetComponent<AudioSouce>();
    }

    public void openDoors() {
        // audioSource.PlayOneShot(openSound);
        animator.SetTrigger("open");
        SceneManager.LoadScene(sceneIndex);
        animator.SetTrigger("close");

    }
}
