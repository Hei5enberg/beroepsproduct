using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIntro : MonoBehaviour
{
    DialogManager dialogManager;
    bool introPlayed = false;
    public bool isFinalDialog;

    void Start() {
        dialogManager = GetComponent<DialogManager>();
    }

    void OnTriggerEnter() {
        introPlayed = true;
        dialogManager.startDialog();

        if (isFinalDialog) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
