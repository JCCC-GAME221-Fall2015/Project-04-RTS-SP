using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class CreateDataScript : MonoBehaviour
{
    const float DY = 20;

    public static bool showWindow;

    string playerName = "Player name";
    Rect windowRect = new Rect(Screen.width / 2 - 150, Screen.height / 2 - 75, 300, 100);

    GameObject[] newMapButtons;

    void Awake()
    {
        showWindow = false;
    }

    public static void ShowWindow()
    {
        showWindow = true;
        foreach (GameObject mapButton in GameObject.FindGameObjectsWithTag("NewMapButton"))
        {
            mapButton.GetComponent<Button>().enabled = false;
        }
        GameObject.Find("btn_Back").GetComponent<Button>().enabled = false;
        GameObject.Find("btn_Continue").GetComponent<Button>().enabled = false;
    }

    void OnGUI()
    {
        if (showWindow)
        {
            windowRect = GUI.Window(0, windowRect, GetInfo, "Game Information");
        }
    }

    void GetInfo(int windowID)
    {
        Rect playerPrefixRect = new Rect(8, DY * 2 + 5, 108, DY);
        GUI.Label(playerPrefixRect, "Player name: ");

        Rect playerNameRect = new Rect(96, DY * 2 + 5, windowRect.width - 104, DY);
        playerName = GUI.TextField(playerNameRect, playerName);

        Rect gotoGameRect = new Rect(8, DY * 3 + 15, 96, DY);
        if(GUI.Button(gotoGameRect, "Start Game"))
        {
			if (playerName.Length > 0)
				HelperScript.playerName = playerName;
			else
				HelperScript.playerName = "Guest Player";
            Application.LoadLevel(3);
        }

        Rect backtoSelectRect = new Rect(196, DY * 3 + 15, 96, DY);
        if(GUI.Button(backtoSelectRect, "Back"))
        {
            foreach (GameObject mapButton in GameObject.FindGameObjectsWithTag("NewMapButton"))
            {
                mapButton.GetComponent<Button>().enabled = true;
            }
            GameObject.Find("btn_Back").GetComponent<Button>().enabled = true;
            showWindow = false;
        }
    }
}
