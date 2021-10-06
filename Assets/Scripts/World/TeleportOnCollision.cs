using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnCollision : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;

    void OnTriggerEnter() {
        player.transform.position = teleportTarget.transform.position;
    }
}
