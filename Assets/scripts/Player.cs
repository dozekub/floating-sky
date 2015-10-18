using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool goLeft = false;
	public bool goRight = false;
	private bool alive = true;
	private Rigidbody2D rigidbody;
	private SpriteRenderer spriteRender;
	private AudioSource collider_sound;

	public float speed;
	public Sprite player_normal;
	public Sprite player_both;
	public Sprite player_left;
	public Sprite player_right;
	public GameObject ex_mark;


	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		spriteRender = GetComponent<SpriteRenderer> ();
		collider_sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (alive) { // If Player alive 
			if (goLeft && goRight) {
				spriteRender.sprite = player_both;
				rigidbody.AddForce (new Vector3 (0, 1, 0) * speed / 2, ForceMode2D.Force);

			} else if (goLeft) {

				spriteRender.sprite = player_left;
				rigidbody.AddForce (new Vector3 (-1, 0.5f, 0) * speed, ForceMode2D.Force);

				if (transform.rotation.z < 0.20)
					transform.Rotate (0, 0, Time.deltaTime * 100);
				
			} else if (goRight) {
				spriteRender.sprite = player_right;
				rigidbody.AddForce (new Vector3 (1, 0.5f, 0) * speed, ForceMode2D.Force);
				
				if (transform.rotation.z > -0.20)
					transform.Rotate (0, 0, -Time.deltaTime * 100);
			} else {
				spriteRender.sprite = player_normal;
				rigidbody.AddForce (new Vector3 (0, -1, 0) * speed / 2, ForceMode2D.Force);
			}
		}

	}

	// Lose Scens

	void OnTriggerEnter2D(Collider2D other) {
		collider_sound.Play ();
		alive = false;
		rigidbody.velocity = Vector3.zero;
		rigidbody.AddForce (new Vector3 (0, -30, 0) * speed, ForceMode2D.Force);
		Instantiate(ex_mark,new Vector3(transform.position.x,transform.position.y+40,transform.position.z),Quaternion.identity);
		StartCoroutine(loadLoseScen(1));
	}

	IEnumerator loadLoseScen(int delay)
	{
		yield return new WaitForSeconds(delay);
		GameController.loadLose ();
	}

}
