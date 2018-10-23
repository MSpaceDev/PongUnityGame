using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void LoadScene(int scene)
	{
		SceneLoader.instance.LoadUnload(scene, SceneManager.GetActiveScene().buildIndex);

		GameManager.instance.player1Score = 0;
		GameManager.instance.player2Score = 0;
	}

	public void Exit()
	{
		Application.Quit();
	}
}
