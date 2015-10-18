using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public AudioSource audioSource;

	public void loadGame(){
		audioSource.Play();
		Menu_controller.choosePlayer ();
		Application.LoadLevel("Game");
	}

}
