using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour {
    public GameObject playerCam;
    public GameObject playerViewObject;
    GameObject player;

    Transform currentView;
    Transform playerView;
    public Transform targetView;

    public float transitionSpeed;

    bool inPlayerView = false;

    void Start() {
        // GameObject playerViewObject = GameObject.Find("Player/Normal view");
        Debug.Log(playerViewObject);
        playerView = playerViewObject.GetComponent<Transform>();

        // playerCam = GameObject.Find("Player/Main camera");
        switchView();
    }

    public void switchView() {
        if (!inPlayerView) {
            currentView = playerView;
            inPlayerView = true;
        } else { 
            currentView = targetView; 
            inPlayerView = false;
        }
    }

    void FixedUpdate() {
        // Debug.Log("Player camera" + playerCam.transform.position);
        // Debug.Log("Player camera" + currentView.position);
        if (playerCam.transform.position != currentView.position) {
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
}
