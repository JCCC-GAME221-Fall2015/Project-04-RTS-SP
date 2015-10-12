// HelperScript.cs
// Author: Craig Broskow
using System;
using System.Collections;
using System.Collections.Generic;

public enum ResourceTypes
{
	GRAIN,
	WOOD,
	BRICK,
	WOOL
}

public static class HelperScript
{
	// list of map files (strings)...map/filenames
	public static List<string> mapList;
	
	// list of saved game files (strings)...game/filenames
	public static List<string> gameList;
	
	// Variables to establish player parameters (single-player for now)
	public static string gameName;
	public static string playerName;
	public static string playerMapSelection;
	public static string playerMenuSelection;
	//	public static int playerNumber;

	// Variables to enable game functions
	public static bool enableRoads;
	public static bool enableSettlements;
//	public static string playerPhase;
	
	public static void LoadMapNames()
	{
		mapList = new List<string>();
		
		mapList.Add("Awesome Map");
		mapList.Add("Difficult Map");
		mapList.Add("Mediocre Map");
		mapList.Add("Horrible Map");
	} // end method LoadMapNames
	
//	public static void LogMapNames()
//	{
//		foreach (string mapName in mapList) {
//			Debug.Log (mapName);
//		}
//	} // end method LogMapNames
	
	public static void LoadGameNames()
	{
		gameList = new List<string>();
		
		gameList.Add("GameName:'Awesome Game', PlayerName:'Player 1'");
		gameList.Add("GameName:'Difficult Game', PlayerName:'Player 2'");
		gameList.Add("GameName:'Mediocre Game', PlayerName:'Player 3'");
		gameList.Add("GameName:'Horrible Game', PlayerName:'Player 4'");
	} // end method LoadGameNames
	
//	public static void LogGameNames()
//	{
//		foreach (string gameName in gameList) {
//			Debug.Log (gameName);
//		}
//	} // end method LogGameNames
} // end class HelperScript
