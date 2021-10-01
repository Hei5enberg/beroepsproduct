using UnityEngine;
using UnityEngine.SceneManagement;

public class HelloWorld : MonoBehaviour
{
    public int index;

    public void DoeIets() {
        Debug.Log("Hoi");
        SceneManager.LoadScene(index);
    }
}
