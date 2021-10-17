using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    public TextAsset dialogData;
    List<Dialog> sentences = new List<Dialog>();

    ChangeView changeView;
    GameObject player, crosshair, continueText;
    PlayerLook playerLook;
    PlayerMove playerMove;
    MeshRenderer playerMesh;    

    public GameObject dialogParent;
    public Text title;
    public Text message;
    public GameObject option1, option2 , option3;

    Text option1Text;
    Text option2Text;
    Text option3Text; 

    bool dialogActive = false;
    bool option1Clicked;
    bool option2Clicked;
    bool option3Clicked;

    void Start() {
        LoadDialog();

        changeView = GetComponent<ChangeView>();

        crosshair = GameObject.Find("Character/UI/Crosshair");
        continueText = GameObject.Find("Character/UI/Dialog/Continue");

        player = GameObject.Find("Player");
        playerLook = player.GetComponent<PlayerLook>();
        playerMove = player.GetComponent<PlayerMove>();
        playerMesh = player.GetComponent<MeshRenderer>();

        option1Text = option1.GetComponentInChildren<Text>();
        option2Text = option2.GetComponentInChildren<Text>();
        option3Text = option3.GetComponentInChildren<Text>();
        
        Button option1Btn = option1.GetComponent<Button>();
        Button option2Btn = option2.GetComponent<Button>();
        Button option3Btn = option3.GetComponent<Button>();

        option1Btn.onClick.AddListener(delegate {catchPressOfButton(0); } );
        option2Btn.onClick.AddListener(delegate {catchPressOfButton(1); } );
        option3Btn.onClick.AddListener(delegate {catchPressOfButton(2); } );
    }

    public void startDialog() {
        changeMode();
        StartCoroutine(executeDialog());
    }

    public void catchPressOfButton(int buttonNumber) {
        if (buttonNumber == 0) {
            option1Clicked = true;
        } else if (buttonNumber == 1) {
            option2Clicked = true;
        } else if (buttonNumber == 2) { 
            option3Clicked = true; 
        } else if (buttonNumber == 3) {
            // Resetting states
            option1Clicked = false;
            option2Clicked = false;
            option3Clicked = false; 
        }
    }

    public void changeMode() {
        playerLook.canLook = dialogActive;
        playerMove.canMove = dialogActive;
        playerMesh.enabled = dialogActive;
        changeView.switchView();

        dialogActive = !dialogActive;
    }

    public IEnumerator executeDialog() {
        dialogParent.SetActive(true);
        crosshair.SetActive(false);

        foreach (Dialog d in sentences) {
            if (d.type == 0) {
                optionsDisplayState(false);
                continueText.SetActive(true);

                title.text = d.name;
                message.text = d.sentence;
                yield return waitForInput("keyPress");
            } else if (d.type == 1) {
                // Turn on dialog elements and display options
                optionsDisplayState(true);
                continueText.SetActive(false);
                message.text = "";

                title.text = d.name;
                if (d.sentence != null) { message.text = d.sentence; }
                option1Text.text = d.option1;
                option2Text.text = d.option2;
                option3Text.text = d.option3;

                // Wait for response of player
                yield return waitForInput("optionInteract");
                optionsDisplayState(false);
                title.text = d.responderName;
               
                if (option1Clicked) {
                    message.text = d.response1;
                } else if (option2Clicked) {
                    message.text = d.response2;
                } else if (option3Clicked) {
                    message.text = d.response3;
                } else {
                    message.text = "Error";
                }
                yield return waitForInput("keyPress");
                catchPressOfButton(3);
            }
        }
        dialogParent.SetActive(false);
        crosshair.SetActive(true);
        changeMode();
    }

    void optionsDisplayState(bool state) {
        option1.SetActive(state);
        option2.SetActive(state);
        option3.SetActive(state);
    }

    private IEnumerator waitForInput(string condition) {
        bool done = false;
        while(!done) {
            if (condition == "keyPress") {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    done = true;
                }
            } else if (condition == "optionInteract") {
                if (option1Clicked || option2Clicked || option3Clicked) {
                    done = true;
                }
            }
            yield return null;
        }
    }

    // Function to load the dialog csv file into the Dialog.cs class
    void LoadDialog() {
        string[] data = dialogData.text.Split(new char[] { '\n' });
        
        for (int i = 1; i < data.Length; i++) {
            string[] row = data[i].Split(new char[] { ';' });
            Dialog d = new Dialog();

            int sentenceType;
            int.TryParse(row[3], out sentenceType);

            if ( sentenceType == 0 ) {
                d.name = row[1];
                d.type = sentenceType;
                d.sentence = row[4];
            } else if ( sentenceType == 1 ) {
                d.name = row[1];
                d.responderName = row[2];
                d.type = sentenceType;
                d.option1 = row[5];
                d.option2 = row[6];
                d.option3 = row[7];
                d.response1 = row[8];
                d.response2 = row[9];
                d.response3 = row[10];
            } else if ( sentenceType == 2 ) {
                d.name = row[1];
                d.responderName = row[2];
                d.type = sentenceType;
                d.sentence = row[4];
                d.option1 = row[5];
                d.option2 = row[6];
                d.option3 = row[7];
            }
            sentences.Add(d);
        }
    }
}