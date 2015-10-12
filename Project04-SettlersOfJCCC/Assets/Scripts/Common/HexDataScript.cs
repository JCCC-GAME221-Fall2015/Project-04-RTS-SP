// HexDataScript.cs
// @author: Craig Broskow
using UnityEngine;
using System.Collections;

public class HexDataScript
{

	public string hexDataName;
	public int hexDataID;
	public int hexDataNumber;
	public ResourceTypes hexDataResourceType;
	public Vector2 hexDataGridLocation;
	public Vector3 hexDataPosition;
	public string hexDataPlayer;
	public Color hexDataColor;
	public Vector2[] hexDataNeighbors = new Vector2[6];

//	public HexDataScript()
//	{
//		hexDataPosition = new Vector3(hexDataGridLocation.x, hexDataGridLocation.y, 0f);
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
} // end class HexDataScript
