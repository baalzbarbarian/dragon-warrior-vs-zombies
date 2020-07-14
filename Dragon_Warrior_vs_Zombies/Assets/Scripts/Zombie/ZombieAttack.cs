using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name.Equals ("Player")) {
			Patrol.isAttacking = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.name.Equals ("Player")) {
			Patrol.isAttacking = false;
		}
	}

}
