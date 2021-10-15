using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public int random;
    void Start() {

    }

    public void Test() {
        random = Random.Range(0, 1000);
        Debug.Log(random);
    }

    public void Reset() {
        random = 0;
    }
}
