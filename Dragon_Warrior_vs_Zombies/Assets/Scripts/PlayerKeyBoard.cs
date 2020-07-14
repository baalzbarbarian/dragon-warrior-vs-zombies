using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerKeyBoard : MonoBehaviour {

	public CharacterController2D controller;
	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	bool isAttacking = false;

	private GameObject player;

	public Animator animator;


	//Health bars
	[SerializeField]
	Slider healthBar;
	[SerializeField]
	Text healthText;

	float maxHealth = 100;
	float curHealth;

	//Casting spell
	public Transform firePoint;
	public GameObject castingSpell;
	bool canShoot = true;

	// Use this for initialization
	void Start () {
		//get healths bars value and set to health text
		healthBar.value = maxHealth;
		curHealth = healthBar.value;
	}
		
	void Update () {
		//Update health value
		healthText.text = curHealth.ToString() + " %";

		if (Input.GetKeyDown (KeyCode.F) && canShoot) {
			SoundManager.PlaySound ("fire");
			isAttacking = true;
			animator.SetBool ("isAttacking", true);
			Shoot ();
			StartCoroutine (CastingSpellDelay ());
		} else {
			animator.SetBool ("isAttacking", false);

		}

		horizontalMove = Input.GetAxisRaw ("Horizontal") * runSpeed;

		animator.SetFloat ("Speed", Mathf.Abs (horizontalMove));


		if (!jump && Input.GetKeyDown (KeyCode.Space)) {
			jump = true;
			animator.SetBool ("isJumping", true);
			SoundManager.PlaySound ("jump");
		}



		if (curHealth <= 0) {
			GetComponent<PlayerKeyBoard> ().enabled = false;

			StartCoroutine ("WaitBeforeDead");
			animator.Play ("Die");

			FindObjectOfType<GameOverMenu> ().EndGame ();
		}
	
	}

	void Shoot(){
		if (isAttacking && canShoot) {
			Instantiate (castingSpell, firePoint.position, firePoint.rotation);
			canShoot = false;
			isAttacking = false;
		}
	}

	public void OnLanding(){
		animator.SetBool ("isJumping", false);	
	}

	void FixedUpdate(){
		//Move character
		controller.Move (horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;

	}

	void OnTriggerStay2D(Collider2D coll) {
		if (coll.gameObject.tag == "zombie_1") {
			healthBar.value -= 1f;
			curHealth = healthBar.value;
		} else if (coll.gameObject.tag == "trap") {
			healthBar.value -= 4f;
			curHealth = healthBar.value;
		} else if (Patrol.isAttacking) {
			healthBar.value -= 1.5f;
			curHealth = healthBar.value;

		}

	}

	IEnumerator WaitBeforeDead(){
		yield return new WaitForSeconds (15/10);
		Destroy (GameObject.Find ("Player"));
	}

	IEnumerator CastingSpellDelay(){
		yield return new WaitForSeconds (1);
		canShoot = true;
	}


	//Collecting Potion
	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Potion")) {
			healthBar.value += 30f;
			curHealth = healthBar.value;
			Destroy (other.gameObject);
		}


	}

}
