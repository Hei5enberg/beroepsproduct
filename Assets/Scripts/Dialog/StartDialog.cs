using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : MonoBehaviour {

    public GameObject dialogWindow;

    public PlayerLook player;
    public PlayerMove player2;

    public Transform target;
    // public GameObject mainCamera;

    bool isVisible;

    void Start() {
        isVisible = false;
        dialogWindow.SetActive(false);
    }

    public void OpenDialog() {
        if (!isVisible) {
            dialogWindow.SetActive(true);
            // Cursor.visible = true;

            transform.LookAt(target);

            player.lookScriptActive = false;
            player2.moveScriptActive = false;

            isVisible = true;
        } else {
            dialogWindow.SetActive(false);
            Cursor.visible = false;

            player.lookScriptActive = true;
            player2.moveScriptActive = true;

            isVisible = false;
        }
    }
}
