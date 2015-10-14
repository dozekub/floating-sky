using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {

	private int player_number;

	// Use this for initialization
	void Start () {
		player_number = Menu_controller.player_number;
		Debug.Log (player_number);
		saveHighScore ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadLose(){
		Application.LoadLevel("Lose");
	}

	public void saveHighScore(){
		
		//highScore = loadHighScore ();
		//if (score > highScore) {
			
			//Animation Save Score
			//highScoreText.text = score.ToString ();
			// Save New Score
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath+"/playerInfo.dat");
			
			HighScoreData data = new HighScoreData();
			data.highScoreData = 50;
			bf.Serialize(file,data);
			file.Close();
			
			
		//}
		
	}

}
