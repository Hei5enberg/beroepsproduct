using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    public TextAsset dialogData;
    List<Dialog> sentences = new List<Dialog>();

    public AudioClip[] audioClips;
    public int audioArrayIndex = 0;
    AudioSource audioSource;

    public bool doEyesTurnBlue;
    public GameObject blueEyes;
    Animator animator;

    ChangeView changeView;
    GameObject player, crosshair, continueText, dialogParent, janeTalking,
    titleObject, messageObject, option1, option2, option3;
    PlayerLook playerLook;
    PlayerMove playerMove;
    MeshRenderer playerMesh;    

    Text title;
    Text message;
    Text option1Text;
    Text option2Text;
    Text option3Text; 

    bool dialogActive = false;
    bool option1Clicked;
    bool option2Clicked;
    bool option3Clicked;

    void Start() {
        LoadDialog();

        audioSource = GetComponent<AudioSource>();

        changeView = GetComponent<ChangeView>();

        crosshair = GameObject.Find("Character/UI/Crosshair");
        dialogParent = GameObject.Find("Character/UI/Dialog");
        janeTalking = GameObject.Find("Character/UI/Dialog/JaneTalking");
        titleObject = GameObject.Find("Character/UI/Dialog/Title");
        messageObject = GameObject.Find("Character/UI/Dialog/Text");
        option1 = GameObject.Find("Character/UI/Dialog/Option 1");
        option2 = GameObject.Find("Character/UI/Dialog/Option 2");
        option3 = GameObject.Find("Character/UI/Dialog/Option 3");

        continueText = GameObject.Find("Character/UI/Dialog/Continue");
        
        player = GameObject.Find("Player");
        playerLook = player.GetComponent<PlayerLook>();
        playerMove = player.GetComponent<PlayerMove>();
        playerMesh = player.GetComponent<MeshRenderer>();
        title = titleObject.GetComponent<Text>();
        message = messageObject.GetComponent<Text>();

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
            Debug.Log("id: " + d.id);
            if (d.type == 0) {
                optionsDisplayState(false);
                continueText.SetActive(true);

                if (d.id == 1) {
                    dialogParent.SetActive(false);
                    blueEyes.SetActive(true);
                    yield return new WaitForSeconds(2);
                    dialogParent.SetActive(true);
                    blueEyes.SetActive(false);
                }
                
                if ((d.name).ToLower() == "jane") {
                    janeTalking.SetActive(true);
                }

                audioSource.PlayOneShot(audioClips[audioArrayIndex]);
                audioArrayIndex++;

                title.text = d.name;
                message.text = d.sentence;
                yield return waitForInput("keyPress");
            } else if (d.type == 1) {
                // Turn on dialog elements and display options
                optionsDisplayState(true);
                continueText.SetActive(false);
                message.text = "";

                if ((d.name).ToLower() == "jane") {
                    janeTalking.SetActive(true);
                }

                if (d.id == 1) {
                    dialogParent.SetActive(true);
                    title.text = "";
                    message.text = "";
                    blueEyes.SetActive(true);
                    yield return new WaitForSeconds(2);
                    blueEyes.SetActive(false);
                    dialogParent.SetActive(false);
                }

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
                    audioSource.PlayOneShot(audioClips[audioArrayIndex]);
                    yield return new WaitForSeconds(audioClips[audioArrayIndex].length);
                    audioArrayIndex = audioArrayIndex + 3;
                    
                    message.text = d.response1;
                    continueText.SetActive(true);
                    audioSource.PlayOneShot(audioClips[audioArrayIndex]);
                    audioArrayIndex = audioArrayIndex + 3;
                } else if (option2Clicked) {
                    audioSource.PlayOneShot(audioClips[audioArrayIndex + 1]);
                    yield return new WaitForSeconds(audioClips[audioArrayIndex].length);
                    audioArrayIndex = audioArrayIndex + 3;

                    message.text = d.response2;
                    continueText.SetActive(true);
                    audioSource.PlayOneShot(audioClips[audioArrayIndex + 1]);
                    audioArrayIndex = audioArrayIndex + 3;
                } else if (option3Clicked) {
                    audioSource.PlayOneShot(audioClips[audioArrayIndex + 2]);
                    yield return new WaitForSeconds(audioClips[audioArrayIndex].length);
                    audioArrayIndex = audioArrayIndex + 3;

                    message.text = d.response3;
                    continueText.SetActive(true);
                    audioSource.PlayOneShot(audioClips[audioArrayIndex + 2]);
                    audioArrayIndex = audioArrayIndex + 3;
                } else {
                    message.text = "Error";
                }
                yield return waitForInput("keyPress");
                catchPressOfButton(3);
            }
            janeTalking.SetActive(false);
        }
        audioArrayIndex = 0;
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

        Debug.Log("File length: " + data.Length);
        
        for (int i = 1; i < data.Length; i++) {
            string[] row = data[i].Split(new char[] { ';' });
            Dialog d = new Dialog();

            int sentenceType;
            int.TryParse(row[3], out sentenceType);

            int ID;
            int.TryParse(row[0], out ID);
            d.id = ID;
            d.name = row[1];

            if ( sentenceType == 0 ) {
                d.type = sentenceType;
                d.sentence = row[4];
            } else if ( sentenceType == 1 ) {
                d.type = sentenceType;
                d.responderName = row[2];
                d.option1 = row[5];
                d.option2 = row[6];
                d.option3 = row[7];
                d.response1 = row[8];
                d.response2 = row[9];
                d.response3 = row[10];
            } else if ( sentenceType == 2 ) {
                d.type = sentenceType;
                d.responderName = row[2];
                d.sentence = row[4];
                d.option1 = row[5];
                d.option2 = row[6];
                d.option3 = row[7];
            }
            sentences.Add(d);
        }
    }

    // IEnumerator turnEyesOff() {
    //     yield return new WaitForSeconds(3);
    //     blueEyes.SetActive(false);
    // }
}

