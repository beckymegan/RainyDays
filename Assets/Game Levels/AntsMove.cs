using UnityEngine;
using System.Collections;

public class AntsMove : MonoBehaviour {

	public Transform target;
	public AudioClip destroyedSound, livesSound;

	private float speed;
	private bool positionPassed = false;

	void Start () {
		speed = Random.Range (0.05f, 0.5f);
	}

	void Update () {
		float step = speed * Time.deltaTime;

		//angle ant sprite so it appears to be facing the picnic basket at all points
		float angleRad = Mathf.Atan2 (transform.position.y - -10.5f, transform.position.x - -6.5f);
		float angleDeg = (180 / Mathf.PI) * angleRad - 225;
		transform.rotation = Quaternion.Euler(0, 0, angleDeg);

		//ant is on an angled path until it's beneath the picnic backet ("position passed") ant then goes straight forward
		//this is so that the ant doesn't hit the picnic basket area weird (sticking out the side, floating in the sky, etc)
		if (positionPassed == false) {
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-6.5f, -11f, 2f), step);
		} else if ((transform.position.x == -6.5f && transform.position.y == -11f) || positionPassed == true) {
			positionPassed = true;
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-6.5f, -8f, 2f), step);
		}

		//if game is over and game is not paused destroy the ant since the game is over
		if (gVar.playGame == false && gVar.pausedGame == false) {
			Destroy (gameObject);
		}
	}

	//when the ant collides with the picnic basket (ANT_TARGET tag) play the destroyed sound, drop lives and destroy ant object
	void OnTriggerEnter2D(Collider2D collisionInfo) {
		if (collisionInfo.GetComponent<Collider2D>().tag == "ANT_TARGET") {
			AudioSource.PlayClipAtPoint(livesSound, transform.position, gVar.effectVolume);
			Destroy (gameObject);
			gVar.lives--;
		}
	}

	//if the player taps the ant and the game is not paused, play sound, increase score and destroy ant object
	void OnMouseDown(){
		if (gVar.pausedGame == false) {
			if(gVar.effectsPaused == true){
				AudioSource.PlayClipAtPoint(destroyedSound, transform.position, gVar.effectVolume);
			}
			gVar.score++;
			Destroy (gameObject);
		}
	}
}

