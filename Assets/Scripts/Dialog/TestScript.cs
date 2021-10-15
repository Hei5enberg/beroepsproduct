using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public ArrayLayout data;

    void Start() {
        Debug.Log(data[0][0]);
        Debug.Log(data[0][1]);
    }
}
