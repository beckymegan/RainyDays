using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {
	
	private GameObject[] cloudClones;
	private GameObject[] antClones;
	private bool levelLost;
	
	public GameObject spawnerObject, canvasObject, gameOverObject, skyObject, groundObject;
	public Image medal, heart1, heart2, heart3, heart4, heart5;
	public Sprite gold, silver, bronze, heartRed, heartGrey;
	public Sprite sky1, sky2, sky3;
	public Sprite ground1, ground2, ground3, ground4, ground5;

	private CanvasGroup levelCompleted, gameOver;
	private int randomNumber;
	private spawner spawnScript;
	
	void Start(){
		levelLost = false;
		Time.timeScale = 1;

		levelCompleted = canvasObject.GetComponent<CanvasGroup> ();
		gameOver = gameOverObject.GetComponent<CanvasGroup> ();
		spawnScript = spawnerObject.GetComponent<spawner>();
		
		levelCompleted.interactable = false;

		randomNumber = Random.Range (1, 4);

		if (randomNumber == 1) {
			skyObject.GetComponent<SpriteRenderer> ().sprite = sky1;
		} else if (randomNumber == 2) {
			skyObject.GetComponent<SpriteRenderer> ().sprite = sky2;
		} else if (randomNumber == 3) {
			skyObject.GetComponent<SpriteRenderer> ().sprite = sky3;
		}

		randomNumber = Random.Range (1, 6);

		if (randomNumber == 1) {
			groundObject.GetComponent<SpriteRenderer> ().sprite = ground1;
		} else if (randomNumber == 2) {
			groundObject.GetComponent<SpriteRenderer> ().sprite = ground2;
		} else if (randomNumber == 3) {
			groundObject.GetComponent<SpriteRenderer> ().sprite = ground3;
		} else if (randomNumber == 4) {
			groundObject.GetComponent<SpriteRenderer> ().sprite = ground4;
		} else if (randomNumber == 5) {
			groundObject.GetComponent<SpriteRenderer> ().sprite = ground5;
		}

	}
	
	// Update is called once per frame
	void Update () {

		//DURING GAME
		if (gVar.score < gVar.winScore) {
			if (gVar.lives == 5) {
				heart5.sprite = heartRed; heart4.sprite = heartRed; heart3.sprite = heartRed; heart2.sprite = heartRed; heart1.sprite = heartRed;
			}
			if (gVar.lives <= 4) {
				heart5.sprite = heartGrey; heart4.sprite = heartRed; heart3.sprite = heartRed; heart2.sprite = heartRed; heart1.sprite = heartRed;
			}
			if (gVar.lives <= 3) {
				heart5.sprite = heartGrey; heart4.sprite = heartGrey; heart3.sprite = heartRed; heart2.sprite = heartRed; heart1.sprite = heartRed;
			}
			if (gVar.lives <= 2) {
				heart5.sprite = heartGrey; heart4.sprite = heartGrey; heart3.sprite = heartGrey; heart2.sprite = heartRed; heart1.sprite = heartRed;
			}
			if (gVar.lives <= 1) {
				heart5.sprite = heartGrey; heart4.sprite = heartGrey; heart3.sprite = heartGrey; heart2.sprite = heartGrey; heart1.sprite = heartRed;
			}
			if(gVar.lives <= 0){
				heart5.sprite = heartGrey; heart4.sprite = heartGrey; heart3.sprite = heartGrey; heart2.sprite = heartGrey; heart1.sprite = heartGrey;
				gameOver.interactable = true;
				gameOver.alpha = 1;
				Time.timeScale = 0;
				if(levelLost == false){
					gVar.numGameOvers += 1;
				}
				levelLost = true;
			}
		}

		//END GAME
		else if (gVar.score >= gVar.winScore && gVar.playGame == true) {

			gVar.timer = (int)Mathf.Round(Time.timeSinceLevelLoad);
			
			cloudClones = GameObject.FindGameObjectsWithTag ("CLOUD_L");
			for(var i = 0 ; i < cloudClones.Length ; i++)
			{
				Destroy(cloudClones[i]);
			}
			
			cloudClones = GameObject.FindGameObjectsWithTag ("CLOUD_R");
			for(var i = 0 ; i < cloudClones.Length ; i++)
			{
				Destroy(cloudClones[i]);
			}
			
			antClones = GameObject.FindGameObjectsWithTag ("ANTS");
			for(var i = 0 ; i < antClones.Length ; i++)
			{
				Destroy(antClones[i]);
			}
			
			spawnScript.stopSpawning();
			
			if(PlayerPrefs.GetInt("unlockedLevel") <= gVar.level){
				PlayerPrefs.SetInt("unlockedLevel", gVar.level+1);
			}
			
			if(gVar.playGame == true){
				levelCompleted.interactable = true;
				levelCompleted.alpha = 1;
			}

			int[] goldLevels = PlayerPrefsX.GetIntArray("goldLevels");

			if (gVar.lives == 5){//GOLD OR SILVER MEDAL
				if(gVar.timer > gVar.goldTime) {//SILVER MEDAL
					if(goldLevels[gVar.level-1] <= 2){
						goldLevels[gVar.level-1] = 2;
					}
					medal.sprite = silver;
				} else {
					if(goldLevels[gVar.level-1] <=3){
						goldLevels[gVar.level-1] = 3;
					}
					medal.sprite = gold;
				}
			} else {//BRONZE MEDAL
				if(goldLevels[gVar.level-1] <= 1){
					goldLevels[gVar.level-1] = 1;
				}
				medal.sprite = bronze;
			}

			PlayerPrefsX.SetIntArray("goldLevels", goldLevels);
			PlayerPrefs.Save ();

			gVar.playGame = false;
		}
	}
}
