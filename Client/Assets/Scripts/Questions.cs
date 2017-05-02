using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Questions : MonoBehaviour {

    private JSONObject data;

    void Start()
    {
        string dataPath = (Resources.Load<TextAsset>("Data") as TextAsset).text;

        data = new JSONObject(dataPath);
        Debug.Log(data.GetField("Questions")[0].GetField("Question"));
    }
}
