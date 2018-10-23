using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public int winScore;
	public int lastWinner;

	[HideInInspector]
	public int player1Score;
	[HideInInspector]
	public int player2Score;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	public int IncrementScore(int playerNumber)
	{
		return playerNumber == 1 ? ++player1Score : ++player2Score;
	}
}
