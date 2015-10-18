using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class End_controller : MonoBehaviour {

	public Text getScore;
	public Text bestScoreText;

	private AudioSource button_sound;

	void Start(){

		button_sound = GetComponent<AudioSource> ();

		bestScoreText.text = Menu_controller.bestSocre.ToString();
		getScore.text = CountScore.score.ToString ();

		saveHighScore ();

	}

	public void loadMenu(){;
		button_sound.Play ();
		StartCoroutine(loadScen("Menu"));
	}

	public void loadGame(){
		button_sound.Play ();
		StartCoroutine(loadScen("Game"));
	}

	IEnumerator loadScen(String scen)
	{
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(scen);
	}

	public void saveHighScore(){
		
		if (CountScore.score > Menu_controller.bestSocre) {
		
			//Animation Save Score
			Menu_controller.bestSocre = CountScore.score;
			bestScoreText.text = getScore.text;
			// Save New Score
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath+"/playerInfo.dat");
			HighScoreData data = new HighScoreData();
			data.highScoreData = CountScore.score;
			bf.Serialize(file,data);
			file.Close();
		
		
		}
		
	}
	
}
