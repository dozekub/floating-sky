using UnityEngine;
using System.Collections;

public class End_controller : MonoBehaviour {

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
