using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogManager : MonoBehaviour {
    GameObject player;
    MeshRenderer playerMesh;
    PlayerLook playerLook;
    PlayerMove playerMove;

    ChangeView changeView;

    // public List<Charlie> sentences = new List<Charlie>();
    // public List<ArrayList> sentences2 = new List<ArrayList>(3);
    

    [Header("UI element containing dialog components")]
    [SerializeField] private GameObject dialogParent;

    void Start() {
        changeView = GetComponent<ChangeView>();
        // dialogText = dialogText.GetComponent<Text>();

        player = GameObject.Find("Player");
        playerLook = player.GetComponent<PlayerLook>();
        playerMove = player.GetComponent<PlayerMove>();
        playerMesh = player.GetComponent<MeshRenderer>();
    }

    private void endDialog() {
        dialogParent.SetActive(false);
    }


    public void startConversation() {
        // Move camera and prevent player from moving

        playerLook.canLook = false;
        playerMove.canMove = false;
        playerMesh.enabled = false;
        changeView.goToView(true);

        StartCoroutine(resetCam());
    }

    IEnumerator resetCam() {
        yield return new WaitForSeconds(5);
        playerLook.canLook = true;
        playerMove.canMove = true;
        changeView.goToView(false);

        // yield return new WaitForSeconds(3);
        playerMesh.enabled = true;
        Debug.Log("Ended");
    }
}
