// SettDataScript.cs
// Author: Craig Broskow
using UnityEngine;
using System.Collections;

public class SettDataScript
{

	public string settDataName;
	public int settDataNumber;
	public string settDataColor;
	public Vector3 settDataPosition;
	public string settDataPlayer;
	public int[] settHexNeighbors = new int[3];

	public void LogSettlementData()
	{
		string outputString;
		
		outputString = "Settlement name: " + settDataName.ToString() +
			" Number: " + settDataNumber.ToString() +
			" Color: " + settDataColor.ToString() +
			" Position: " + settDataPosition.ToString() +
			" Player: " + settDataPlayer.ToString() +
			" Hex Neighbor 1: " + settHexNeighbors[0].ToString() +
			" Hex Neighbor 2: " + settHexNeighbors[1].ToString() +
			" Hex Neighbor 3: " + settHexNeighbors[2].ToString();

		Debug.Log(outputString);
	} // end method LogSettlementData

	//	public SettDataScript()
	//	{
	//
	//	}
	
	// Use this for initialization
	//	void Start () {
	//	
	//	}
	
	// Update is called once per frame
	//	void Update () {
	//	
	//	}
} // end class SettDataScript
