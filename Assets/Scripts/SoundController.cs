using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public AudioClip nextClip;
    public GameObject player;

	private AudioSource soundsource;
	private PlayerController pc;
	// Use this for initialization
	void Awake () {
		
        soundsource = GetComponent<AudioSource>();
		pc = player.GetComponent<PlayerController>();
		soundsource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		//soundsource.Play();
		if(pc.collectionMode == true) {
			Debug.Log("inside cm");
			soundsource.Play();
		}
	}
}
