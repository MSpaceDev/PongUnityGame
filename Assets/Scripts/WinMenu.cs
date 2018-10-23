using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour {

	public Text winText;

	void Awake () {
		if (GameManager.instance.player1Score >= GameManager.instance.winScore)
			winText.text = "Player 1 Wins!";
		else
			winText.text = "Player 2 Wins!";
	}

	private void Start()
	{
		AudioManager.instance.Play(1);
	}
}
