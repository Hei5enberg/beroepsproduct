using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SentencesData {
    [System.Serializable]
    public struct sentenceData {
        public string[] collection;
    }
    public sentenceData[] sentence = new sentenceData[5];
}

public class Dialog : MonoBehaviour
{
    // public string characterName;
    // public string[][] sentences;
    // public List<Sentences> sentences = new List<Sentences>();
    // public ArrayList sentences = new ArrayList();

    public string[][] test = new string[5][];

    // [System.Serializable]
    // public class serializableClass
    // {
    //     public List<string> sentencesCollection;
    // }
    // public List<serializableClass> sentence = new List<serializableClass>();

    [SerializeField] int currentSentence;

    public void addSentence() {
        // string[] newSentence = new string[]{"noOpt", "Character name", "Actual sentence"};
        // sentences[currentSentence] = newSentence;

        // sentences.Add(new Sentences("noOpt", "Character name", "Actual sentence"));
        // var newSentence = newArrayList();
        // newSentence.Add(true);
        // newSentence.Add("billy");
        // newSentence.Add("badabingbadabong");
        test[0] = new string[] {"hoi", "doei"};

        // currentSentence++;
        Debug.Log(test[0][0]);
        Debug.Log("Added normal sentence");
        
    }

    public void addSentenceWithOptions() {
        Debug.Log("Boob");
        // if (currentSentence != sentences.Length) {
        //     string[] newSentence = new string[]{"Opt", "Character name", "Option 1", "Option 2", 
        //     "Option 3", "Response 1", "Response 2", "Response 3"};
        //     sentences[currentSentence] = newSentence;

        //     currentSentence++;
        //     Debug.Log("Added options sentence");
        // } else {
        //     Debug.Log("On max sentence count");
        // }
    }


}
