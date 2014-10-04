using UnityEngine;
using System.Collections;

//[RequireComponent(AudioSource)]
public class AudioScript : MonoBehaviour {
	
	private AudioSource AS;
	// Use this for initialization
	void Start () {
		AS = GetComponent<AudioSource> ();
	}
	// Update is called once per frame
	void FixedUpdate () {
		Collider[] objectsInVicinity = Physics.OverlapSphere (transform.position, 15f);
		AS.volume = ((float)(objectsInVicinity.Length - 2))/20;//nomalize
	}
}