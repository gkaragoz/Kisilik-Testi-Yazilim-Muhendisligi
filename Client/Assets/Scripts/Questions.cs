using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour {

    private JSONObject data;

    void Start()
    {
        string dataPath = (Resources.Load<TextAsset>("Data") as TextAsset).text;

        data = new JSONObject(dataPath);
        Debug.Log(data);
    }
}
