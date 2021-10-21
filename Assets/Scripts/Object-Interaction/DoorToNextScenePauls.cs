using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorToNextScenePauls : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip doorOpenClip;
    public int index;
    public GameObject cutScenePanel;

    public void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadScene() {
        StartCoroutine(goToScene());
    }

    public IEnumerator goToScene() {
        audioSource.PlayOneShot(doorOpenClip);
        float waitTime = doorOpenClip.length - 0.5F;
        yield return new WaitForSeconds(waitTime);
        cutScenePanel.SetActive(true);
        yield return new WaitForSeconds(17);
        SceneManager.LoadScene(index);
    }
}
