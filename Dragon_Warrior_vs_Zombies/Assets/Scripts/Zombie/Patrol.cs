using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	public float speed;
	public float distance;
	public int health = 100;
	private bool movingRight = true;

	public Transform groundDetection;

	Vector3 localScale;

	public static bool isAttacking = false;

	Rigidbody2D rb;

	Animator anim;

	public GameObject deathEffect;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * speed * Time.deltaTime);

		RaycastHit2D groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.down, distance);

		if ((groundInfo.collider == false) && (movingRight)) {
			transform.eulerAngles = new Vector3 (0, -180 , 0);
			movingRight = false;
		} else if((groundInfo.collider == false) && (!movingRight)){
			transform.eulerAngles = new Vector3 (0, 0, 0);
			movingRight = true;
		}

		if (isAttacking) {
			anim.SetBool ("isAttacking", true);
		} else {
			anim.SetBool ("isAttacking", false);
		}

	}

	public void TakeDamage(int damage){
		health -= damage;

		if (health <= 0) {
			speed = 0;
			Die ();
		}
	}

	void Die(){
		SoundManager.PlaySound ("enemyDeath");
		//anim.SetBool ("isDead", true);
		//StartCoroutine ("WaitBeforeDead");

		GameObject enemyDeathEffect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);

		if (!movingRight) {
			enemyDeathEffect.transform.eulerAngles = new Vector3 (0, -180, 0);
		} else {
			enemyDeathEffect.transform.eulerAngles = new Vector3 (0, 0, 0);
		}

		Destroy (enemyDeathEffect, 2);
		Destroy (gameObject);
	}

	IEnumerator WaitBeforeDead(){
		yield return new WaitForSeconds (19/10f);
		Destroy (gameObject);
	}

}
