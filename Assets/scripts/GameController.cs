using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Text scoreText;
	public GameObject suggestion;
	public GameObject[] playerPrefab;
	private int player_number;
	private GameObject player;
	private Player myPlayer;


	// Use this for initialization
	void Start () {
		player_number = Menu_controller.player_number;
		MakePlayer (player_number);
		StartCoroutine("Suggestion");
	}

	IEnumerator Suggestion(){
		yield return new WaitForSeconds(2);
		suggestion.GetComponent<Rigidbody2D> ().gravityScale = -10;
		yield return new WaitForSeconds(4);
		Destroy (suggestion);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		scoreText.text = (CountScore.score).ToString();
	}

	public static void loadLose(){
		Application.LoadLevel("Lose");
	}

	// Make Player

	private void MakePlayer(int player_number){
		player = Instantiate(playerPrefab[player_number],transform.position, Quaternion.identity) as GameObject;
		myPlayer = player.GetComponent<Player> ();
	}
	
	public void DownPanelLeft(){
		myPlayer.goLeft = true;
	}
	public void UpPanelLeft(){
		myPlayer.goLeft = false;
	}
	
	public void DownPanelRight(){
		myPlayer.goRight = true;
	}
	public void UpPanelRight(){
		myPlayer.goRight = false;
	}

}
