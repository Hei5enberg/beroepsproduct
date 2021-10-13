using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {
    bool dialogActive;
    GameObject player;
    PlayerLook playerLook;
    PlayerMove playerMove;
    Transform currentView;
    Transform playerView;
    
    // public GameObject dialogCollection;
    GameObject dialogTitle;
    GameObject dialogText;
    GameObject dialogOption1;
    GameObject dialogOption2;
    GameObject dialogOption3;

    public GameObject playerCam;

    public Transform npcView;

    public float transitionSpeed;

    void Start() {
        GameObject playerViewObject = GameObject.Find("Player/Normal view");
        playerView = playerViewObject.GetComponent<Transform>();

        // GameObject playerCam = GameObject.Find("Character/Player/Main camera");
        // GameObject playerCamObject = GameObject.Find("Character/Player/Main camera");
        // playerCam = playerCamObject.GetComponent<Camera>();

        player = GameObject.Find("Player");
        playerLook = player.GetComponent<PlayerLook>();
        playerMove = player.GetComponent<PlayerMove>();

        dialogTitle = GameObject.Find("Character/UI/Dialog/Title");
        dialogText = GameObject.Find("Character/UI/Dialog/Text");
        dialogOption1 = GameObject.Find("Character/UI/Dialog/Option 1");
        dialogOption2 = GameObject.Find("Character/UI/Dialog/Option 2");
        dialogOption3 = GameObject.Find("Character/UI/Dialog/Option 3");
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

    public void startConversation() {
        // Move camera and prevent player from moving
        currentView = npcView;

        playerLook.canLook = false;
        playerMove.canMove = false;

        // Show dialog UI elements
        dialogDisplayState(true);

        StartCoroutine(resetCam());
    }

    void lateUpdate() {
        //Lerp position
        playerCam.transform.position = Vector3.Lerp(playerCam.transform.position, currentView.position, Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3 (
            Mathf.LerpAngle(playerCam.transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(playerCam.transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(playerCam.transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed)
            );

        playerCam.transform.eulerAngles = currentAngle;
    }

    void dialogDisplayState(bool state) {
        dialogTitle.SetActive(state);
        dialogText.SetActive(state);
        dialogOption1.SetActive(state);
        dialogOption2.SetActive(state);
        dialogOption3.SetActive(state);
    }

    // public void Test() {
    //     currentView = npcView;
    //     StartCoroutine(resetCam());
    // }

    IEnumerator resetCam() {
        yield return new WaitForSeconds(5);
        dialogDisplayState(false);
        currentView = playerView;
        Debug.Log("Ended");
    }
}
