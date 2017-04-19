using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Animations animations;
    private List<GameObject> Panels = new List<GameObject>();

    #region PANELS
    public GameObject PNL_WELCOME;
    public GameObject PNL_GUIDE;
    public GameObject PNL_QUESTIONS;

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
    #endregion

    #region BUTTONS
    private Button btnStart;
    private Button btnIUnderstand;

    void FindButtonsGameObjects()
    {
        btnStart        = PNL_WELCOME.transform.FindChild("btnStart").GetComponent<Button>();
        btnIUnderstand  = PNL_GUIDE.transform.FindChild("btnIUnderstand").GetComponent<Button>();

        GiveButtonsTasks();
    }

    void GiveButtonsTasks ()
    {
        btnStart.onClick.AddListener(delegate { OpenScreen(PNL_GUIDE); });
        btnIUnderstand.onClick.AddListener(delegate { OpenScreen(PNL_QUESTIONS); });
    }
    #endregion

    void Start () {
        FindPanelsGameObjects(); //Initialize all panel objects references.
        FindButtonsGameObjects();//Initialize all button objects references.

        animations = transform.GetComponent<Animations>();
        animations.PingPongScale(btnStart.gameObject);
        animations.PingPongScale(btnIUnderstand.gameObject);
        OpenScreen(PNL_WELCOME); //Start the application with Welcome Screen.
	}
}
