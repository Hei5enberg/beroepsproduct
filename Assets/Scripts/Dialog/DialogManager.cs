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
    public GameObject option1, option2 , option3;
    // public Button option2;
    // public Button option3;

    Text option1Text;
    Text option2Text;
    Text option3Text;

    // Button option1Btn;

    Test test;

    bool dialogActive = false;
    bool option1Clicked;
    bool option2Clicked;
    bool option3Clicked;

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
        
        // Button btn = option1.GetComponent<Button>();
        // option2 = option2.GetComponent<Button>();
        // option3 = option3.GetComponent<Button>();
        Button option1Btn = option1.GetComponent<Button>();
        Button option2Btn = option2.GetComponent<Button>();
        Button option3Btn = option3.GetComponent<Button>();

        // btn.onClick.AddListener(testFunction);
        option1Btn.onClick.AddListener(delegate {catchButtonPress(0); } );
        option2Btn.onClick.AddListener(delegate {catchButtonPress(1); } );
        option3Btn.onClick.AddListener(delegate {catchButtonPress(2); } );
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            changeMode();
            StartCoroutine(executeDialog());
        }

        // Debug.Log("Button states: ");
        // Debug.Log(option1Clicked);
        // Debug.Log(option2Clicked);
        // Debug.Log(option3Clicked);
    }

    public void startDialog() {
        changeMode();
        StartCoroutine(executeDialog());
    }

    public void catchButtonPress(int buttonNumber) {
        if (buttonNumber == 0) {
            option1Clicked = true;
        } else if (buttonNumber == 1) {
            option2Clicked = true;
        } else if (buttonNumber == 2) { 
            option3Clicked = true; 
        } else if (buttonNumber == 3) {
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
        foreach (Dialog d in sentences) {
            if (d.type == 0) {
                optionsState(false);

                title.text = d.name;
                message.text = d.sentence;
                yield return waitForInput(0);
            } else if (d.type == 1) {
                optionsState(true);

                title.text = d.name;
                if (d.sentence != null) { message.text = d.sentence; }
                option1Text.text = d.option1;
                option2Text.text = d.option2;
                option3Text.text = d.option3;

                yield return waitForInput(1);
                optionsState(false);
                if (option1Clicked) {
                    message.text = d.response1;
                } else if (option2Clicked) {
                    message.text = d.response2;
                } else if (option3Clicked) {
                    message.text = d.response3;
                } else {
                    message.text = "Error";
                }
                yield return waitForInput(0);
                catchButtonPress(3);
            }
        }
        dialogParent.SetActive(false);
        changeMode();
    }

    void optionsState(bool state) {
        option1.SetActive(state);
        option2.SetActive(state);
        option3.SetActive(state);
    }

    private IEnumerator waitForInput(int condition) {
        bool done = false;
        while(!done) {
            if (condition == 0) {
                if (Input.GetKeyDown(KeyCode.F)) {
                    done = true;
                }
            } else if (condition == 1) {
                if (option1Clicked || option2Clicked || option3Clicked) {
                    done = true;
                }
            }
            yield return null;
        }
    }

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
            } else if ( sentenceType == 1) {
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
