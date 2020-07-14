using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class CastingSpell : MonoBehaviour {

	public float spellSpeed = 20f;
	public Rigidbody2D rb;
	public int damage = 25;
	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * spellSpeed;
	}

	void OnTriggerEnter2D(Collider2D hitInfo){
		Patrol enemy = hitInfo.GetComponent<Patrol> ();
		if (enemy != null) {
			enemy.TakeDamage (damage);
		}

		GameObject explosion = (GameObject) Instantiate (impactEffect, transform.position, transform.rotation);

		Destroy (explosion, 6/10f);

		Destroy (gameObject);
	}
}
