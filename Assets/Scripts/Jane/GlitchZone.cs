using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchZone : MonoBehaviour {
    AudioSource audioSource;

    public GameObject[] glitchZoneComponents;
    bool isAvailable = true;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter() {
        audioSource.Play();
    }

    public void OnTriggerStay() {
        if (isAvailable) {
            
            int componentCount = (glitchZoneComponents.Length);

            int glitchObject = Random.Range(0, componentCount);
            glitchZoneComponents[glitchObject].SetActive(false);

            StartCoroutine(turnObjectOn(glitchZoneComponents[glitchObject]));
            StartCoroutine(waitForNext());
            isAvailable = false;
        }
    }

    void OnTriggerExit() {
        audioSource.Stop();
    }

    IEnumerator turnObjectOn(GameObject asset) {
        int waitTime = Random.Range(0, 3000);
        yield return new WaitForSeconds(waitTime / 1000);
        asset.SetActive(true);
    }

    IEnumerator waitForNext() {
        int waitTime = Random.Range(0, 2);
        // yield return new WaitForSeconds(waitTime);
        yield return new WaitForSeconds(0.1F);
        isAvailable = true;
    }

}
