using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextScene2 : MonoBehaviour
{
        AudioSource audioSource;
        public int index;
        public AudioClip doorOpenClip;

        public void Start() {
            audioSource = GetComponent<AudioSource>();
        }

        public void openDoor() {
            StartCoroutine(goToScene());
        }

        private IEnumerator goToScene() {
        audioSource.PlayOneShot(doorOpenClip);
        float waitTime = doorOpenClip.length - 0.5F;
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(index);
    }
}
