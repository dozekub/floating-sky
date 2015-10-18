using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	private float speed = 0.4f;
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (0,Time.time * speed);
		GetComponent<Renderer> ().material.mainTextureOffset = -offset;
	}
}
