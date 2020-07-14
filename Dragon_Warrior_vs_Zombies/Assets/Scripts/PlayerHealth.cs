using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	[SerializeField]
	Slider healthBar;
	[SerializeField]
	Text healthText;

	float maxHealth = 100;
	float curHealth;

	public Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

		healthBar.value = maxHealth;
		curHealth = healthBar.value;
	}
	
	// Update is called once per frame
	void Update () {
		healthText.text = curHealth.ToString() + " %";

		if (curHealth <= 0) {
			GetComponent<CharacterController2D> ().enabled = false;
			GetComponent<PlayerKeyBoard> ().enabled = false;
			StartCoroutine ("WaitBeforeDeath");
			animator.Play("Die");

		}

	}

	void OnTriggerStay2D(Collider2D coll) {
		if (coll.gameObject.tag == "zombie_1") {
			healthBar.value -= 2f;
			curHealth = healthBar.value;
		}
	}

	IEnumerator WaitBeforeDeath(){
		yield return new WaitForSeconds (15/10);
		Destroy (GameObject.Find ("Player"));
	}
}
