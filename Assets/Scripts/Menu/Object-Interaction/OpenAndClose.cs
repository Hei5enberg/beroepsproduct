using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndClose : MonoBehaviour {

    Animator animator;
    AudioSource audioSource;

    // Variables
    bool isOpen;
    bool objectHasSound;

    public AudioClip openSound;
    public AudioClip closeSound;
    
    void Start() {
        animator = GetComponent<Animator>();
        isOpen = false;

        if (objectHasSound) {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void OpenOrClose() {
        if (!isOpen) {
            animator.SetTrigger("open");

            if (objectHasSound) { audioSource.PlayOneShot(openSound); }
            isOpen = true;

        } else {
            animator.SetTrigger("close");

            if (objectHasSound) { audioSource.PlayOneShot(closeSound); }
            isOpen = false;
        }
    }
}
