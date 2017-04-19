using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {
	public void PingPongScale(GameObject obj)
    {
        LeanTween.scale(obj, new Vector3(1.12f, 1.12f, 1.12f), 1f).setLoopPingPong().setEaseInOutSine();
    }
}
