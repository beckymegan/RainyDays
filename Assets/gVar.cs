using UnityEngine;
using System.Collections;

public class gVar : MonoBehaviour {

	public static int score = 0;//Player score
	public static int lives = 5;//Player lives
	public static int winScore = 10;//Number of points to win the level
	public static int loseScore = 90;//Number of frames before score goes down
	public static int level = 0;
	public static int timer = 0;
	public static int numGameOvers = 0;

	public static int[] cloudAlley = new int[9];

	public static float cloudSpawnX = -9.7f;
	public static float cloudChangeX = -6.5f;
	public static float cloudSpawnY = -5.6f;
	public static float cloudChangeY = 1f;
	public static float antSpawnX = -10f;
	public static float antChangeX = 0.5f;
	public static float antSpawnY = -14f;
	public static float antChangeY = 1f;

	public static float top_speed_cloud = 0f; //SPAWN RATE - HIGHER IS SLOWER
	public static float top_speed_ants = 0f;

	public static float minCloud = 0f;//Min speed of clouds
	public static float maxCloud = 0f;//Max speed of clouds
	public static float minAnt = 0f;
	public static float maxAnt = 0f;

	public static float musicVolume = 0.5f;
	public static float effectVolume = 0.5f;

	public static int goldTime = 30;//Level complete time to gold a level

	public static bool playGame = true;
	public static bool gameStart = true;
	public static bool restart = false;
	public static bool pausedGame = false;
	public static bool musicPaused = true;
	public static bool effectsPaused = true;
	public static bool levelRestart = true;
	public static bool clearData = false;
	public static bool levelLost = false;

}
