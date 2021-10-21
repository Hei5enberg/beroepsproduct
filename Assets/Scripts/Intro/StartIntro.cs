using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIntro : MonoBehaviour
{
    DialogManager dialogManager;
    bool introPlayed = false;

    void Start() {
        dialogManager = GetComponent<DialogManager>();
    }

    void OnTriggerEnter() {
        introPlayed = true;
        dialogManager.startDialog();
    }
}
