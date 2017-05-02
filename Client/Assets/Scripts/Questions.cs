using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Questions : MonoBehaviour {

    public string value;
    public string[] answers = new string[4];

    public Questions(string value, string[] answers)
    {
        this.value = value; //This is question.
        for (int ii = 0; ii < answers.Length; ii++)
            this.answers[ii] = answers[ii];
    }
}
