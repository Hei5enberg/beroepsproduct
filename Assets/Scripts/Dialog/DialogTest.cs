using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTest : MonoBehaviour {
    GameObject player;
    PlayerLook playerLook;
    PlayerMove playerMove;

    Transform currentView;
    Transform playerView;
    public Transform npcView;

    public GameObject playerCam;

    public float transitionSpeed;

    void Start() {
        GameObject playerViewObject = GameObject.Find("Player/Normal view");
        playerView = playerViewObject.GetComponent<Transform>();

        player = GameObject.Find("Player");
        playerLook = player.GetComponent<PlayerLook>();
        playerMove = player.GetComponent<PlayerMove>();
    }

    void Update() {
        if (Input.GetKeyDown (KeyCode.Alpha1)) {
            playerLook.canLook = true;
            playerMove.canMove = true;
            currentView = playerView;
        }

        if (Input.GetKeyDown (KeyCode.Alpha2)) {
            playerLook.canLook = false;
            playerMove.canMove = false;
            currentView = npcView;
        }
    }

    void LateUpdate() {
        //Lerp position
        playerCam.transform.position = Vector3.Lerp(playerCam.transform.position, currentView.position, Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3 (
            Mathf.LerpAngle(playerCam.transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(playerCam.transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(playerCam.transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed)
            );

        playerCam.transform.eulerAngles = currentAngle;
    }
}