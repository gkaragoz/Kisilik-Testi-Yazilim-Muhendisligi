using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour {

    private JSONObject data;

    public List<Questions> Questions = new List<Questions>();
    public Informations Info = new Informations();
    public Advices Advice = new Advices();
    
    void Start()
    {
        string dataPath = (Resources.Load<TextAsset>("Data") as TextAsset).text;
        data = new JSONObject(dataPath);

        FillQuestionsList(data);
        FillInformations(data);
        FillAdvices(data);
    }

    #region FillStuff
    public void FillQuestionsList(JSONObject data)
    {
        int answerCount = 4;

        string [] answers = new string[answerCount];
        for (int ii = 0; ii < data.GetField("Questions").Count; ii++)
        {
            for (int jj = 0; jj < answerCount + 1; jj++) //Answers keys.
            {
                if (jj < answerCount)
                {
                    answers[jj] = data.GetField("Questions")[ii].GetField("Answers")[jj].ToString();
                    continue;
                }
                Questions q = new Questions(data.GetField("Questions")[ii].GetField("Question").ToString(), answers);
                Questions.Add(q);
            }
        }
    }

    public void FillInformations(JSONObject data)
    {
        for (int ii = 0; ii < data.GetField("Informations").GetField("Yellow").Count; ii++)
            Info.Yellow.Add(data.GetField("Informations").GetField("Yellow")[ii].ToString());

        for (int ii = 0; ii < data.GetField("Informations").GetField("Blue").Count; ii++)
            Info.Blue.Add(data.GetField("Informations").GetField("Blue")[ii].ToString());

        for (int ii = 0; ii < data.GetField("Informations").GetField("Red").Count; ii++)
            Info.Red.Add(data.GetField("Informations").GetField("Red")[ii].ToString());

        for (int ii = 0; ii < data.GetField("Informations").GetField("Green").Count; ii++)
            Info.Green.Add(data.GetField("Informations").GetField("Green")[ii].ToString());
    }

    public void FillAdvices(JSONObject data)
    {
        for (int ii = 0; ii < data.GetField("Advices").GetField("Yellow").Count; ii++)
            Advice.Yellow.Add(data.GetField("Advices").GetField("Yellow")[ii].ToString());

        for (int ii = 0; ii < data.GetField("Advices").GetField("Blue").Count; ii++)
            Advice.Blue.Add(data.GetField("Advices").GetField("Blue")[ii].ToString());

        for (int ii = 0; ii < data.GetField("Advices").GetField("Red").Count; ii++)
            Advice.Red.Add(data.GetField("Advices").GetField("Red")[ii].ToString());

        for (int ii = 0; ii < data.GetField("Advices").GetField("Green").Count; ii++)
            Advice.Green.Add(data.GetField("Advices").GetField("Green")[ii].ToString());
    }
    #endregion
}
