using System.Collections;
using UnityEngine;

[System.Serializable]
public class ArrayLayout {
    [System.Serializable]
    public struct rowData {
        public string[] row;
    }
    
    public rowData[] rows;
}
