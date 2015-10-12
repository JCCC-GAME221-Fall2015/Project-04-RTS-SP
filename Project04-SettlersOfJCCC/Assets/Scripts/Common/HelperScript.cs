// HelperScript.cs
// @author: Craig Broskow
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

	// Variables to enable game functions
	public static bool enableRoads;
	public static bool enableSettlements;

	public static void LoadMapNames()
	{
		mapList = new List<string>();
		
		mapList.Add("Default");
		mapList.Add("Ring");
		mapList.Add("TopHeavy");
		mapList.Add("BottomHeavy");
	} // end method LoadMapNames
	
	public static void LoadGameNames()
	{
		gameList = new List<string>();
		
		gameList.Add("GameName:'Awesome Game', PlayerName:'Player 1'");
		gameList.Add("GameName:'Difficult Game', PlayerName:'Player 2'");
		gameList.Add("GameName:'Mediocre Game', PlayerName:'Player 3'");
		gameList.Add("GameName:'Horrible Game', PlayerName:'Player 4'");
	} // end method LoadGameNames
} // end class HelperScript
