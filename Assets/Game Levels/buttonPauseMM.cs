using UnityEngine;
using System.Collections;

public class buttonPauseMM : MonoBehaviour {
	
	public GameObject optionsObject, clearDataObject;

	private CanvasGroup cg, cd;
	
	void Start(){
		cg = optionsObject.GetComponent<CanvasGroup> ();
		cd = clearDataObject.GetComponent<CanvasGroup> ();
		cd.transform.Translate (new Vector2 (-20, 0));
	}

	public void clear_data(){
		if (gVar.clearData == false) {
			gVar.clearData = true;
			cd.interactable = true;
			cd.transform.Translate (new Vector2 (14.3f, 0));
			cg.transform.Translate (new Vector2 (-14.3f, 0));
			cg.interactable = false;
		} else {
			gVar.clearData = false;
			cd.interactable = false;
			cd.transform.Translate (new Vector2 (-14.3f, 0));
			cg.interactable = true;
		}
	}
		
	public void buttonYesNo(bool yes){
		if (yes) {
			PlayerPrefs.DeleteAll();
			gVar.clearData = false;
			Application.LoadLevel("Main Menu");
		} else {
			cd.transform.Translate (new Vector2 (-14.3f, 0));
			cg.interactable = true;
			gVar.clearData = false;
			gVar.pausedGame = false;
		}
	}

}
