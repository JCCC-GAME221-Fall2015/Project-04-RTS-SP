using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: MapNode 
/// </summary>
public class MapNode : MonoBehaviour {
    #region Fields

    public MapNodeType type;
    public int activationNumber;
    public int resourceAmount;

    #endregion

    void Start() { }

    void Update() { }

}

public enum MapNodeType {
    Wood, Brick, Wool, Grain 
}