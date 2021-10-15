using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteractTest : MonoBehaviour
{
    Dialog d;
    List<Dialog> sentences = new List<Dialog>();

    void Start() {
        foreach (Dialog d in sentences) {
            Debug.Log(d.type);
        }
    }
}
