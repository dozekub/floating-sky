using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Menu_controller : MonoBehaviour {

	private Vector3 dragStart, dragEnd;
	private AudioSource audioSource;
	private float offsetTransform;
	private GameObject slider_menu;

	public static int player_number;
	public static int bestSocre;
	public Text BestScore;

	// Use this for initialization
	void Start () {

		slider_menu = GameObject.Find ("slider");
		player_number = 1;
		offsetTransform = 180f / 2.812102f; // different position each Slider 
		BestScore.text = loadHighScore ().ToString ();
	}
	
	public void  DragStart(){
		dragStart = Input.mousePosition;
	}
	
	public void DragEnd(){
		// Launch the ball
		dragEnd = Input.mousePosition;
		//audioSource.Play ();
		if (dragEnd.x < dragStart.x) {
			if (player_number != 5) {
				player_number++;
				slider_menu.transform.position = new Vector3(slider_menu.transform.position.x-(offsetTransform),slider_menu.transform.position.y,slider_menu.transform.position.z);
				//sumpoint +=  15;
				//point.text = sumpoint.ToString();
			}
			
		} else if (dragEnd.x > dragStart.x) {
			if (player_number != 1) {
				player_number--;
				slider_menu.transform.position = new Vector3(slider_menu.transform.position.x+(offsetTransform),slider_menu.transform.position.y,slider_menu.transform.position.z);
				//sumpoint -= 15;
				//point.text = sumpoint.ToString();
			}
		}
	}

	private int loadHighScore(){
		
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
			
			HighScoreData data = (HighScoreData)bf.Deserialize(file);
			file.Close();
			
			return data.highScoreData;
		}
		
		return 0;
		
	}

}

//For Save Hight Score
[Serializable]
class HighScoreData{
	public int highScoreData;
}
