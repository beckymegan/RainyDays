using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameOverButton : MonoBehaviour {

	public GameObject Spawner, canvasObject, timeObject, goldTimeObject;

	private Text time, goldTime;
	private CanvasGroup gameOver;
	private bool printScore = true;
	private spawner spawn;
	private int button;// 0=Next Level || 1=Reset Level || 2=Main Menu
	
	void Start(){
		spawn = Spawner.GetComponent<spawner> ();
		gameOver = canvasObject.GetComponent<CanvasGroup> ();
		time = timeObject.GetComponent<Text> ();
		goldTime = goldTimeObject.GetComponent<Text> ();
		gameOver.transform.Translate(new Vector2(-20, 0));
	}
	
	public void buttonSelected (int b) {
		
		button = b;

		if (button == 1) {
			Time.timeScale = 1;
			gVar.levelLost = false;
			spawn.Restart ();
		} else if (button == 2) {
			Application.LoadLevel ("Level Select");
		}
		
		gameOver.interactable = false;
		gameOver.alpha = 0;
		
	}
	
	void Update(){
		if (gVar.playGame == false & gVar.lives == 0) {
			if (printScore == true){
				gameOver.transform.Translate(new Vector2(14.3f, 0));
				time.text = "Time: " + ((int)Time.timeSinceLevelLoad).ToString () + " sec";
				goldTime.text = "Gold Time: " + (gVar.goldTime).ToString () + " sec";
				printScore = false;
			}
		}
	}
}
