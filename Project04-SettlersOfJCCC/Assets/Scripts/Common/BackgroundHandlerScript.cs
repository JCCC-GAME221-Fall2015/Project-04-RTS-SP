// BackgroundHandlerScript.cs
// Author: Craig Broskow
using UnityEngine;
using System.Collections;

public class BackgroundHandlerScript : MonoBehaviour {

	public void SetBackgroundImage(ResourceTypes pResourceType)
	{
		Material backgroundMaterial;

		switch (pResourceType)
		{
			case ResourceTypes.BRICK:
				backgroundMaterial = (Material)Resources.Load("Materials/ClayMaterial");
				GetComponent<MeshRenderer>().material = backgroundMaterial;
				break;
			case ResourceTypes.GRAIN:
				backgroundMaterial = (Material)Resources.Load("Materials/WheatMaterial");
				GetComponent<MeshRenderer>().material = backgroundMaterial;
				break;
			case ResourceTypes.WOOD:
				backgroundMaterial = (Material)Resources.Load("Materials/WoodMaterial");
				GetComponent<MeshRenderer>().material = backgroundMaterial;
				break;
			case ResourceTypes.WOOL:
				backgroundMaterial = (Material)Resources.Load("Materials/SheepMaterial");
				GetComponent<MeshRenderer>().material = backgroundMaterial;
				break;
			default:
				Debug.Log ("Invalid resource type!");
				break;
		}
	} // end method SetBackgroundImage

	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
} // end class BackgroundHandlerScript
