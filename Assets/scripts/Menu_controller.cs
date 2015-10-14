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
	private RectTransform rectTransform;

	public static int player_number;
	public static int bestSocre;
	public Text bestScoreText;

	// Use this for initialization
	void Start () {

		slider_menu = GameObject.Find ("slider");
		player_number = 1;
		offsetTransform = 180f;// / 2.812102f; // different position each Slider 
		bestSocre = loadHighScore ();
		bestScoreText.text = bestSocre.ToString ();
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

				rectTransform = slider_menu.GetComponent<RectTransform>();
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x-(offsetTransform),rectTransform.anchoredPosition.y);
				//sumpoint +=  15;
				//point.text = sumpoint.ToString();
			}
			
		} else if (dragEnd.x > dragStart.x) {
			if (player_number != 1) {
				player_number--;

				rectTransform = slider_menu.GetComponent<RectTransform>();
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x+(offsetTransform),rectTransform.anchoredPosition.y);

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
