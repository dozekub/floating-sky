using UnityEngine;
using System.Collections;

public class MusicBackground : MonoBehaviour {
	
	private static bool created = false;
	// Use this for initialization
	void Start () {
		if (!created) {
			// this is the first instance - make it persist
			DontDestroyOnLoad(this.gameObject);
			created = true;
		} else {
			// this must be a duplicate from a scene reload - DESTROY!
			Destroy(this.gameObject);
		} 
	}
	
}
