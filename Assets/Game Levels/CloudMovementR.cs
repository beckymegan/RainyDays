using UnityEngine;
using System.Collections;

public class CloudMovementR : MonoBehaviour {
	
	private float speed;
	private int counter = 0;
	private bool cloud_collision = false;
	private GameObject collided_object;
	private int cloudSprite;
	
	public Sprite cloudSprite1, cloudSprite2, cloudSprite3;
	public AudioClip destroyedSound;
	
	// Use this for initialization
	void Start () {
		speed = Random.Range (gVar.minCloud, gVar.maxCloud);
		cloudSprite = Random.Range (1,4);

		if(cloudSprite==1){
			GetComponent<SpriteRenderer>().sprite = cloudSprite1;
		}
		else if(cloudSprite==2){
			GetComponent<SpriteRenderer>().sprite = cloudSprite2;
		}
		else if(cloudSprite==3){
			GetComponent<SpriteRenderer>().sprite = cloudSprite3;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
		if (gVar.playGame == false) {
			Destroy (gameObject);
		}
		if (counter > gVar.loseScore && gVar.pausedGame == false) {
			gVar.score--;
			counter = 0;
		}
		if (gVar.pausedGame == true) {
			counter--;
		}
		counter++;
	}
	
	void OnTriggerEnter2D(Collider2D collisionInfo)
	{
		if (collisionInfo.GetComponent<Collider2D>().tag == "CLOUD_L") {
			cloud_collision = true;
			collided_object = collisionInfo.gameObject;
		}
	}
	
	void OnTriggerExit2D(Collider2D collisionInfo){
		if (collisionInfo.GetComponent<Collider2D>().tag == "CLOUD_L") {
			cloud_collision = false;
		}
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
	
	void OnMouseDown(){
		if (gVar.pausedGame == false) {
			if(gVar.effectsPaused == true){
				AudioSource.PlayClipAtPoint(destroyedSound, transform.position, gVar.effectVolume);
			}
			gVar.score++;
			Destroy (gameObject);
			if (cloud_collision) {
				Destroy (collided_object);
			}
		}
	}
	
}
