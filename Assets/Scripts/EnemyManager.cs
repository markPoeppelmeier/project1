using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public DungeonManager dungeonManager;

	public Transform[] spawnLocations;
	public GameObject[] enemyPrefabs;
	public GameObject[] enemyClones;

    public GameObject[] upgrades;
    public float unitValue = 1.00f;
    public float baseEnemyDMG;
    public float enemyDMG;
    public float enemyRate;

    public int enemiesInField;

    public UnityEngine.UI.Text capacityWarning;

    public void spawnEnemy()
    {
        
        //check to see if user is at their limit or not
        if ((dungeonManager.inDungeon + enemiesInField) < dungeonManager.dungeonCapacity)
        {
            enemyClones[0] = Instantiate(enemyPrefabs[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            enemiesInField += 1;
        }
        else
        {
            capacityWarning.text = "Upgrade your mine's capacity to add more miners";
        }
    }

    public void Start()
    {
        enemiesInField = 0;
        //set their upgrade stats
        enemyDMG = baseEnemyDMG + calculateAtkFromUpgrades();
    }

    public void Update()
    {
        calcDmg();  
    }

    public float calcDmg()
    {
        enemyDMG = baseEnemyDMG + calculateAtkFromUpgrades();
        return enemyDMG;
    }

    public float calcTotalMinerDmg()
    {
        calcDmg * total
    }

    //calculating stats
    public float calculateAtkFromUpgrades()
    {
        float upgradeATK = 0;
        upgrades = GameObject.FindGameObjectsWithTag("Upgrade");
        foreach (GameObject upgrade in upgrades)
        {
            if (upgrade.GetComponent<UpgradeManager>().itemSummary.text == "ATK")
            {
                upgradeATK += (upgrade.GetComponent<UpgradeManager>().count * upgrade.GetComponent<UpgradeManager>().upgradeIncAtk);
            }
        }
        return upgradeATK;
    }
}

