// SettPrefabData.cs
// Author: Craig Broskow
using UnityEngine;
using System.Collections;

public class SettPrefabData : MonoBehaviour {
	
	public string settName;
	public int settNumber;
	public string settColor;

	public void SetSettName(string pSettName)
	{
		settName = pSettName;
	}
	
	public void SetSettNumber(int pSettNumber)
	{
		settNumber = pSettNumber;
	}
	
	public void SetSettColor(string pSettColor)
	{
		settColor = pSettColor;
		Material settlementMaterial;

		switch (pSettColor)
		{
			case "Blue":
				settlementMaterial = (Material)Resources.Load("Materials/Blue");
				GetComponent<MeshRenderer>().material = settlementMaterial;
				break;
			case "Green":
				settlementMaterial = (Material)Resources.Load("Materials/Green");
				GetComponent<MeshRenderer>().material = settlementMaterial;
				break;
			case "Orange":
				settlementMaterial = (Material)Resources.Load("Materials/Orange");
				GetComponent<MeshRenderer>().material = settlementMaterial;
				break;
			case "Purple":
				settlementMaterial = (Material)Resources.Load("Materials/Purple");
				GetComponent<MeshRenderer>().material = settlementMaterial;
				break;
			case "Red":
				settlementMaterial = (Material)Resources.Load("Materials/Red");
				GetComponent<MeshRenderer>().material = settlementMaterial;
				break;
			case "Yellow":
				settlementMaterial = (Material)Resources.Load("Materials/Yellow");
				GetComponent<MeshRenderer>().material = settlementMaterial;
				break;
			default:
				settlementMaterial = (Material)Resources.Load("Materials/Black");
				GetComponent<MeshRenderer>().material = settlementMaterial;
				break;
		} // end switch
	} // end method SetSettColor
	
	// Use this for initialization
	//	void Start ()
	//	{
	//
	//	}
	
	// Update is called once per frame
	//	void Update () {
	//	
	//	}
}// end class SettPrefabData
