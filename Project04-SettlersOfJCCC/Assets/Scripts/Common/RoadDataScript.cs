// RoadDataScript.cs
// Author: Craig Broskow
using UnityEngine;
using System.Collections;

public class RoadDataScript
{
	public string roadDataName;
	public int roadDataID;
	public string roadDataColor;
	public Vector3 roadDataPosition;
	public string roadDataPlayer;
	public int[] roadHexNeighbors = new int[2];
	
	public void LogRoadData()
	{
		string outputString;
		
		outputString = "Road name: " + roadDataName.ToString() +
			" ID: " + roadDataID.ToString() +
			" Color: " + roadDataColor.ToString() +
			" Position: " + roadDataPosition.ToString() +
			" Player: " + roadDataPlayer.ToString() +
			" Hex Neighbor 1: " + roadHexNeighbors[0].ToString() +
			" Hex Neighbor 2: " + roadHexNeighbors[1].ToString();
		
		Debug.Log(outputString);
	} // end method LogRoadData
	
	//	public RoadDataScript()
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
} // end class RoadDataScript
