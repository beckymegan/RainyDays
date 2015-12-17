using UnityEngine;
using System.Collections;

public class MusicGenerator : MonoBehaviour {

	public GameObject musicPlayer;

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectWithTag("MUSIC CONTROLLER") == null){
			Instantiate (musicPlayer, Vector3.zero, Quaternion.identity);
		}
    }
}
