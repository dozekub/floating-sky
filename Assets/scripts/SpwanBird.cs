using UnityEngine;
using System.Collections;

public class SpwanBird : MonoBehaviour {

	private int randomSpawn;
	private Vector3 spawnPosition;
	private GameObject bornBird;

	public GameObject birdLeft;
	public GameObject birdRight;

	// Use this for initialization
	void Start () {
		StartCoroutine("spawnBird");
	}
	
	IEnumerator spawnBird(){
		
		while(true){

			randomSpawn = Random.Range (0,2); // IF Random 0 = Left , 1 = Right
			if(randomSpawn == 0){
				//Left
				spawnPosition  = new Vector3(-110f,Random.Range(-80f,65),0 );
				bornBird = birdLeft;
			}
			else if(randomSpawn == 1){
				//Right
				spawnPosition  = new Vector3(110f,Random.Range(-80f,65),0 );
				bornBird = birdRight;
			}
			//else if(randomSpawn == 2){
				//Left Below
				//spawnPosition  = new Vector3(Random.Range(-4f,0),-5.0f,0 );
				//bornBird = birdLeft;
			//}
			//else if(randomSpawn == 3){
				//Right Below
				//spawnPosition  = new Vector3(Random.Range(0,4f),-5.0f,0 );
				//bornBird = birdRight;
			//}
			
//			if(Score.GetScore() >= 10)
//			{
//				timeDelay = 1;
//			}

			
			Instantiate(bornBird,spawnPosition,Quaternion.identity);

			yield return new WaitForSeconds(1);
			
		}

		
	}
}
