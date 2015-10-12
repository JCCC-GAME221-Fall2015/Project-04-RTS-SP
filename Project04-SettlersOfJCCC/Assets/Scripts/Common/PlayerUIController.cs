using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// @author Jake Skov & Craig Broskow
/// @desc Displays relevent resource counts to the player and creates the OnClick methods for all player interactable buttons
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
	public void DisplayPlayerResources(int pPlayerGrain, int pPlayerWood, int pPlayerBrick, int pPlayerWool)
	{
		grain = pPlayerGrain;
		wood = pPlayerWood;
		brick = pPlayerBrick;
		sheep = pPlayerWool;
	} // end method DisplayPlayerResources

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
            wood--;
            brick--;
            grain--;
            sheep--;

    }

	public void RoadOnClick()
	{
		Debug.Log("Built Road");
		wood--;
		brick--;
		
	}

	// Author: Craig Broskow
	public void RollDiceOnClick()
	{
		Debug.Log("Roll Dice");
		gameControlScript.SetGamePhase(1);
//		wood--;
//		brick--;
//		
	}
}
