using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionManager : MonoBehaviour {

    private JSONObject data;

    public List<Question> Questions = new List<Question>();
    public Informations Info = new Informations();

    [System.Serializable]
    public class Question
    {
        public string value;
        public string[] answers = new string[4];

        public Question(string value, string [] answers)
        {
            this.value = value; //This is question.
            for (int ii = 0; ii < answers.Length; ii++)
                this.answers[ii] = answers[ii];
        }
    }

    [System.Serializable]
    public class Informations
    {
        public List<string> Yellow = new List<string>();
        public List<string> Blue = new List<string>();
        public List<string> Red = new List<string>();
        public List<string> Green = new List<string>();
    }

    void Start()
    {
        string dataPath = (Resources.Load<TextAsset>("Data") as TextAsset).text;

        data = new JSONObject(dataPath);

        FillQuestionsList(data);
        FillInformations(data);

        //Debug.Log(data.GetField("Questions")[0].GetField("Answers")[0].ToString());

        //Debug.Log(data.GetField("Questions")[0].GetField("Question"));
    }

    public void FillQuestionsList(JSONObject data)
    {
        int answerCount = 4;

        string [] answers = new string[answerCount];
        for (int ii = 0; ii < data.GetField("Questions").list.Count; ii++)
        {
            for (int jj = 0; jj < answerCount + 1; jj++) //Answers keys.
            {
                if (jj < answerCount)
                {
                    answers[jj] = data.GetField("Questions")[ii].GetField("Answers")[jj].ToString();
                    continue;
                }
                Question q = new Question(data.GetField("Questions")[ii].GetField("Question").ToString(), answers);
                Questions.Add(q);
            }
        }
    }

    public void FillInformations(JSONObject data)
    {
        Debug.Log(data.GetField("Informations").ToString());
    }
}
