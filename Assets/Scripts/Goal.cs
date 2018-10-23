using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	public Text player1Score;
	public Text player2Score;

	private void Awake()
	{
		player1Score.text = Convert.ToString(GameManager.instance.player1Score);
		player2Score.text = Convert.ToString(GameManager.instance.player2Score);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (gameObject.tag == "PlayerGoal1")
		{
			player2Score.text = Convert.ToString(GameManager.instance.IncrementScore(2));
			GameManager.instance.lastWinner = 2;
		}
		else
		{
			player1Score.text = Convert.ToString(GameManager.instance.IncrementScore(1));
			GameManager.instance.lastWinner = 1;
		}

		if (GameManager.instance.player1Score >= GameManager.instance.winScore ||
			GameManager.instance.player2Score >= GameManager.instance.winScore)
			SceneLoader.instance.LoadUnload(3, SceneManager.GetActiveScene().buildIndex);
		else
			SceneLoader.instance.Reset(SceneManager.GetActiveScene().buildIndex);
	}
}
