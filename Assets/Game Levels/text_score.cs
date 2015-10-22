using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class text_score : MonoBehaviour {

	public GameObject scoreObject, goalScoreObject, goldTimeObject, timerObject, currentLevelObject;
	private Text score, goalScore, goldTime, timer, currentLevel;
	
	void Start () {
		score = scoreObject.GetComponent<Text> ();
		goalScore = goalScoreObject.GetComponent<Text> ();
		goldTime = goldTimeObject.GetComponent<Text> ();
		timer = timerObject.GetComponent<Text> ();
		currentLevel = currentLevelObject.GetComponent<Text> ();
	}

	void Update(){

		//Timer Stuff
		if (gVar.playGame == true) {
			if (Time.timeSinceLevelLoad < 10) {
				timer.text = "Time: 00" + (int)Time.timeSinceLevelLoad + " sec";
			} else if (Time.timeSinceLevelLoad < 100) {
				timer.text = "Time: 0" + (int)Time.timeSinceLevelLoad + " sec";
			} else if (Time.timeSinceLevelLoad < 1000) {
				timer.text = "Time: " + (int)Time.timeSinceLevelLoad + " sec";
			} else {
				timer.text = "Time: >999 sec|";
			}
		}

		//Score stuff
		if (gVar.score <= -1000 && gVar.score < 0) {
			score.color = Color.red;
			score.text = "SCORE:<999";
		} else if (gVar.score <= -100 && gVar.score < 0) {
			score.color = Color.red;
			score.text = "SCORE: " + (gVar.score*-1).ToString ();
		} else if (gVar.score <= -10 && gVar.score < 0) {
			score.color = Color.red;
			score.text = "SCORE: 0" + (gVar.score*-1).ToString ();
		} else if (gVar.score < 0) {
			score.color = Color.red;
			score.text = "SCORE: 00" + (gVar.score*-1).ToString ();
		} else if (gVar.score < 10) {
			score.color = Color.white;
			score.text = "SCORE: 00" + gVar.score.ToString ();
		} else if (gVar.score < 100) {
			score.color = Color.white;
			score.text = "SCORE: 0" + gVar.score.ToString ();
		} else if (gVar.score < 1000) {
			score.color = Color.white;
			score.text = "SCORE: " + gVar.score.ToString ();
		}

		//Current level stuff
		if (gVar.level < 10) {
			currentLevel.text = "Level: 0" + gVar.level;
		} else {
			currentLevel.text = "Level: " + gVar.level;
		}

		//Goal stuff
		goalScore.text = "Goal Score: " + gVar.winScore + " pts";
		goldTime.text = "Goal Time: " + gVar.goldTime + " sec";

	}
}
