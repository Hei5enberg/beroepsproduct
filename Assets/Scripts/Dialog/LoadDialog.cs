using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDialog : MonoBehaviour {
    public TextAsset dialogData;
    List<Dialog> sentences = new List<Dialog>();

    void Start() {
        string[] data = dialogData.text.Split(new char[] { '\n' });
        
        for (int i = 1; i < data.Length; i++) {
            string[] row = data[i].Split(new char[] { ';' });
            Dialog d = new Dialog();

            bool hasOptions;
            bool.TryParse(row[2], out hasOptions);

            if (!hasOptions) {
                d.name = row[1];
                d.type = hasOptions;
                d.sentence = row[3];
            } else {
                d.name = row[1];
                d.type = hasOptions;
                d.option1 = row[4];
                d.option2 = row[5];
                d.option3 = row[6];
                d.response1 = row[7];
                d.response2 = row[8];
                d.response3 = row[9];
            }

            sentences.Add(d);
        }

        // foreach (Dialog d in sentences) {
        //     Debug.Log(d.type);
        // }
    }
}
