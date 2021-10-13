using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {
    GameObject player;
    PlayerLook playerLook;
    PlayerMove playerMove;

    Transform playerView;
    public Transform npcView;

    public float transitionSpeed;

    Transform currentView;

    void Start() {
        GameObject playerViewObject = GameObject.Find("Normal view");
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
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3 (
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed)
            );

        transform.eulerAngles = currentAngle;
    }

    // public void Test() {
    //     currentView = npcView;
    //     StartCoroutine(resetCam());
    // }

    // IEnumerator resetCam() {
    //     Debug.Log("Ended");
    //     yield return new WaitForSeconds(5);
    //     currentView = playerView;
    // }
}
