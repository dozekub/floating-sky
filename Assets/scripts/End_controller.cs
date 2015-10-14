using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class End_controller : MonoBehaviour {

	public Text getScore;
	public Text bestScoreText;

	void Start(){
		bestScoreText.text = Menu_controller.bestSocre.ToString();
		getScore.text = "5";
	}

	public void loadEnd(){
		//audioSource.Play();
		//choosePlayer ();
		Application.LoadLevel("Menu");
	}

	public void loadGame(){
		//audioSource.Play();
		//choosePlayer ();
		Application.LoadLevel("Game");
	}


}
