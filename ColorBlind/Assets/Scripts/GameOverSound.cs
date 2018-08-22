using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSound : MonoBehaviour {
    //Audio
    AudioSource myAudio;


	// Use this for initialization
	void Start () {
        //Gets the song for the menu
        myAudio = GetComponent<AudioSource>();
        //Puts a 1.4 seconds delay before the menu song starts
        myAudio.PlayDelayed(1.4f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
