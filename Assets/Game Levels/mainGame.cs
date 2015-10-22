using UnityEngine;
using System.Collections;

public class mainGame : MonoBehaviour {

	int counter = 1;

	void Start(){
		gVar.pausedGame = false;
		gVar.playGame = true;
		if (PlayerPrefs.GetInt("gameStarted") == 0) {
			//set players/gVars as 0
			PlayerPrefs.SetInt("unlockedLevel", 1);
			int[] goldLevels = new int[12];
			PlayerPrefsX.SetIntArray("goldLevels", goldLevels);
			PlayerPrefs.SetInt("gameStarted", 1);
		}
	}

	void OnApplicationPause(bool isPaused){
		if (isPaused) {
			Time.timeScale = 0;
			gVar.pausedGame = true;
			counter = 0;
		} else if (isPaused == false && counter == 0) {
			Time.timeScale = 1;
			gVar.pausedGame = false;
			counter = 1;
		}
	}
}
