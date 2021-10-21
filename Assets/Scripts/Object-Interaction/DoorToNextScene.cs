using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorToNextScene : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip doorOpenClip;
    public int index;

    public void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadScene() {
        StartCoroutine(goToScene());
    }

    public IEnumerator goToScene() {
        audioSource.PlayOneShot(doorOpenClip);
        float waitTime = doorOpenClip.length;
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(index);
    }
}
