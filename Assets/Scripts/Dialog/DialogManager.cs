using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {
    // bool dialogActive;
    bool changeView;

    GameObject playerCam;
    GameObject player;

    MeshRenderer playerMesh;

    PlayerLook playerLook;
    PlayerMove playerMove;

    Transform currentView;
    Transform playerView;
    public Transform npcView;

    public float transitionSpeed;

    // public GameObject dialogCollection;
    // GameObject dialogTitle;
    // GameObject dialogText;
    // GameObject dialogOption1;
    // GameObject dialogOption2;
    // GameObject dialogOption3;


    void Start() {
        GameObject playerViewObject = GameObject.Find("Player/Normal view");
        playerView = playerViewObject.GetComponent<Transform>();

        playerCam = GameObject.Find("Character/Player/Main camera");
        // GameObject playerCamObject = GameObject.Find("Character/Player/Main camera");
        // playerCam = playerCamObject.GetComponent<Camera>();

        player = GameObject.Find("Player");
        playerLook = player.GetComponent<PlayerLook>();
        playerMove = player.GetComponent<PlayerMove>();
        playerMesh = player.GetComponent<MeshRenderer>();

        // dialogTitle = GameObject.Find("Character/UI/Dialog/Title");
        // dialogText = GameObject.Find("Character/UI/Dialog/Text");
        // dialogOption1 = GameObject.Find("Character/UI/Dialog/Option 1");
        // dialogOption2 = GameObject.Find("Character/UI/Dialog/Option 2");
        // dialogOption3 = GameObject.Find("Character/UI/Dialog/Option 3");
    }

    // void Update() {
    //     if (Input.GetKeyDown (KeyCode.Alpha1)) {
    //         playerLook.canLook = true;
    //         playerMove.canMove = true;
    //         currentView = playerView;
    //     }

    //     if (Input.GetKeyDown (KeyCode.Alpha2)) {
    //         playerLook.canLook = false;
    //         playerMove.canMove = false;
    //         currentView = npcView;
    //     }
    // }

    public void startConversation() {
        changeView = true;
        // Move camera and prevent player from moving
        currentView = npcView;
        playerLook.canLook = false;
        playerMove.canMove = false;
        playerMesh.enabled = false;

        // Show dialog UI elements
        // dialogDisplayState(true);

        StartCoroutine(resetCam());
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

    // void dialogDisplayState(bool state) {
    //     dialogTitle.SetActive(state);
    //     dialogText.SetActive(state);
    //     dialogOption1.SetActive(state);
    //     dialogOption2.SetActive(state);
    //     dialogOption3.SetActive(state);
    // }

    // public void Test() {
    //     currentView = npcView;
    //     StartCoroutine(resetCam());
    // }

    IEnumerator resetCam() {
        yield return new WaitForSeconds(5);
        // dialogDisplayState(false);
        currentView = playerView;

        playerLook.canLook = true;
        playerMove.canMove = true;

        yield return new WaitForSeconds(3);
        playerMesh.enabled = true;
        changeView = false;
        Debug.Log("Ended");
    }
}
