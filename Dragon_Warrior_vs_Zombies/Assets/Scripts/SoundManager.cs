using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static AudioClip playerFireSound, playerJumpSound, playerHealing, enemyDeath;
	static AudioSource audioSrc;
	// Use this for initialization
	void Start () {
		playerFireSound = Resources.Load<AudioClip> ("fire_sound");
		playerJumpSound = Resources.Load<AudioClip> ("jump_sound");
		playerHealing = Resources.Load<AudioClip> ("coin_sound");
		enemyDeath = Resources.Load<AudioClip> ("zombie_Sound");

		audioSrc = GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void PlaySound (string clip){
		switch (clip) {
		case "fire":
			audioSrc.PlayOneShot (playerFireSound);
			break;
		case "jump":
			audioSrc.PlayOneShot (playerJumpSound);
			break;
		case "healing":
			audioSrc.PlayOneShot (playerHealing);
			break;
		case "enemyDeath":
			audioSrc.PlayOneShot (enemyDeath);
			break;
		}
	}
}
