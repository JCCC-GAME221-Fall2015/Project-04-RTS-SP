using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// @author Jake Skov
/// @desc 
/// </summary>
public class PlayerUIController : MonoBehaviour 
{
    public Text woodAmount;
    public Text brickAmount;
    public Text grainAmount;
    public Text sheepAmount;

    public int wood, brick, grain, sheep;

	public Button rollDice;
	public Button buildSettlement;
	public Button buildRoad;
	public Text diceText;
	public Text victoryText;
	public Text lossText;
	public Text Phase0;
	public Text Phase1;
	public Text Phase2;
	public Text Phase3;
	public Text Phase4;
	public Text Phase5;
	public Text Phase6;

	private GameObject diceRollPanel;
	private GameControlScript gameControlScript;

    void Awake()
    {
        //Sets the buttons to noninteractable
		rollDice.interactable = false;
		buildSettlement.interactable = false;
		buildRoad.interactable = false;
    }

	// Author: Craig Broskow
	// Use this for initialization
	void Start()
	{
		gameControlScript = GameObject.FindGameObjectWithTag("GameControllerObject").GetComponent<GameControlScript>();
		diceRollPanel = GameObject.Find("DiceRollPanel");
		DisplayDiceRoll(false);
		DisplayVictoryMessage(false);
		DisplayLossMessage(false);
		DisablePhaseNumbers();
	}
	
	// Update is called once per frame
	void Update () 
    {
        UpdateUI();
        TestBuildables();
	}

    //Displays the players resources 
    void UpdateUI()
    {
        woodAmount.text = wood.ToString();
        brickAmount.text = brick.ToString();
        grainAmount.text = grain.ToString();
        sheepAmount.text = sheep.ToString();
    }

	// Author: Craig Broskow
	public void DisplayDiceRoll(bool displayOn)
	{
		diceRollPanel.SetActive(displayOn);
	}
	
	// Author: Craig Broskow
	public void DisplayDiceValue(int diceValue)
	{
		diceText.text = diceValue.ToString();
	}
	
	// Author: Craig Broskow
	public void DisplayVictoryMessage(bool displayOn)
	{
		victoryText.enabled = displayOn;
	}

	// Author: Craig Broskow
	public void DisplayLossMessage(bool displayOn)
	{
		lossText.enabled = displayOn;
	}
	
	// Author: Craig Broskow
	public void DisplayPhaseNumber(int phaseNumber, bool displayOn)
	{
		switch (phaseNumber)
		{
			case 0:
				Phase0.enabled = displayOn;
				break;
			case 1:
				Phase1.enabled = displayOn;
				break;
			case 2:
				Phase2.enabled = displayOn;
				break;
			case 3:
				Phase3.enabled = displayOn;
				break;
			case 4:
				Phase4.enabled = displayOn;
				break;
			case 5:
				Phase5.enabled = displayOn;
				break;
			case 6:
				Phase6.enabled = displayOn;
				break;
		}
	} // end method DisplayPhaseNumber
	
	// Author: Craig Broskow
	public void DisablePhaseNumbers()
	{
		for (int i = 0; i <= 6; i++)
		{
			DisplayPhaseNumber(i, false);
		}
	}

	// Author: Craig Broskow
	public void DisplayPlayerResources(int pPlayerGrain, int pPlayerWood, int pPlayerBrick, int pPlayerWool)
	{
		grain = pPlayerGrain;
		wood = pPlayerWood;
		brick = pPlayerBrick;
		sheep = pPlayerWool;
	} // end method DisplayPlayerResources

	// Author: Craig Broskow
	public void EnableBuildSettlementButton(bool buttonOn)
	{
		buildSettlement.interactable = buttonOn;
	}
	
	// Author: Craig Broskow
	public void EnableBuildRoadButton(bool buttonOn)
	{
		buildRoad.interactable = buttonOn;
	}
	
	// Author: Craig Broskow
	public void EnableRollDiceButton(bool buttonOn)
	{
		rollDice.interactable = buttonOn;
	}
	
	void TestBuildables()
    {
        if (wood > 0 && brick > 0)
        {
            buildRoad.interactable = true;
        }
        else
        {
            buildRoad.interactable = false;
        }

        if (wood > 0 && brick > 0 && grain > 0 && sheep > 0)
        {
            buildSettlement.interactable = true;
        }
        else
        {
            buildSettlement.interactable = false;
        }
    }

    public void SettlementOnClick()
    {
            Debug.Log("Built Settlement");
			gameControlScript.SetGamePhase(3, "BuildSettlement");
			wood--;
            brick--;
            grain--;
            sheep--;
    }

	public void RoadOnClick()
	{
		Debug.Log("Built Road");
		gameControlScript.SetGamePhase(3, "BuildRoad");
		wood--;
		brick--;
	}

	// Author: Craig Broskow
	public void RollDiceOnClick()
	{
		Debug.Log("Roll Dice");
		gameControlScript.SetGamePhase(1, "None");
	}
	
	// Author: Craig Broskow
	public void QuitGame ()
	{
		Application.Quit();
		Debug.Log("Quit button clicked!");
	}
} // end class PlayerUIController
