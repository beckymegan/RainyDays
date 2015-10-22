using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {

	private float speed = -0.005f;
	private Renderer rent;

	// Use this for initialization
	void Start () {
		rent = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2(Time.time*speed, 0);
		rent.material.mainTextureOffset = offset;
	}
}
