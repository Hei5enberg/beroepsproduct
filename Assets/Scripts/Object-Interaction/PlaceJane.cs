using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaceJane : MonoBehaviour
{
    public GameObject jane;
    public int finalSceneIndex;

    public void placeJane() {
        jane.SetActive(true);
        StartCoroutine(finishGame());
    }

    IEnumerator finishGame() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(finalSceneIndex);
    }
}
