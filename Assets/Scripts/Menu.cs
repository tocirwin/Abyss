using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameObject start;
	public GameObject highScore;
	public GameObject winner;

	void Start () {
		InitializeOnScene();
	}

	public void Load (string sceneName) {
		SceneChanger.LoadNewScene(sceneName);
	}

	public void Load (int sceneIndex) {
		SceneChanger.LoadNewScene(sceneIndex);
	}

	private void DisplayWinner () {
		winner.GetComponentInChildren<Text>().text = "The winner is " + SceneChanger.winningPlayer;
	}

	private void InitializeOnScene () {
		string sceneName = SceneManager.GetActiveScene().name;
		switch (sceneName)
		{
			case "Start" :
				start.SetActive(true);
				highScore.SetActive(true);
				winner.SetActive(false);
				break;
			case "Game" :
				start.SetActive(false);
				highScore.SetActive(false);
				winner.SetActive(false);
				GetComponent<Image>().enabled = false;
				break;
			case "HighScore" :
				start.SetActive(true);
				highScore.SetActive(false);
				winner.SetActive(true);
				DisplayWinner();
				break;
		}
	}

}
