// HexNumberHandlerScript.cs
// Author: Craig Broskow
using UnityEngine;
using System.Collections;

public class HexNumberHandlerScript : MonoBehaviour {

	public void SetHexNumberText(int pHexNumber)
	{
		Material numberMaterial = (Material)Resources.Load("Materials/Number" + pHexNumber.ToString());
		GetComponent<MeshRenderer>().material = numberMaterial;
	}

	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
} // end class HexNumberHandlerScript
