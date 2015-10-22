using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	public Button button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12;
	public Image medal1, medal2, medal3, medal4, medal5, medal6, medal7, medal8, medal9, medal10, medal11, medal12;
	public Sprite gold, silver, bronze, empty;
	public int numLevels;

	private Button[] buttonArray = new Button[12];
	private Image[] medalArray = new Image[12];

	void Start(){
		//load all levels with correct button (locked/unlocked) and medals(none, bronze, silver, gold) that are stored between games (one app session)
		buttonArray [0] = button1; medalArray [0] = medal1;
		buttonArray [1] = button2; medalArray [1] = medal2;
		buttonArray [2] = button3; medalArray [2] = medal3; 
		buttonArray [3] = button4; medalArray [3] = medal4;
		buttonArray [4] = button5; medalArray [4] = medal5;
		buttonArray [5] = button6; medalArray [5] = medal6;
		buttonArray [6] = button7; medalArray [6] = medal7;
		buttonArray [7] = button8; medalArray [7] = medal8;
		buttonArray [8] = button9; medalArray [8] = medal9;
		buttonArray [9] = button10; medalArray [9] = medal10;
		buttonArray [10] = button11; medalArray [10] = medal11;
		buttonArray [11] = button12; medalArray [11] = medal12;

		for (int i = 0; i < numLevels; i++) {
			//load unlocked levels stored between app sessions
			if (PlayerPrefs.GetInt("unlockedLevel") >= i+1) {
				buttonArray[i].interactable = true;
			} else {
				buttonArray[i].interactable = false;
			}

			//load medals stored between app sessions
			int[] goldLevels = PlayerPrefsX.GetIntArray("goldLevels");

			if (goldLevels[i] == 1){
				medalArray[i].sprite = bronze;
			} else if (goldLevels[i] == 2){
				medalArray[i].sprite = silver;
			} else if (goldLevels[i] == 3){
				medalArray[i].sprite = gold;
			} else{
				medalArray[i].sprite = empty;
			}

		}

	}

	//if level is unlocked then load level with variables (levelGlobal.cs) stored for that level
	public void switchLevels(int level){
		if (PlayerPrefs.GetInt("unlockedLevel") >= level) {
			gameObject.GetComponent<levelGlobal>().levelSelect (level);
			Application.LoadLevel ("Level");
		}
	}

}
