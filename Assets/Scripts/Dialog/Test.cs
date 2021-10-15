using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{ 
    public int randomNumber = 0;
    
    public void generateNumber() {
        randomNumber = Random.Range(0, 1000);
    }
}
