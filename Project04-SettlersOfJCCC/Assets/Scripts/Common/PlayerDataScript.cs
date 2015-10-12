// PlayerDataScript.cs
// @author: Craig Broskow
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerDataScript
{

	public string playerName;
	public int playerNumber;
	public string playerPhase;
	public string playerColor;
	public List<HexDataScript> playerHexList;
	public int playerGrain;
	public int playerWood;
	public int playerBrick;
	public int playerWool;
	
	// Use this for initialization
	void Start()
	{
		playerGrain = 0;
		playerWood = 0;
		playerBrick = 0;
		playerWool = 0;
	}

	public void LogPlayerData()
	{
		string outputString;
		
		outputString = "Player name: " + playerName.ToString() +
				" Number: " + playerNumber.ToString() +
				" Color: " + playerColor.ToString() +
				" Phase: " + playerPhase.ToString() +
				" Hex Count: " + playerHexList.Count.ToString();

		Debug.Log(outputString);
	} // end method LogPlayerData
} // end class PlayerDataScript
