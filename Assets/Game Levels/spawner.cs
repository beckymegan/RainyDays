using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	private int spawn_location_cloud, spawn_location_cloud_old, spawn_location_ants, counter_cloud, counter_ants;
	private int whileCount = 0;
	private int cloudAlleyCount = 0;

	private float timer_cloud, timer_ants, old_top_cloud, old_top_ants;

	private GameObject[] cloudClones;
	private GameObject[] antClones;

	public GameObject cloudL, cloudR;
	public GameObject ants;

	// Use this for initialization
	IEnumerator Start () {
		counter_cloud = 0;
		counter_ants = 0;
		yield return new WaitForSeconds (0.5f);
		StartCoroutine ("spawnCloud", 5f);
		StartCoroutine ("spawnAnts", 15f);
		old_top_ants = gVar.top_speed_ants;
		old_top_cloud = gVar.top_speed_cloud;
	}

	public void Restart () {
		gVar.top_speed_ants = old_top_ants;
		gVar.top_speed_cloud = old_top_cloud;
		gVar.levelRestart = true;
		gVar.playGame = true;
		counter_cloud = 0;
		counter_ants = 0;
		StartCoroutine ("spawnCloud", 1f);
		StartCoroutine ("spawnAnts", 10f);
		gVar.lives = 5;
		gVar.score = 0;
		DestroyAllObjects ();
		Application.LoadLevel ("Level");
	}

	public void stopSpawning(){
		StopCoroutine ("spawnCloud");
		StopCoroutine ("spawnAnts");
	}

	void DestroyAllObjects()
	{
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

	}

	void Update () {
		if (gVar.lives == 0) {
			gVar.playGame = false;
		}
	}

	IEnumerator spawnCloud(){
		while (gVar.playGame && gVar.pausedGame == false) {

			timer_cloud = Random.Range (0.05f, gVar.top_speed_cloud-1);

			if (counter_cloud>10){
				if (gVar.top_speed_cloud>1.0f){
					gVar.top_speed_cloud = gVar.top_speed_cloud - 0.1f;
				}
				counter_cloud = 0;
			}

			yield return new WaitForSeconds (timer_cloud);
		
			spawn_location_cloud = Random.Range (1, 9);

			while(whileCount<4){
				if(spawn_location_cloud == gVar.cloudAlley[whileCount]){
					spawn_location_cloud = Random.Range (1, 9);
					whileCount = 0;
				}
				if(spawn_location_cloud != gVar.cloudAlley[whileCount]){
					whileCount++;
				}
			}

			if (spawn_location_cloud == 1) {
				Instantiate (cloudL, new Vector3 ((gVar.cloudSpawnX - gVar.cloudChangeX*1), (gVar.cloudSpawnY - gVar.cloudChangeY*0), 0f), Quaternion.identity);
			}
			else if (spawn_location_cloud == 2) {
				Instantiate (cloudR, new Vector3 ((gVar.cloudSpawnX - gVar.cloudChangeX*0), (gVar.cloudSpawnY - gVar.cloudChangeY*0), 0f), Quaternion.identity);
			}
			else if (spawn_location_cloud == 3) {
				Instantiate (cloudL, new Vector3 ((gVar.cloudSpawnX - gVar.cloudChangeX*1), (gVar.cloudSpawnY - gVar.cloudChangeY*1), 0f), Quaternion.identity);
			}
			else if (spawn_location_cloud == 4) {
				Instantiate (cloudR, new Vector3 ((gVar.cloudSpawnX - gVar.cloudChangeX*0), (gVar.cloudSpawnY - gVar.cloudChangeY*1), 0f), Quaternion.identity);
			}
			else if (spawn_location_cloud == 5) {
				Instantiate (cloudL, new Vector3 ((gVar.cloudSpawnX - gVar.cloudChangeX*1), (gVar.cloudSpawnY - gVar.cloudChangeY*2), 0f), Quaternion.identity);
			}
			else if (spawn_location_cloud == 6) {
				Instantiate (cloudR, new Vector3 ((gVar.cloudSpawnX - gVar.cloudChangeX*0), (gVar.cloudSpawnY - gVar.cloudChangeY*2), 0f), Quaternion.identity);
			}
			else if (spawn_location_cloud == 7) {
				Instantiate (cloudL, new Vector3 ((gVar.cloudSpawnX - gVar.cloudChangeX*1), (gVar.cloudSpawnY - gVar.cloudChangeY*3), 0f), Quaternion.identity);
			}
			else if (spawn_location_cloud == 8) {
				Instantiate (cloudR, new Vector3 ((gVar.cloudSpawnX - gVar.cloudChangeX*0), (gVar.cloudSpawnY - gVar.cloudChangeY*3), 0f), Quaternion.identity);
			}

			if(cloudAlleyCount<8){
				gVar.cloudAlley[cloudAlleyCount] = spawn_location_cloud;
			}
			else{
				cloudAlleyCount = 0;
				gVar.cloudAlley[cloudAlleyCount] = spawn_location_cloud;}

			whileCount = 0;
			cloudAlleyCount++;
			counter_cloud++;
		}
	}
	
	IEnumerator spawnAnts(){
		while (gVar.playGame && gVar.pausedGame == false) {
			
			timer_ants = Random.Range (2.0f, gVar.top_speed_ants);
			
			if (counter_ants>10){
				if (gVar.top_speed_ants>2.0f){
					gVar.top_speed_ants = gVar.top_speed_ants - 0.05f;
				}
				counter_ants = 0;
			}
			
			yield return new WaitForSeconds (timer_ants);
			
			spawn_location_ants = Random.Range (1, 13);

			Instantiate (ants, new Vector3 ((gVar.antSpawnX+gVar.antChangeX*spawn_location_ants), gVar.antSpawnY, 2f), Quaternion.identity);
			counter_ants++;
		}
	}

}
