using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class ADVERTISEMENT : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Advertisement.Initialize ("56423");
	}
	
	// Update is called once per frame
	void Update () {
		if(gVar.numGameOvers >= 2){
			if(Advertisement.IsReady()){
				Advertisement.Show();
				gVar.levelLost = true;
				gVar.numGameOvers = 0;
			}
		}
	}
}
