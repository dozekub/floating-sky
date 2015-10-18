using UnityEngine;
using System.Collections;

public class CountScore : MonoBehaviour {

	public static int score;

	void Start(){
		score = 0 ;
		StartCoroutine("CountScoreWithDelay");
	}

	IEnumerator CountScoreWithDelay(){
		while(true){
			yield return new WaitForSeconds(2);
			score++;
		}
		
	}
}
