// VertexHandlerScript.cs
// Author: Craig Broskow
using UnityEngine;
using System.Collections;

public class VertexHandlerScript : MonoBehaviour {
	
	private string outputString;

	void OnMouseDown()
	{
		gameObject.GetComponentInParent<AddRoadsAndSettlements>().OnMouseDown();
	}
	
	// Use this for initialization
//	void Start () {
//		
//	}
	
	// Update is called once per frame
//	void Update () {
//		
//	}
} // end class VertexHandlerScript
