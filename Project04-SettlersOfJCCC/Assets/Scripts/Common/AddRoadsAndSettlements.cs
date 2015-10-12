// AddRoadsAndSettlements.cs
// Author: Craig Broskow
using UnityEngine;
using System.Collections;

public class AddRoadsAndSettlements : MonoBehaviour {

	private string outputString;
	private GameControlScript gameControlScript;

	public void OnMouseDown()
	{
		if (!HelperScript.enableRoads && !HelperScript.enableSettlements)
			return;

		outputString = "Parent Name: " + gameObject.GetComponentInParent<HexPrefabData>().name
			+ "  Side: " + gameObject.name + " was clicked!";
		Debug.Log(outputString);

		if (HelperScript.enableRoads && gameObject.tag == "Side")
		{
			HelperScript.enableRoads = false;
			gameControlScript.AddRoad(gameObject.GetComponentInParent<HexPrefabData>().name, gameObject.name);
		}

		if (HelperScript.enableSettlements && gameObject.tag == "Vertex")
		{
			HelperScript.enableSettlements = false;
			gameControlScript.AddSettlement(gameObject.GetComponentInParent<HexPrefabData>().name, gameObject.name);
		}
	}
	
	// Use this for initialization
	void Start () {
		gameControlScript = GameObject.FindGameObjectWithTag("GameControllerObject").GetComponent<GameControlScript>();
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
} // end class AddRoadsAndSettlements
