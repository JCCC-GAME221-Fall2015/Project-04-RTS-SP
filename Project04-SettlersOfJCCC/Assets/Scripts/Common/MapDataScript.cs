// MapDataScript.cs
// @author: Craig Broskow
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class MapDataScript : MonoBehaviour {

	const float VERTICAL_SEPARATION = 0.8593752f;

	public List<HexDataScript> hexList;

	private FileInfo sourceFile = null;
	private StreamReader reader = null;
	private string filePath;
	private string[] inputLines;
	private int[] dataNumbers;
	private Vector2[] gridLocations;
	private ResourceTypes[] resourceTypes;

	public List<HexDataScript> LoadMapData()
	{
		hexList = new List<HexDataScript>();
		HexDataScript tempHexData;

		if (!MapFileExists())
		{
			Debug.Log("The map file cannot be found!");
			return null;
		}
		if (LoadMapFile())
		{
			for (int i = 1; i <= dataNumbers.Length; i++)
			{
				tempHexData = new HexDataScript();
				tempHexData.hexDataColor = Color.red;
				tempHexData.hexDataName = "HexNumber" + i.ToString();
				tempHexData.hexDataID = i;
				tempHexData.hexDataGridLocation = gridLocations[i - 1];
				tempHexData.hexDataNumber = dataNumbers[i - 1];
				tempHexData.hexDataPlayer = "None";
				tempHexData.hexDataPosition =
					new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
				tempHexData.hexDataResourceType = resourceTypes[i - 1];
				tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
				hexList.Add(tempHexData);
				LogMapData(tempHexData);
			}
		}
		else
		{
			Debug.Log("The map file did not load correctly!");
			Debug.Log("Loading a default, internal map instead!");
			for (int i = 1; i <= 19; i++)
			{
				tempHexData = new HexDataScript();
				switch (i)
				{
				case 1:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(-1f, 2f);
					tempHexData.hexDataNumber = 2;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.WOOD;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 2:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(0f, 2f);
					tempHexData.hexDataNumber = 3;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.WOOL;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 3:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(1f, 2f);
					tempHexData.hexDataNumber = 6;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.GRAIN;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 4:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(-1.5f, 1f);
					tempHexData.hexDataNumber = 4;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.BRICK;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 5:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(-0.5f, 1f);
					tempHexData.hexDataNumber = 6;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.GRAIN;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 6:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(0.5f, 1f);
					tempHexData.hexDataNumber = 5;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.BRICK;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 7:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(1.5f, 1f);
					tempHexData.hexDataNumber = 2;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.WOOL;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 8:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(-2f, 0f);
					tempHexData.hexDataNumber = 2;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.WOOL;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 9:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(-1f, 0f);
					tempHexData.hexDataNumber = 3;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.WOOD;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 10:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(0f, 0f);
					tempHexData.hexDataNumber = 1;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.GRAIN;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 11:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(1f, 0f);
					tempHexData.hexDataNumber = 4;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.WOOD;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 12:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(2f, 0f);
					tempHexData.hexDataNumber = 1;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.GRAIN;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 13:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(-1.5f, -1f);
					tempHexData.hexDataNumber = 1;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.BRICK;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 14:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(-0.5f, -1f);
					tempHexData.hexDataNumber = 4;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.WOOL;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 15:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(0.5f, -1f);
					tempHexData.hexDataNumber = 5;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.WOOL;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 16:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(1.5f, -1f);
					tempHexData.hexDataNumber = 3;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.BRICK;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 17:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(-1f, -2f);
					tempHexData.hexDataNumber = 5;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.WOOD;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 18:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(0f, -2f);
					tempHexData.hexDataNumber = 2;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.GRAIN;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				case 19:
					tempHexData.hexDataColor = Color.red;
					tempHexData.hexDataName = "HexNumber" + i.ToString();
					tempHexData.hexDataID = i;
					tempHexData.hexDataGridLocation = new Vector2(1f, -2f);
					tempHexData.hexDataNumber = 6;
					tempHexData.hexDataPlayer = "None";
					tempHexData.hexDataPosition =
						new Vector3(tempHexData.hexDataGridLocation.x, tempHexData.hexDataGridLocation.y * VERTICAL_SEPARATION, 0f);
					tempHexData.hexDataResourceType = ResourceTypes.WOOD;
					tempHexData.hexDataNeighbors = CalcNeighbors(tempHexData.hexDataGridLocation);
					hexList.Add(tempHexData);
					break;
				} // end switch
				LogMapData(tempHexData);
			} // end for (int i = 1; i <= 19; i++)...
		} // end if (LoadMapFile())...else...

		if (MapIsValid())
			return hexList;
		else
			return null;
	} // end method LoadMapData

	public void LogMapData(HexDataScript pHexData)
	{
		string outputString;

		outputString = "Color: " + pHexData.hexDataColor.ToString() +
			" Name: " + pHexData.hexDataName.ToString() +
			" ID: " + pHexData.hexDataID.ToString() +
			" Grid Location: " + pHexData.hexDataGridLocation.ToString() +
			" Number: " + pHexData.hexDataNumber.ToString() +
			" Player: " + pHexData.hexDataPlayer.ToString() +
			" Resource: " + ((int)pHexData.hexDataResourceType).ToString() +
			" Position: " + pHexData.hexDataPosition.ToString() +
			" Neighbor 1: " + pHexData.hexDataNeighbors[0] +
			" Neighbor 5: " + pHexData.hexDataNeighbors[4];

		Debug.Log(outputString);
	} // end method LogMapData

	public Vector2[] CalcNeighbors(Vector2 pGridLocation)
	{
		Vector2[] tempNeighbors = new Vector2[6];

		tempNeighbors[0] = new Vector2(pGridLocation.x - 1f, pGridLocation.y);
		tempNeighbors[1] = new Vector2(pGridLocation.x - 0.5f, pGridLocation.y + 1f);
		tempNeighbors[2] = new Vector2(pGridLocation.x + 0.5f, pGridLocation.y + 1f);
		tempNeighbors[3] = new Vector2(pGridLocation.x + 1f, pGridLocation.y);
		tempNeighbors[4] = new Vector2(pGridLocation.x + 0.5f, pGridLocation.y - 1f);
		tempNeighbors[5] = new Vector2(pGridLocation.x - 0.5f, pGridLocation.y - 1f);
		return tempNeighbors;
	} // end method CalcNeighbors
	
	public bool HasANeighbor(HexDataScript pHexData)
	{
		const float MAX_VECTOR_DIFF = 0.01f;
		string outputString;
		
		foreach (HexDataScript hexData in hexList)
		{
			if (hexData.hexDataName != pHexData.hexDataName)
			{
				for (int i = 0; i < pHexData.hexDataNeighbors.Length; i++)
				{
					if ((hexData.hexDataGridLocation - pHexData.hexDataNeighbors[i]).magnitude < MAX_VECTOR_DIFF)
					{
						return true;
					}
				}
			}
		}
		
		outputString = "Hex name: " + pHexData.hexDataName.ToString() +
			" is not connected to any other Hex grids!";
		Debug.Log(outputString);
		return false;
	} // end method HasANeighbor
	
	public bool MapIsValid()
	{
		bool validMap = true;
		int[] hexNumberCount = new int[6];
		int[] hexResourceCount = new int[4];
		string outputString;
		int minResourceCount = 1000;
		int maxResourceCount = 0;
		int minNumberCount = 1000;
		int maxNumberCount = 0;

		for (int i = 0; i < hexNumberCount.Length; i++)
			hexNumberCount[i] = 0;
		for (int i = 0; i < hexResourceCount.Length; i++)
			hexResourceCount[i] = 0;

		foreach (HexDataScript hexData in hexList)
		{
			if (validMap)
			{
				if (!HasANeighbor(hexData))
				{
					validMap = false;
				}
				else if (hexData.hexDataNumber < 1 || hexData.hexDataNumber > 6)
				{
					outputString = "Hex name " + hexData.hexDataName.ToString() +
						" has an invalid Hex number: " + hexData.hexDataNumber.ToString();
					Debug.Log(outputString);
					validMap = false;
				}
				else
				{
					hexNumberCount[hexData.hexDataNumber - 1]++;
					switch (hexData.hexDataResourceType)
						{
							case ResourceTypes.BRICK:
								hexResourceCount[0]++;
								break;
							case ResourceTypes.GRAIN:
								hexResourceCount[1]++;
								break;
							case ResourceTypes.WOOD:
								hexResourceCount[2]++;
								break;
							case ResourceTypes.WOOL:
								hexResourceCount[3]++;
								break;
							default:
								outputString = "Hex name " + hexData.hexDataName.ToString() +
									" has an invalid resource type!";
								Debug.Log(outputString);
								validMap = false;
								break;
						} // end switch
				} // if (!HasANeighbor(hexData))...else...
			} // if (validMap)...
		} // foreach (HexDataScript hexData in hexList)...

		if (!validMap)
		{
			Debug.Log("This map is invalid!");
			return false;
		}

		for (int i = 0; i < hexResourceCount.Length; i++)
		{
			if (hexResourceCount[i] == 0)
			{
				switch (i)
				{
					case 0:
						outputString = "The Brick resource type is missing from the map!";
						break;
					case 1:
						outputString = "The Grain resource type is missing from the map!";
						break;
					case 2:
						outputString = "The Wood resource type is missing from the map!";
						break;
					case 3:
						outputString = "The Wool resource type is missing from the map!";
						break;
					default:
						outputString = "An unknown resource type is missing from the map!";
						break;
				} // end switch
				Debug.Log(outputString);
				Debug.Log("This map is invalid!");
				return false;
			}
			else
			{
				if (hexResourceCount[i] < minResourceCount)
					minResourceCount = hexResourceCount[i];
				if (hexResourceCount[i] > maxResourceCount)
					maxResourceCount = hexResourceCount[i];
			}
		} // end for (int i = 0; i < hexResourceCount.Length; i++)...

		if ((maxResourceCount - minResourceCount) > 1)
		{
			Debug.Log("The discrepancy between resources is too great!");
			Debug.Log("This map is invalid!");
			return false;
		}

		for (int i = 0; i < hexNumberCount.Length; i++)
		{
			if (hexNumberCount[i] < minNumberCount)
				minNumberCount = hexNumberCount[i];
			if (hexNumberCount[i] > maxNumberCount)
				maxNumberCount = hexNumberCount[i];
		}
		
		if ((maxNumberCount - minNumberCount) > 1)
		{
			Debug.Log("The discrepancy between hex numbers is too great!");
			Debug.Log("This map is invalid!");
			return false;
		}

		if (!validMap)
			Debug.Log("This map is invalid!");
		return validMap;
	} // end method MapIsValid

	private bool MapFileExists()
	{
		try
		{
			if (HelperScript.playerMapSelection != null && HelperScript.playerMapSelection.Length > 0)
				filePath = Application.dataPath + "/Resources/UGC/" +
					HelperScript.playerMapSelection.ToString() + ".txt";
			else
				filePath = Application.dataPath + "/Resources/UGC/Default.txt";
			sourceFile = new FileInfo (filePath);
			return (sourceFile.Exists);
		}
		catch (Exception e)
		{
			Debug.Log("MapDataScript.MapFileExists() threw an exception!");
			Debug.Log("Exception Message: " + e.Message);
			return false;
		}
	} // end method MapFileExists

	private bool LoadMapFile()
	{
		char[] delimiterChars = { ' ', '=' };

		try
		{
			if (!sourceFile.Exists)
			{
				return false;
			}
			if (sourceFile != null && sourceFile.Exists)
				reader = sourceFile.OpenText();
			if (reader == null)
			{
				Debug.Log ("Map stream reader is null!");
				return false;
			}
			else
			{
				inputLines = new string[100];
				int lineNumber = 0;
				int lineCount = 0;
				while (((lineNumber < 100) && (inputLines[lineNumber] = reader.ReadLine()) != null))
				{
					lineNumber++;
					lineCount++;
				}
				reader.Close();
				
				dataNumbers = new int[lineCount];
				gridLocations = new Vector2[lineCount];
				resourceTypes = new ResourceTypes[lineCount];
				for (int i = 0; i < lineCount; i++)
				{
					string[] paramArray = inputLines[i].Split(delimiterChars);
					for (int j = 0; j < paramArray.Length - 1; j = j + 2)
					{
						switch (paramArray[j])
						{
							case "DN":
								dataNumbers[i] = Convert.ToInt32(paramArray[j+1]);
								break;
							case "RT":
								switch (Convert.ToInt32(paramArray[j+1]))
								{
									case 0:
										resourceTypes[i] = ResourceTypes.GRAIN;
										break;
									case 1:
										resourceTypes[i] = ResourceTypes.WOOD;
										break;
									case 2:
										resourceTypes[i] = ResourceTypes.BRICK;
										break;
									default:
										resourceTypes[i] = ResourceTypes.WOOL;
										break;
								}
								break;
							case "GL":
								string[] GLArray = paramArray[j+1].Split(',');
								gridLocations[i] = new Vector2(Convert.ToSingle(GLArray[0]),
								                               Convert.ToSingle(GLArray[1]));
								break;
							default:
								Debug.Log ("Map file contains an invalid parameter: " + paramArray[j]);
								return false;
								break;
						}
					}
				}
			}
			return true;
		}
		catch (Exception e)
		{
			Debug.Log("MapDataScript.LoadMapFile() threw an exception!");
			Debug.Log("Exception Message: " + e.Message);
			return false;
		}
	} // end method LoadMapFile
} // end class MapDataScript
