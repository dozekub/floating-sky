using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.5f;

	private int drawDepth = -100;
	private float alpha = 1.0f;
	private int fadeDir = -1;

	void OnGUI(){
		// fade Out/in 
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		//Set Color
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);

	}

	public float BeginFade(int direction){
		fadeDir = direction;
		return (fadeSpeed);
	}

}
