using UnityEngine;
using System.Collections;

public class BirdLeft : MonoBehaviour {

	public float speed = 50f;
	private Rigidbody2D rigidbody;
	private int randomBird;
	
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		randomBird = Random.Range (0,2);
	}

	void FixedUpdate(){

		if(randomBird==0) // Up
			rigidbody.AddForce(new Vector3(1,1,0) * speed,ForceMode2D.Force);
		else // Down
			rigidbody.AddForce(new Vector3(1,-1,0) * speed,ForceMode2D.Force);
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		if(other.tag != "bird")
			Destroy (gameObject);
	}


}
