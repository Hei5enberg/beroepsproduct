using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int sceneIndex;

    public void startGame() {
        SceneManager.LoadScene(sceneIndex);
    }

}
