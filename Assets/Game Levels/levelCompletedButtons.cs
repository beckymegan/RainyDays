using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class levelCompletedButtons : MonoBehaviour {

	public GameObject Spawner, canvasObject, livesObject, timeObject, goldTimeObject, faderObject;

	private Text lives, time, goldTime;
	private CanvasGroup levelCompleted;
	private spawner spawn;
	private SpriteRenderer fader;
	private bool printScore = true;
	private int timeInt;
	private static bool fadeIn;
	private static int fading;

	void Start(){
		spawn = Spawner.GetComponent<spawner> ();
		levelCompleted = canvasObject.GetComponent<CanvasGroup> ();
		lives = livesObject.GetComponent<Text> ();
		time = timeObject.GetComponent<Text> ();
		goldTime = goldTimeObject.GetComponent<Text> ();
		levelCompleted.transform.Translate(new Vector2(-20, 0));
		fadeIn = false;
		fading = 1;
	}

	public void buttonSelected (int b) {

		StartCoroutine (Fade (b));

		levelCompleted.interactable = false;
		levelCompleted.alpha = 0;
	
	}

	void Update(){
		if (gVar.playGame == false && gVar.lives != 0) {
			if (printScore == true){
				lives.text = "Lives: " + (gVar.lives).ToString ();
				time.text = "Time: " + ((int)Time.timeSinceLevelLoad).ToString () + " sec";
				goldTime.text = "Gold Time: " + (gVar.goldTime).ToString () + " sec";
				printScore = false;
				levelCompleted.transform.Translate(new Vector2(14.3f, 0));
			}
		}
	}

	IEnumerator Fade(int b) {
		fader = faderObject.GetComponent<SpriteRenderer> ();
		Color c;
		Time.timeScale = 0;
		float f;

		if (b == 0) {
			fadeIn = true;
		} else if (b > 0) {
			fadeIn = false;
		}

		if (fadeIn == true) {
			if (fading == 0) {
				for (f = 1f; f >= 0; f -= 0.07f) {//fade out
					c = fader.color;
					c.a = f;
					fader.color = c;
					yield return null;
				}
				fading = 1;
			} else if (fading == 1) {
				for (f = 0f; f <= 1; f += 0.07f) {//fade in
					c = fader.color;
					c.a = f;
					fader.color = c;
					yield return null;
				}
				fading = 0;
			}
		}

		Time.timeScale = 1;

		if (b == 0) {// 0=Next Level || 1=Reset Level || 2=Main Menu
			fadeIn = true;
			gameObject.GetComponent<levelGlobal> ().levelSelect ((gVar.level + 1));
			Application.LoadLevel ("Level");
		} else if (b == 1) {
			fadeIn = false;
			spawn.Restart ();
		} else if (b == 2) {
			fadeIn = false;
			Application.LoadLevel ("Level Select");
		}
	}

	void OnLevelWasLoaded(){
		if (fadeIn == true) {
			StartCoroutine (Fade (-1));
		}
	}
}
