// GameControlScript.cs
// @author: Craig Broskow
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControlScript : MonoBehaviour {

	public GameObject hexPrefab;
	public GameObject settPrefab;
	public GameObject roadPrefab;

	private List<PlayerDataScript> playerList;
	private List<HexDataScript> hexList;
	private List<SettDataScript> settList;
	private List<RoadDataScript> roadList;

	private int currentPhase = -1; // should be 0 (minimum) through 6 (maximum)
	private string currentSubphase; // Subphase is not used in all phases of the game
	private string currentPlayer; // should be the name of one of the players in the playerList

	private bool currentPhaseDone = false;
	private bool gameOver = false;
	private PlayerUIController UIControllerScript;
	private int diceRollValue = 0; // should be 1 (minimum) through 6 (maximum)

	// Use this for initialization
	void Start () {

		currentPhaseDone = false;
		gameOver = false;
		HelperScript.enableRoads = false;  // public static variable
		HelperScript.enableSettlements = false;  // public static variable
		hexList = gameObject.GetComponent<MapDataScript>().LoadMapData();
		UIControllerScript = Camera.main.GetComponent<PlayerUIController>();

		if (hexList != null)
		{
			foreach (HexDataScript hexData in hexList)
			{
				GameObject newHex = (GameObject)Instantiate(hexPrefab, hexData.hexDataPosition, Quaternion.identity);
				newHex.name = hexData.hexDataName;
				newHex.GetComponent<HexPrefabData>().SetHexName(newHex.name);
				newHex.GetComponent<HexPrefabData>().SetHexNumber(hexData.hexDataNumber);
				newHex.GetComponent<HexPrefabData>().SetHexResourceType(hexData.hexDataResourceType);
			}
		}

		playerList = new List<PlayerDataScript>();

		PlayerDataScript tempPlayerData = new PlayerDataScript();

		if (HelperScript.playerName != null && HelperScript.playerName.Length > 0)
			tempPlayerData.playerName = HelperScript.playerName;
		else
			tempPlayerData.playerName = "Guest Player";
		tempPlayerData.playerNumber = playerList.Count + 1;
		tempPlayerData.playerColor = "Yellow"; // HelperScript.playerColor
		tempPlayerData.playerHexList = new List<HexDataScript>();
		tempPlayerData.playerPhase = "Phase0";
		playerList.Add(tempPlayerData);

		Debug.Log("Player Count: " + playerList.Count.ToString());
		foreach (PlayerDataScript playerData in playerList)
		{
			playerData.LogPlayerData();
		}

		settList = new List<SettDataScript>();
		roadList = new List<RoadDataScript>();

		currentPhase = 0;
		currentSubphase = "None";
		RunGame();
	} // end method Start
	
	public void SetGamePhase(int pGamePhase, string pSubphase)
	{
		currentPhase = pGamePhase;
		currentSubphase = pSubphase;
		RunGame();
	}

	private void RunGame()
	{
		string outputString = "";

		UIControllerScript.DisablePhaseNumbers();
		switch (currentPhase)
		{
			case 0:
				UIControllerScript.DisplayPhaseNumber(0, true);
				StartCoroutine("RunPhase0");
				break;
			case 1:
				UIControllerScript.DisplayPhaseNumber(1, true);
				StartCoroutine("RunPhase1");
				break;
			case 2:
				UIControllerScript.DisplayPhaseNumber(2, true);
				break;
			case 3:
				UIControllerScript.DisplayPhaseNumber(3, true);
				StartCoroutine("RunPhase3");
				break;
			case 4:
				UIControllerScript.DisplayPhaseNumber(4, true);
				break;
			case 5:
				UIControllerScript.DisplayPhaseNumber(5, true);
				break;
			case 6:
				UIControllerScript.DisplayPhaseNumber(6, true);
				break;
			default:
				outputString = "Game is running an unknown phase!";
				Debug.Log(outputString);
				break;
		}
	} // end method RunGame
	
	IEnumerator RunPhase0()
	{
		currentPhaseDone = false;
		HelperScript.enableRoads = true;
		HelperScript.enableSettlements = true;
		while ((roadList.Count == 0) || (settList.Count == 0))
		{
			if (roadList.Count > 0)
				HelperScript.enableRoads = false;
			if (settList.Count > 0)
				HelperScript.enableSettlements = false;
			
			yield return new WaitForSeconds(.1f);
		}
		currentPhaseDone = true;
	} // end method RunPhase0
	
	IEnumerator RunPhase1()
	{
		currentPhaseDone = false;
		UIControllerScript.EnableRollDiceButton(false);
		diceRollValue = 0;
		StartCoroutine("RunDiceRoll");
		while (diceRollValue == 0)
		{
			yield return new WaitForSeconds(.1f);
		}
		CalcNewResources(); // should be a coroutine?
		UIControllerScript.EnableRollDiceButton(true);
		currentPhaseDone = true;
	} // end method RunPhase1

	IEnumerator RunPhase3()
	{
		int currentRoadCount;
		int currentSettCount;
		
		currentPhaseDone = false;
		if (currentSubphase == "BuildRoad")
		{
			UIControllerScript.EnableBuildRoadButton(false);
			currentRoadCount = roadList.Count;
			HelperScript.enableRoads = true;
			while (roadList.Count == currentRoadCount)
			{
				if (roadList.Count > currentRoadCount)
					HelperScript.enableRoads = false;
				yield return new WaitForSeconds(.1f);
			}
			currentSubphase = "None";
		}
		else if (currentSubphase == "BuildSettlement")
		{
			UIControllerScript.EnableBuildSettlementButton(false);
			currentSettCount = settList.Count;
			HelperScript.enableSettlements = true;
			while (settList.Count == currentSettCount)
			{
				if (settList.Count > currentSettCount)
					HelperScript.enableSettlements = false;
				yield return new WaitForSeconds(.1f);
			}
			currentSubphase = "None";
		}
		gameOver = CheckForVictory();
		currentPhaseDone = true;
	} // end method RunPhase3

	IEnumerator RunDiceRoll()
	{
		int tempDiceValue = 0;

		diceRollValue = 0;
		UIControllerScript.DisplayDiceRoll(true);
		for (int i = 0; i < 40; i++)
		{
			tempDiceValue = Random.Range(1, 7); // should return a random value between 1 and 6
			UIControllerScript.DisplayDiceValue(tempDiceValue);
			yield return new WaitForSeconds(.1f);
		}
		diceRollValue = tempDiceValue;
	} // end method RunDiceRoll

	private void CalcNewResources()
	{
		bool addedResource = false;
		List<int> hexIDs = new List<int>();
		string outputString;

		if (settList.Count == 0)
			return;
		foreach (SettDataScript settData in settList)
		{
			if (settData.settDataPlayer == playerList[0].playerName)
			{
				for (int i = 0; i < 3; i++)
				{
					if (settData.settHexNeighbors[i] > 0)
					{
						hexIDs.Add(settData.settHexNeighbors[i]);
					}
				}
			}
		}

		if (hexIDs.Count == 0)
			return;
		foreach (int pHexID in hexIDs)
		{
			switch (FindHexIDResource(pHexID))
			{
				case (int)ResourceTypes.BRICK:
					playerList[0].playerBrick++;
					addedResource = true;
					break;
				case (int)ResourceTypes.GRAIN:
					playerList[0].playerGrain++;
					addedResource = true;
					break;
				case (int)ResourceTypes.WOOD:
					playerList[0].playerWood++;
					addedResource = true;
					break;
				case (int)ResourceTypes.WOOL:
					playerList[0].playerWool++;
					addedResource = true;
					break;
			} // end switch
		} // end foreach (int pHexID in hexIDs)...

		if (addedResource)
		{
			UIControllerScript.DisplayPlayerResources(playerList[0].playerGrain, playerList[0].playerWood,
			                                          playerList[0].playerBrick, playerList[0].playerWool);
		}
	} // end method CalcNewResources

	private int FindHexIDResource(int pHexID)
	{
		foreach (HexDataScript hexData in hexList)
		{
			if ((hexData.hexDataID == pHexID) && (hexData.hexDataNumber == diceRollValue))
			{
				return (int)hexData.hexDataResourceType;
			}
		}
		return -1;
	} // end method FindHexIDResource

	public void AddSettlement(string pHexPrefabName, string vertexName)
	{
		bool foundHex = false;
		bool validVertex = true;
		bool lowVertex = true;
		string outputString;
		string settlementName;
		Vector3 vertexPosition = new Vector3(-100f, 100f, 0f);
		Vector3 vertexOffset;
		SettDataScript tempSettlementData;

		settlementName = "Settlement" + (settList.Count + 1).ToString();
		switch (vertexName)
		{
			case "TopVertex":
				vertexOffset = new Vector3(0f, 0.5546875f, 0f);
				lowVertex = true;
				break;
			case "URVertex":
				vertexOffset = new Vector3(0.5f, 0.3046875f, 0f);
				lowVertex = false;
				break;
			case "LRVertex":
				vertexOffset = new Vector3(0.5f, -0.3046875f, 0f);
				lowVertex = true;
				break;
			case "BottomVertex":
				vertexOffset = new Vector3(0f, -0.5546875f, 0f);
				lowVertex = false;
				break;
			case "LLVertex":
				vertexOffset = new Vector3(-0.5f, -0.3046875f, 0f);
				lowVertex = true;
				break;
			case "ULVertex":
				vertexOffset = new Vector3(-0.5f, 0.3046875f, 0f);
				lowVertex = false;
				break;
			default:
				validVertex = false;
				vertexOffset = new Vector3(-100f, 100f, 0f);
				outputString = "GameControlScript method AddSettlement was passed " +
					"the following invalid vertex name: " + vertexName;
				Debug.Log(outputString);
				break;
		} // end switch

		if (!validVertex)
		{
			HelperScript.enableSettlements = true;
			return;
		}

		foreach (HexDataScript hexData in hexList)
		{
			if (!foundHex && hexData.hexDataName == pHexPrefabName)
			{
				Vector3 newPosition = hexData.hexDataPosition + vertexOffset;
				if (!SettPositionEmpty(newPosition))
				{
					HelperScript.enableSettlements = true;
					return;
				}
				else if (!CheckAdjacentRoad(newPosition, lowVertex))
				{
					HelperScript.enableSettlements = true;
					return;
				}
				else
				{
					GameObject newSettlement = (GameObject)Instantiate(settPrefab, newPosition,
						Quaternion.Euler(-90, 0, 0));
					newSettlement.name = settlementName;
					newSettlement.GetComponent<SettPrefabData>().SetSettName(newSettlement.name);
					newSettlement.GetComponent<SettPrefabData>().SetSettNumber(settList.Count + 1);
					newSettlement.GetComponent<SettPrefabData>().SetSettColor(playerList[0].playerColor);
					vertexPosition = newSettlement.transform.position;
					foundHex = true;
				}
			}
		}

		tempSettlementData = new SettDataScript();
		tempSettlementData.settDataName = settlementName;
		tempSettlementData.settDataNumber = settList.Count + 1;
		tempSettlementData.settDataColor = playerList[0].playerColor;
		tempSettlementData.settDataPosition = vertexPosition;
		tempSettlementData.settDataPlayer = playerList[0].playerName;
		tempSettlementData.settHexNeighbors = CalcHexNeighbors(vertexPosition, lowVertex);
		settList.Add(tempSettlementData);

		tempSettlementData.LogSettlementData();

		HelperScript.enableSettlements = false; // turn off settlement adding
	} // end method AddSettlement

	private bool SettPositionEmpty(Vector3 pNewPosition)
	{
		const float MAX_VECTOR_DIFF = 0.01f;
		string outputString;

		if (settList.Count == 0)
			return true;
		foreach (SettDataScript settData in settList)
		{
			if ((settData.settDataPosition - pNewPosition).magnitude < MAX_VECTOR_DIFF)
			{
				outputString = "Settlement position is already occupied!";
				Debug.Log(outputString);
				return false;
			}
		}
		
		return true;
	} // end method SettPositionEmpty
	
	private int[] CalcHexNeighbors(Vector3 pSettDataPosition, bool lowVertex)
	{
		const float MAX_VECTOR_DIFF = 0.01f;
		int[] tempNeighbors = new int[3];
		Vector3[] tempHexPositions = new Vector3[3];

		if (lowVertex)
		{
			tempHexPositions[0] = pSettDataPosition + new Vector3(0f, -0.5546875f, 0f);
			tempHexPositions[1] = pSettDataPosition + new Vector3(0.5f, 0.3046875f, 0f);
			tempHexPositions[2] = pSettDataPosition + new Vector3(-0.5f, 0.3046875f, 0f);
		}
		else
		{
			tempHexPositions[0] = pSettDataPosition + new Vector3(0f, 0.5546875f, 0f);
			tempHexPositions[1] = pSettDataPosition + new Vector3(0.5f, -0.3046875f, 0f);
			tempHexPositions[2] = pSettDataPosition + new Vector3(-0.5f, -0.3046875f, 0f);
		}

		for (int i = 0; i < 3; i++)
		{
			tempNeighbors[i] = 0;
			foreach (HexDataScript hexData in hexList)
			{
				if ((hexData.hexDataPosition - tempHexPositions[i]).magnitude < MAX_VECTOR_DIFF)
				{
					tempNeighbors[i] = hexData.hexDataID;
				}
			}
		}
		return tempNeighbors;
	} // end method CalcHexNeighbors

	private bool CheckAdjacentRoad(Vector3 pSettDataPosition, bool lowVertex)
	{
		const float MAX_VECTOR_DIFF = 0.01f;
		string outputString;
		Vector3[] tempRoadPositions = new Vector3[3];
		
		if (roadList.Count == 0)
		{
			outputString = "You must place a settlement next to one of your roads!";
			Debug.Log(outputString);
			return false;
		}

		if (lowVertex)
		{
			tempRoadPositions[0] = pSettDataPosition + new Vector3(0f, 0.3046877f, -0.1f);
			tempRoadPositions[1] = pSettDataPosition + new Vector3(0.25f, -0.125f, -0.1f);
			tempRoadPositions[2] = pSettDataPosition + new Vector3(-0.25f, -0.125f, -0.1f);
		}
		else
		{
			tempRoadPositions[0] = pSettDataPosition + new Vector3(0f, -0.3046877f, -0.1f);
			tempRoadPositions[1] = pSettDataPosition + new Vector3(0.25f, 0.125f, -0.1f);
			tempRoadPositions[2] = pSettDataPosition + new Vector3(-0.25f, 0.125f, -0.1f);
		}
		
		for (int i = 0; i < 3; i++)
		{
			foreach (RoadDataScript roadData in roadList)
			{
				if ((roadData.roadDataPosition - tempRoadPositions[i]).magnitude < MAX_VECTOR_DIFF)
				{
					if (roadData.roadDataPlayer == playerList[0].playerName)
						return true;
				}
			}
		}

		outputString = "You must place a settlement next to one of your roads!";
		Debug.Log(outputString);
		return false;
	} // end method CheckAdjacentRoad
	
	public void AddRoad(string pHexPrefabName, string pSideName)
	{
		bool foundHex = false;
		bool validRoad = true;
		string outputString;
		string roadName;
		Vector3 roadPosition = new Vector3(-100f, 100f, 0f);
		Vector3 roadOffset;
		float roadRotation = 0f;
		RoadDataScript tempRoadData;

		roadName = "Road" + (roadList.Count + 1).ToString();
		switch (pSideName)
		{
		case "LeftSide":
			roadOffset = new Vector3(-0.5f, 0f, -0.1f);
			roadRotation = 0f;
			break;
		case "RightSide":
			roadOffset = new Vector3(0.5f, 0f, -0.1f);
			roadRotation = 0f;
			break;
		case "ULSide":
			roadOffset = new Vector3(-0.25f, 0.4296876f, -0.1f);
			roadRotation = 120f;
			break;
		case "URSide":
			roadOffset = new Vector3(0.25f, 0.4296876f, -0.1f);
			roadRotation = 60f;
			break;
		case "LLSide":
			roadOffset = new Vector3(-0.25f, -0.4296876f, -0.1f);
			roadRotation = 60f;
			break;
		case "LRSide":
			roadOffset = new Vector3(0.25f, -0.4296876f, -0.1f);
			roadRotation = 120f;
			break;
		default:
			validRoad = false;
			roadOffset = new Vector3(-100f, 100f, 0f);
			roadRotation = 0f;
			outputString = "GameControlScript method AddRoad was passed " +
				"the following invalid side name: " + pSideName;
			Debug.Log(outputString);
			break;
		} // end switch
		
		if (!validRoad)
		{
			HelperScript.enableRoads = true;
			return;
		}
		
		foreach (HexDataScript hexData in hexList)
		{
			if (!foundHex && hexData.hexDataName == pHexPrefabName)
			{
				Vector3 newPosition = hexData.hexDataPosition + roadOffset;
				if (!RoadPositionEmpty(newPosition))
				{
					HelperScript.enableRoads = true;
					return;
				}
				else
				{
					GameObject newRoad = (GameObject)Instantiate(roadPrefab, newPosition,
					                                             Quaternion.Euler(0, 0, roadRotation));
					newRoad.name = roadName;
					newRoad.GetComponent<RoadPrefabData>().SetRoadName(newRoad.name);
					newRoad.GetComponent<RoadPrefabData>().SetRoadID(roadList.Count + 1);
					newRoad.GetComponent<RoadPrefabData>().SetRoadColor(playerList[0].playerColor);
					roadPosition = newRoad.transform.position;
					foundHex = true;
				}
			}
		}
		
		tempRoadData = new RoadDataScript();
		tempRoadData.roadDataName = roadName;
		tempRoadData.roadDataID = roadList.Count + 1;
		tempRoadData.roadDataColor = playerList[0].playerColor;
		tempRoadData.roadDataPosition = roadPosition;
		tempRoadData.roadDataPlayer = playerList[0].playerName;
		tempRoadData.roadHexNeighbors = CalcRoadHexNeighbors(roadPosition, roadRotation);
		roadList.Add(tempRoadData);
		
		tempRoadData.LogRoadData();

		HelperScript.enableRoads = false; // turn off road adding
	} // end method AddRoad

	private bool RoadPositionEmpty(Vector3 pNewPosition)
	{
		const float MAX_VECTOR_DIFF = 0.01f;
		string outputString;

		if (roadList.Count == 0)
			return true;
		foreach (RoadDataScript roadData in roadList)
		{
			if ((roadData.roadDataPosition - pNewPosition).magnitude < MAX_VECTOR_DIFF)
			{
				outputString = "Road position is already occupied!";
				Debug.Log(outputString);
				return false;
			}
		}
		
		return true;
	} // end method RoadPositionEmpty
	
	private int[] CalcRoadHexNeighbors(Vector3 pRoadDataPosition, float pRoadRotation)
	{
		const float MAX_VECTOR_DIFF = 0.01f;
		int[] tempNeighbors = new int[2];
		Vector3[] tempHexPositions = new Vector3[2];
		
		if (pRoadRotation < 30f) // value should be 0f
		{
			tempHexPositions[0] = pRoadDataPosition + new Vector3(-0.5f, 0f, 0.1f);
			tempHexPositions[1] = pRoadDataPosition + new Vector3(0.5f, 0f, 0.1f);
		}
		else if (pRoadRotation < 90f) // value should be 60f
		{
			tempHexPositions[0] = pRoadDataPosition + new Vector3(0.25f, 0.4296876f, 0.1f);
			tempHexPositions[1] = pRoadDataPosition + new Vector3(-0.25f, -0.4296876f, 0.1f);
		}
		else // value should be 120f
		{
			tempHexPositions[0] = pRoadDataPosition + new Vector3(-0.25f, 0.4296876f, 0.1f);
			tempHexPositions[1] = pRoadDataPosition + new Vector3(0.25f, -0.4296876f, 0.1f);
		}

		for (int i = 0; i < 2; i++)
		{
			tempNeighbors[i] = 0;
			foreach (HexDataScript hexData in hexList)
			{
				if ((hexData.hexDataPosition - tempHexPositions[i]).magnitude < MAX_VECTOR_DIFF)
				{
					tempNeighbors[i] = hexData.hexDataID;
				}
			}
		}
		return tempNeighbors;
	} // end method CalcRoadHexNeighbors

	// Update is called once per frame
	void Update ()
	{
		if (gameOver)
			return;
		if (currentPhaseDone)
		{
			currentPhaseDone = false;
			currentPhase++;
			RunGame();
		}
	}

	private bool CheckForVictory()
	{
		int victoryPoints;
		int currentPoints;
		string outputString;
		
		victoryPoints = (int)System.Math.Ceiling(1.25d * playerList.Count);
		currentPoints = settList.Count;

		if (currentPoints >= victoryPoints)
		{
			UIControllerScript.DisplayVictoryMessage(true);
			return true;
		}
		else
			return false;
	} // end method CheckForVictory

	private void LogMapNames()
	{
		foreach (string mapName in HelperScript.mapList)
		{
			Debug.Log (mapName);
		}
	} // end method LogMapNames
	
	private void LogGameNames()
	{
		foreach (string gameName in HelperScript.gameList)
		{
			Debug.Log (gameName);
		}
	} // end method LogGameNames
} // end class GameControlScript
