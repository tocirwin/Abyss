using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneChanger : object {

	public static string winningPlayer;
	public static string[] playerNames = {"Player1", "AIPlayer"};

	public static List<string> scenes = new List<string>()
	{"Start", "Game", "HighScore"};

	//Application.targetFrameRate = 60;
	// for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
	// 	scenes.Add(SceneManager.GetSceneByBuildIndex(i).name);
	// }

	public static void LoadNewScene (string sceneName) {

		SceneManager.LoadScene(sceneName);
	}

	public static void LoadNewScene (int sceneIndex) {
		SceneManager.LoadScene(sceneIndex);
	}

	public static void LoadNewScene (string sceneName, string playerName) {
		SceneManager.LoadScene(sceneName);
		foreach (string name in playerNames) {
			if (playerName != name) {
				winningPlayer = name;
			}
		}
	}
}
