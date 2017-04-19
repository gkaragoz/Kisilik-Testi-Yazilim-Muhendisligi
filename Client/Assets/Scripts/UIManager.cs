using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private List<GameObject> Panels = new List<GameObject>();

    #region PANELS
        public GameObject PNL_WELCOME;
        public GameObject PNL_GUIDE;
        public GameObject PNL_QUESTIONS;
    #endregion

    void FindPanelsGameObjects()
    {
        PNL_WELCOME   = transform.FindChild("pnlWelcome").gameObject;
        PNL_GUIDE     = transform.FindChild("pnlGuide").gameObject;
        PNL_QUESTIONS = transform.FindChild("pnlQuestions").gameObject;

        Panels.Add(PNL_WELCOME);
        Panels.Add(PNL_GUIDE);
        Panels.Add(PNL_QUESTIONS);
    }

    void OpenScreen(GameObject screen)
    {
        foreach (GameObject item in Panels)
        {
            if (item == screen)
                item.SetActive(true);
            else
                item.SetActive(false);
        }
    }

	void Start () {
        FindPanelsGameObjects(); //Initialize all panel objects references.
        OpenScreen(PNL_WELCOME);
	}
	
	void Update () {
		
	}
}
