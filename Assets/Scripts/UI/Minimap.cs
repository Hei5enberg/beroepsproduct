using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;

    void LateUpdate() {
        // Moving the camera
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        // Rotating the Camera
        transform.rotation = Quaternion.Euler(45f, player.eulerAngles.y, 0f);
    }
}
