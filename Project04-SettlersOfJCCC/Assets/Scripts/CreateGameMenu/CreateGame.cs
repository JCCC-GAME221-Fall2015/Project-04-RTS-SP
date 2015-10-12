using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class CreateGame : MonoBehaviour 
{
    public GameObject mapListScrollbar;
    public GameObject mapButtonPrefab;
    public GameObject[] mapButtonInstances;


    void Awake()
    {
        GameObject.Find("btn_Continue").GetComponent<Button>().enabled = false;
        mapListScrollbar = GameObject.Find("pnl_Content");
     
        HelperScript.LoadMapNames();

        mapButtonInstances = new GameObject[HelperScript.mapList.Count];

        for(int i = 0; i < HelperScript.mapList.Count; i++)
        {
			string mapName;

            mapButtonInstances[i] = Instantiate(mapButtonPrefab) as GameObject;
			mapButtonInstances[i].name = HelperScript.mapList[i];
			mapName = HelperScript.mapList[i];
			mapButtonInstances[i].SetActive(true);
            mapButtonInstances[i].transform.SetParent(mapListScrollbar.transform, false);
			mapButtonInstances[i].GetComponentInChildren<Text>().text = HelperScript.mapList[i] + " Map";
			mapButtonInstances[i].GetComponent<Button>().onClick.AddListener(() => SelectedLevel(mapName));
		}
    }

    public void SelectedLevel(string mapName)
    {
		HelperScript.playerMapSelection = mapName;
        GameObject.Find("btn_Continue").GetComponent<Button>().enabled = true;
    }

    public void BackToMain()
    {
        Application.LoadLevel(0);
    }

    public void InformationMenu()
    {
        CreateDataScript.ShowWindow();
    }
}
