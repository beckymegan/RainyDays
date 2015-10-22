using UnityEngine;
using System.Collections;

public class button_pause : MonoBehaviour {
	
	public GameObject optionsContainer;
	private CanvasGroup cg;

	void Start(){
		cg = optionsContainer.GetComponent<CanvasGroup> ();
		cg.transform.Translate(new Vector2(-20, 0));
	}

	public void pause_pressed(){
		if (gVar.pausedGame == false && gVar.playGame == true) {
			Time.timeScale = 0;
			gVar.pausedGame = true;
			cg.interactable = true;
			cg.transform.Translate(new Vector2(14.3f, 0));
			cg.alpha = 1;
		}
		else if (gVar.pausedGame == true && gVar.playGame == true) {
			Time.timeScale = 1;
			gVar.pausedGame = false;
			cg.interactable = false;
			cg.transform.Translate(new Vector2(-14.3f, 0));
			cg.alpha = 0;
		}
	}

	public void button_mainmenu(){
		Application.LoadLevel ("Level Select");
	}

}
