// RoadPrefabData.cs
// Author: Craig Broskow
using UnityEngine;
using System.Collections;

public class RoadPrefabData : MonoBehaviour {
	
	public string roadName;
	public int roadID;
	public string roadColor;
	
	public void SetRoadName(string pRoadName)
	{
		roadName = pRoadName;
	}
	
	public void SetRoadID(int pRoadID)
	{
		roadID = pRoadID;
	}
	
	public void SetRoadColor(string pRoadColor)
	{
		roadColor = pRoadColor;
		Material roadMaterial;
		
		switch (pRoadColor)
		{
		case "Blue":
			roadMaterial = (Material)Resources.Load("Materials/Blue");
			GetComponent<MeshRenderer>().material = roadMaterial;
			break;
		case "Green":
			roadMaterial = (Material)Resources.Load("Materials/Green");
			GetComponent<MeshRenderer>().material = roadMaterial;
			break;
		case "Orange":
			roadMaterial = (Material)Resources.Load("Materials/Orange");
			GetComponent<MeshRenderer>().material = roadMaterial;
			break;
		case "Purple":
			roadMaterial = (Material)Resources.Load("Materials/Purple");
			GetComponent<MeshRenderer>().material = roadMaterial;
			break;
		case "Red":
			roadMaterial = (Material)Resources.Load("Materials/Red");
			GetComponent<MeshRenderer>().material = roadMaterial;
			break;
		case "Yellow":
			roadMaterial = (Material)Resources.Load("Materials/Yellow");
			GetComponent<MeshRenderer>().material = roadMaterial;
			break;
		default:
			roadMaterial = (Material)Resources.Load("Materials/Black");
			GetComponent<MeshRenderer>().material = roadMaterial;
			break;
		} // end switch
	} // end method SetRoadColor
	
	// Use this for initialization
	//	void Start ()
	//	{
	//
	//	}
	
	// Update is called once per frame
	//	void Update () {
	//	
	//	}
}// end class RoadPrefabData
