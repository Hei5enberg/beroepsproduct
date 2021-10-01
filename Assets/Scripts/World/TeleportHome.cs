using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHome : MonoBehaviour
{
    void OnTriggerEnter(Collider Col) {
        Col.transform.position = new Vector3 (0, 1, 0);
    }
}
