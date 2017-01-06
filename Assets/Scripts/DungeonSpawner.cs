using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour {
    
    //location variables
    public Transform[] spawnLocations;
    public GameObject[] dungeonPrefabs;
    public GameObject[] dungeonClones;
    
    void Start () {
        //create the dungeon
        dungeonClones[0] = Instantiate(dungeonPrefabs[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }
}
