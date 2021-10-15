using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    public TextAsset dialogData;
    List<Dialog> sentences = new List<Dialog>();

    ChangeView changeView;
    GameObject player;
    PlayerLook playerLook;
    PlayerMove playerMove;
    MeshRenderer playerMesh;    

    public GameObject dialogParent;
    public Text title;
    public Text message;
    public Button option1;
    public GameObject option2;
    public GameObject option3;

    Text option1Text;
    Text option2Text;
    Text option3Text;

    Button option1Btn;

    Test test;

    bool dialogActive = false;

    void Start() {
        LoadDialog();

        changeView = GetComponent<ChangeView>();

        player = GameObject.Find("Player");
        playerLook = player.GetComponent<PlayerLook>();
        playerMove = player.GetComponent<PlayerMove>();
        playerMesh = player.GetComponent<MeshRenderer>();

        option1Text = option1.GetComponentInChildren<Text>();
        option2Text = option2.GetComponentInChildren<Text>();
        option3Text = option3.GetComponentInChildren<Text>();
        
        Button btn = option1.GetComponent<Button>();
        // option2 = option2.GetComponent<Button>();
        // option3 = option3.GetComponent<Button>();

        btn.onClick.AddListener(testFunction);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            changeMode();
            executeDialog();
        }
    }

    public void changeMode() {
        playerLook.canLook = dialogActive;
        playerMove.canMove = dialogActive;
        playerMesh.enabled = dialogActive;
        changeView.switchView();

        dialogActive = !dialogActive;
    }

    public void executeDialog() {
        dialogParent.SetActive(true);
        foreach (Dialog d in sentences) {
            if (d.type == 0) {
                option1.enabled = false;
                option1.enabled = false;
                option1.enabled = false;

                title.text = d.name;
                message.text = d.sentence;
            } else if (d.type == 1) {
                option1.enabled = true;
                option1.enabled = true;
                option1.enabled = true;

                title.text = d.name;
                if (d.sentence != null) { message.text = d.sentence; }
                option1Text.text = d.option1;
                option2Text.text = d.option2;
                option3Text.text = d.option3;
            }
        }
        // dialogParent.SetActive(false);
    }

    // private void changeDialogDisplay(int mode) {
    //     if (mode == 0) {
    //         option1.SetActive(false);
    //         option2.SetActive(false);
    //         option3.SetActice(false);
    //     } else if (mode == 1) {
    //         option1.SetActive(true);
    //         option2.SetActive(true);
    //         option3.SetActice(true);
    //     }
    // }

    public void testFunction() {
        Debug.Log("You did a thing");
    }

    void LoadDialog() {
        string[] data = dialogData.text.Split(new char[] { '\n' });
        
        for (int i = 1; i < data.Length; i++) {
            string[] row = data[i].Split(new char[] { ';' });
            Dialog d = new Dialog();

            int sentenceType;
            int.TryParse(row[2], out sentenceType);

            if ( sentenceType == 0) {
                d.name = row[1];
                d.type = sentenceType;
                d.sentence = row[3];
            } else if ( sentenceType == 2) {
                d.name = row[1];
                d.type = sentenceType;
                d.option1 = row[4];
                d.option2 = row[5];
                d.option3 = row[6];
                d.response1 = row[7];
                d.response2 = row[8];
                d.response3 = row[9];
            } else {
                d.name = row[1];
                d.type = sentenceType;
                d.sentence = row[3];
                d.option1 = row[4];
                d.option2 = row[5];
                d.option3 = row[6];
            }
            sentences.Add(d);
        }
    }
}
