// using UnityEngine;
// using UnityEditor;

// [CustomEditor(typeof(Dialog))]

// public class DialogEditor : Editor {
//     public override void OnInspectorGUI() {
//         base.OnInspectorGUI();

//         Dialog dialog = (Dialog)target;

//         GUILayout.BeginHorizontal();

//         if (GUILayout.Button("Add sentence")) {
//             dialog.addSentence();
//         }

//         if (GUILayout.Button("Add options sentence")) {
//             dialog.addSentenceWithOptions();
//         }

//         GUILayout.EndHorizontal();
//     }
// }
