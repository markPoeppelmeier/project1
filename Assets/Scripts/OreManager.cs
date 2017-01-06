using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreManager : MonoBehaviour
{
    public DungeonManager dungeonManager;
    public EnemyManager enemyManager;

    public Transform[] spawnLocations;
    public GameObject[] orePrefabs;
    public GameObject[] oreClones;

    private int someParam;
    private float oreSpawnDelay;

    public void Start()
    {
        someParam = 5;
        oreSpawnDelay = Mathf.Max(Random.value * someParam, 1);
        StartCoroutine(oreSystem());
    }

    public void spawnOre()
    {
        oreClones[0] = Instantiate(orePrefabs[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    public float calcOreValue()
    {
        return dungeonManager.totalDmgPerSec();
    }

    IEnumerator oreSystem()
    {
        while (true)
        {
            if(dungeonManager.inDungeon > 0)
            {
                spawnOre();
                oreSpawnDelay = Mathf.Max(Random.value * someParam, 1);
            }
            yield return new WaitForSeconds(oreSpawnDelay);
        }
    }
}
