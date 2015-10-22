using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {

	//Don't destory object when scenes are swapped so music isn't restarted
	void Awake() {
		DontDestroyOnLoad(gameObject);
	}
}
