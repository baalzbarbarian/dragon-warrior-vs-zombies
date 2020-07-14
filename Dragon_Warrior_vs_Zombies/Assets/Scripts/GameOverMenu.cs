using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	bool gameHasEnded = false;

	public GameObject gameOverMenu;

	// Use this for initialization
	public void EndGame () {

		if (gameHasEnded == false) {
			gameHasEnded = true;

			StartCoroutine ("waitASecond");
		}
	}

	IEnumerator waitASecond(){
		yield return new WaitForSeconds (2);
		gameOverMenu.SetActive (true);
	}

	public void RestartLevel(){

		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	
	}

	public void RestartGame(){
		SceneManager.LoadScene ("BeginScreen");
	}

}
