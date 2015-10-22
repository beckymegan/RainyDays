using UnityEngine;
using System.Collections;

public class levelGlobal : MonoBehaviour {

	public void levelSelect(int level){
		if (level == 1) {
			gVar.playGame = true;
			gVar.score = 0;
			gVar.lives = 5;
			gVar.level = 1;
			gVar.top_speed_ants = 8.0f;
			gVar.top_speed_cloud = 6.0f;
			gVar.minCloud = 0.3f;
			gVar.maxCloud = 2.5f;
			gVar.minAnt = 0.2f;
			gVar.maxAnt = 1.3f;
			gVar.goldTime = 30;
			gVar.loseScore = 180;
			gVar.winScore = 10;
		} else if (level == 2) {
			gVar.playGame = true;
			gVar.score = 0;
			gVar.lives = 5;
			gVar.level = 2;
			gVar.top_speed_ants = 7.8f;
			gVar.top_speed_cloud = 5.8f;
			gVar.minCloud = 0.3f;
			gVar.maxCloud = 2.7f;
			gVar.minAnt = 0.2f;
			gVar.maxAnt = 1.4f;
			gVar.goldTime = 40;
			gVar.loseScore = 90;
			gVar.winScore = 20;
		} else if (level == 3) {
			gVar.playGame = true;
			gVar.score = 0;
			gVar.lives = 5;
			gVar.level = 3;
			gVar.top_speed_ants = 7.6f;
			gVar.top_speed_cloud = 5.6f;
			gVar.minCloud = 0.4f;
			gVar.maxCloud = 2.9f;
			gVar.minAnt = 0.2f;
			gVar.maxAnt = 1.5f;
			gVar.goldTime = 55;
			gVar.loseScore = 70;
			gVar.winScore = 30;
		} else if (level == 4) {
			gVar.playGame = true;
			gVar.score = 0;
			gVar.lives = 5;
			gVar.level = 4;
			gVar.top_speed_ants = 7.4f;
			gVar.top_speed_cloud = 5.4f;
			gVar.minCloud = 0.4f;
			gVar.maxCloud = 3.1f;
			gVar.minAnt = 0.2f;
			gVar.maxAnt = 1.6f;
			gVar.goldTime = 60;
			gVar.loseScore = 60;
			gVar.winScore = 40;
		} else if (level == 5) {
			gVar.playGame = true;
			gVar.score = 0;
			gVar.lives = 5;
			gVar.level = 5;
			gVar.top_speed_ants = 7.2f;
			gVar.top_speed_cloud = 5.2f;
			gVar.minCloud = 0.5f;
			gVar.maxCloud = 3.3f;
			gVar.minAnt = 0.3f;
			gVar.maxAnt = 1.7f;
			gVar.goldTime = 75;
			gVar.loseScore = 50;
			gVar.winScore = 40;
		} else if (level == 6) {
			gVar.playGame = true;
			gVar.score = 0;
			gVar.lives = 5;
			gVar.level = 6;
			gVar.top_speed_ants = 7f;
			gVar.top_speed_cloud = 5f;
			gVar.minCloud = 0.5f;
			gVar.maxCloud = 3.6f;
			gVar.minAnt = 0.3f;
			gVar.maxAnt = 1.8f;
			gVar.goldTime = 90;
			gVar.loseScore = 50;
			gVar.winScore = 50;
		} else if (level == 7) {
			gVar.playGame = true;
			gVar.score = 0;
			gVar.lives = 5;
			gVar.level = 7;
			gVar.top_speed_ants = 6.8f;
			gVar.top_speed_cloud = 4.8f;
			gVar.minCloud = 0.6f;
			gVar.maxCloud = 3.9f;
			gVar.minAnt = 0.3f;
			gVar.maxAnt = 2.0f;
			gVar.goldTime = 110;
			gVar.loseScore = 45;
			gVar.winScore = 50;
		} else if (level == 8) {
			gVar.playGame = true;
			gVar.score = 0;
			gVar.lives = 5;
			gVar.level = 8;
			gVar.top_speed_ants = 6.6f;
			gVar.top_speed_cloud = 4.4f;
			gVar.minCloud = 0.6f;
			gVar.maxCloud = 4.2f;
			gVar.minAnt = 0.3f;
			gVar.maxAnt = 2.1f;
			gVar.goldTime = 130;
			gVar.loseScore = 45;
			gVar.winScore = 60;
		} else if (level == 9) {
			gVar.playGame = true;
			gVar.score = 0;
			gVar.lives = 5;
			gVar.level = 9;
			gVar.top_speed_ants = 6.4f;
			gVar.top_speed_cloud = 4.4f;
			gVar.minCloud = 0.7f;
			gVar.maxCloud = 4.5f;
			gVar.minAnt = 0.4f;
			gVar.maxAnt = 2.3f;
			gVar.goldTime = 155;
			gVar.loseScore = 45;
			gVar.winScore = 60;
		} else if (level == 10) {
			gVar.playGame = true;
			gVar.score = 0;
			gVar.lives = 5;
			gVar.level = 10;
			gVar.top_speed_ants = 6.2f;
			gVar.top_speed_cloud = 4.2f;
			gVar.minCloud = 0.8f;
			gVar.maxCloud = 4.9f;
			gVar.minAnt = 0.4f;
			gVar.maxAnt = 2.5f;
			gVar.goldTime = 180;
			gVar.loseScore = 40;
			gVar.winScore = 70;
		} else if (level == 11) {
			gVar.playGame = true;
			gVar.score = 0;
			gVar.lives = 5;
			gVar.level = 11;
			gVar.top_speed_ants = 6.0f;
			gVar.top_speed_cloud = 4.0f;
			gVar.minCloud = 0.9f;
			gVar.maxCloud = 5.3f;
			gVar.minAnt = 0.5f;
			gVar.maxAnt = 2.7f;
			gVar.goldTime = 205;
			gVar.loseScore = 40;
			gVar.winScore = 70;
		} else if (level == 12) {
			gVar.playGame = true;
			gVar.score = 0;
			gVar.lives = 5;
			gVar.level = 12;
			gVar.top_speed_ants = 5.8f;
			gVar.top_speed_cloud = 3.8f;
			gVar.minCloud = 1.0f;
			gVar.maxCloud = 5.7f;
			gVar.minAnt = 0.5f;
			gVar.maxAnt = 2.9f;
			gVar.goldTime = 235;
			gVar.loseScore = 40;
			gVar.winScore = 70;
		}
	}
}
