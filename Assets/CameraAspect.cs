using UnityEngine;
using System.Collections;

public class CameraAspect : MonoBehaviour {

	private double aspect;

	public GameObject barrierL, barrierR;

	// Use this for initialization
	void Start () {
		gVar.gameStart = false;
		aspect = System.Math.Round (System.Math.Round (Camera.main.aspect, 2) - 0.1, 1);
		//Assume starting position of barrierLR is 4.1
		if (aspect == 0.5) {
			barrierL.transform.Translate (-0.5f, 0, 0);
			barrierR.transform.Translate (0.5f, 0, 0);
		} else if (aspect == 0.6) {
			barrierL.transform.Translate (-0.6f, 0, 0);
			barrierR.transform.Translate (0.6f, 0, 0);
		} else if (aspect == 0.7) {
			barrierL.transform.Translate (-0.3f, 0, 0);
			barrierR.transform.Translate (0.3f, 0, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
