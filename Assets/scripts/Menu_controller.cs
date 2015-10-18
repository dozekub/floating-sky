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
	private int sumpoint;

	public static int player_number;
	public static int bestSocre;
	public Text bestScoreText;
	public Text pointText;
	public GameObject[] lockPlayer;
	public AudioSource audioSource_slider;

	// Use this for initialization
	void Start () {

		sumpoint = 0;
		slider_menu = GameObject.Find ("slider");
		player_number = 1;
		offsetTransform = 180f;// / 2.812102f; // different position each Slider 
		bestSocre = loadHighScore ();
		bestScoreText.text = bestSocre.ToString ();
		hiddenLock ();
	}

	void hiddenLock(){
		
		if (bestSocre >= 60)
		{
			lockPlayer[3].gameObject.SetActive(false);
		} 
		if (bestSocre >= 45)
		{
			lockPlayer[2].gameObject.SetActive(false);
		} 
		if (bestSocre >= 30)
		{
			lockPlayer[1].gameObject.SetActive(false);
		} 
		if (bestSocre >= 15)
		{
			lockPlayer[0].gameObject.SetActive(false);
		} 
	}
	
	public static void choosePlayer(){
		
		if (player_number == 5 && bestSocre >= 60)
		{
			player_number = 5;
		} 
		else if (player_number >= 4 && bestSocre >= 45)
		{
			player_number = 4;
		} 
		else if (player_number >= 3 && bestSocre >= 30)
		{
			player_number = 3;
		} 
		else if (player_number >= 2 && bestSocre >= 15)
		{
			player_number = 2;
		} 
		else 
		{
			player_number = 1;
		}
	}

	public void  DragStart(){
		dragStart = Input.mousePosition;
	}
	
	public void DragEnd(){
		// Launch the ball
		audioSource_slider.Play ();
		dragEnd = Input.mousePosition;
		//audioSource.Play ();
		if (dragEnd.x < dragStart.x) {
			if (player_number != 5) {
				player_number++;

				rectTransform = slider_menu.GetComponent<RectTransform>();
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x-(offsetTransform),rectTransform.anchoredPosition.y);
				sumpoint +=  15;
				pointText.text = sumpoint.ToString();
			}
			
		} else if (dragEnd.x > dragStart.x) {
			if (player_number != 1) {
				player_number--;

				rectTransform = slider_menu.GetComponent<RectTransform>();
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x+(offsetTransform),rectTransform.anchoredPosition.y);

				sumpoint -= 15;
				pointText.text = sumpoint.ToString();
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

	public void rateButtonClick(){
		Application.OpenURL("market://details?id=com.Dozekub.SkyDown");
	}

}

//For Save Hight Score
[Serializable]
class HighScoreData{
	public int highScoreData;
}
