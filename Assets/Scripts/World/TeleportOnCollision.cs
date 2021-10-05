using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnCollision : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;

    void OnTriggerEnter() {
        //Col.transform.position = new Vector3 (xPosition, yPosition, zPosition);
        // Col.transform.position = new Vector3 (0, 0, 0);
        player.transform.position = teleportTarget.transform.position;
    }
}
