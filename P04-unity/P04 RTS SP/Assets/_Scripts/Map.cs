using UnityEngine;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: Map 
/// </summary>
public class Map : MonoBehaviour {
    #region Fields

    MapNode[] nodes = new MapNode[19];

    #endregion

    void Start() {}

    void Update() {}

    public void LoadMap(string levelName = "default") {
        if (levelName != "default") {
            //load level at path from string name
        } else {
            //load default level
        }
    }

    MapNode[] ParseNodes(string name) {
        List<MapNode> nodes = new List<MapNode>();
        string path;
        if (name != "default") {
            path = Application.dataPath + "/save_data/" + name + ".txt";
        } else {
            path = Application.dataPath + "/resources/default.txt";
        }
        using (StreamReader sr = new StreamReader(path)) {
                //parsing code
        }
        
        return nodes.ToArray();
    }
}