using UnityEngine;
using System.Collections;

public class DEBUG : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("backspace")){ 
			PlayerPrefs.DeleteAll();
		}
		if (Input.GetKeyDown ("space")) {
			gVar.numGameOvers = 3;
		}
		if (Input.GetKeyDown ("k")) {
			Application.CaptureScreenshot("Screenshot.png");
			print ("Screenshot");
		}



	}
}
