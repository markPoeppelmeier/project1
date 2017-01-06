using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessorSpawner : MonoBehaviour {

    //location variables
    public Transform[] spawnLocations;
    public GameObject[] processorPrefabs;
    public GameObject[] processorClones;

    void Start()
    {
        //create the dungeon
        processorClones[0] = Instantiate(processorPrefabs[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }
}
