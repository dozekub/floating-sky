using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private bool goLeft = false;
	private bool goRight = false;
	private Rigidbody2D rigidbody;
	public float speed;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (goLeft && goRight) {
			//spriteRenderer.sprite = spritePlayer_both;
			//rigidbody.velocity = new Vector3(0,5f,0);
		} else if (goLeft) {
			
			//spriteRenderer.sprite = spritePlayer_left;
			//rigidbody.velocity = new Vector3(-1.5f*speed,0,0);
			
			if(transform.rotation.z < 0.20 )
				transform.Rotate(0, 0,Time.deltaTime*50);
			//transform.eulerAngles  = new Vector3(0,0,10);
			
		} else if (goRight) {
			//spriteRenderer.sprite = spritePlayer_right;
			//rigidbody.velocity = new Vector3(1.5f*speed,0,0);
			
			if(transform.rotation.z > -0.20 )
				transform.Rotate(0, 0,-Time.deltaTime*50);
			//transform.eulerAngles  = new Vector3(0,0,-10);
		} else{
			//spriteRenderer.sprite = spritePlayer_normal;
			//transform.eulerAngles  = new Vector3(0,0,0);
		}

	}
	
	public void DownPanelLeft(){
		goLeft = true;
	}
	public void UpPanelLeft(){
		goLeft = false;
	}
	
	public void DownPanelRight(){
		goRight = true;
	}
	public void UpPanelRight(){
		goRight = false;
	}

}
