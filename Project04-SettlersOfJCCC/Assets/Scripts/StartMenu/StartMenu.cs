using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour 
{
    public void NewGameMenu()
    {
        Application.LoadLevel(1);
    }

    public void LoadGameMenu()
    {
		Application.LoadLevel(2);
	}

    public void ExitGame()
    {
        Application.Quit();
    }
}
