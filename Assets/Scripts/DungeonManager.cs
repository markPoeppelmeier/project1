using UnityEngine;
using System.Collections;

public class DungeonManager : MonoBehaviour
{
    //reference other classes
    public Click click;
    public EnemyManager enemyManager;

    //dungeon text
    public UnityEngine.UI.Text mainHudDungeonHpDisplay;
    public UnityEngine.UI.Text mainHudinDungeonDisplay;
    public UnityEngine.UI.Text dungeonViewDungeonHpDisplay;
    public UnityEngine.UI.Text dungeonViewinDungeonDisplay;
    public UnityEngine.UI.Text dungeonViewSelectedFloor;
    public UnityEngine.UI.Text dungeonViewGoldDisplay;

    //dungeon stats
    public float inDungeon = 0.00f;
    public int dungeonCapacity;
    public int baseCapacity;
    public float[] dungeonHP;
    public float baseDungeonHP;
    public float[] dungeonGold;
    public float baseDungeonGold;

    public float bossHpMultiplier;
    public float bossGoldMultiplier;
    public bool isBossLevel;

    public int selectedFloor;
    public float float_selectedFloor;
    public bool changedFloors = false;

    public float dungeonFloorHp;
    public float currentDungeonFloorHp;
    public float dungeonFloorDMG;

    public GameObject[] upgrades;

    //player's pool of unit's stats in dungeon
    public float enemyPoolHP;
    public float enemyPoolDMG;
    public float temp1;
    public float lastEnemyDMG;
    public float lastEnemyEnteredHP;

    void Start()
    {
        //Set up the dungeon stats
        dungeonHP = new float[100];
        selectedFloor = 0;
        dungeonHP[0] = 100;
        baseDungeonHP = 100;
        bossHpMultiplier = 10;
        bossGoldMultiplier = 10;
        currentDungeonFloorHp = dungeonHP[0];

        dungeonGold = new float[100];
        dungeonGold[0] = 10;
        baseDungeonGold = 10;

        baseCapacity = 10;
        dungeonCapacity = 10;

        //begin battle coroutine
        StartCoroutine(dungeonBattle());
    }

    void Update()
    {
        currentDungeonFloorHp = Mathf.Max(currentDungeonFloorHp, 0);
        //Updating Main HUD and DungeonView Dungeon UI 
        dungeonViewSelectedFloor.text = "Mine Depth : " + (selectedFloor + 1) + " m";
        mainHudDungeonHpDisplay.text = "Ore: " + Mathf.Round(currentDungeonFloorHp) + " / " + dungeonHP[selectedFloor];
        dungeonViewDungeonHpDisplay.text = "Ore Remaining: " + Mathf.Round(currentDungeonFloorHp) + " / " + dungeonHP[selectedFloor];
        mainHudinDungeonDisplay.text = "In Mine: " + inDungeon + " / " + dungeonCapacity;
        dungeonViewinDungeonDisplay.text = "In Mine: " + inDungeon + " / " + dungeonCapacity;
        dungeonViewGoldDisplay.text = "Gold: " + dungeonGold[selectedFloor];        
       
        //Update unit stats
        enemyPoolDMG = totalDmgPerSec();
        dungeonCapacity = calculateCapacityFromUpgrades();
    }

    public float totalDmgPerSec()
    {
        return inDungeon * enemyManager.enemyDMG;
    }

    public int calculateCapacityFromUpgrades()
    {
        int upgradeCAP = 0;
        upgrades = GameObject.FindGameObjectsWithTag("Upgrade");
        foreach (GameObject upgrade in upgrades)
        {
            if (upgrade.GetComponent<UpgradeManager>().itemSummary.text == "MINERS")
            {

                upgradeCAP += (upgrade.GetComponent<UpgradeManager>().count * upgrade.GetComponent<UpgradeManager>().upgradeIncCap);
            }
        }
        return (baseCapacity + upgradeCAP);
    }

    public float createNormalFloorHP()
    {
        temp1 = Mathf.Round(Mathf.Pow(1.15f, float_selectedFloor) * baseDungeonHP);
        return temp1;
    }
    public float createBossFloorHP()
    {
        temp1 = createNormalFloorHP() * bossHpMultiplier;
        return temp1;
    }
    public float createFloorGold()
    {
        temp1 = Mathf.Round(Mathf.Pow(1.15f, float_selectedFloor) * baseDungeonGold);
        return temp1;
    }
    public float calculateBossGold()
    {
        temp1 = createFloorGold() * bossGoldMultiplier;
        return temp1;
    }

    public void changeFloor(int x)
    {
        selectedFloor += x;
        float_selectedFloor = (float)selectedFloor;
        
        //Make normal floors
        if (dungeonHP[selectedFloor] == 0)
        {
            //dungeon hp values
            dungeonHP[selectedFloor] = createNormalFloorHP();
            currentDungeonFloorHp = dungeonHP[selectedFloor];

            //dungeon gold values
            dungeonGold[selectedFloor] = createFloorGold();
            isBossLevel = false;
        }

        //Make boss on 10th floor
        if ((selectedFloor + 1) % 10 == 0)
        {
            isBossLevel = true;
            dungeonHP[selectedFloor] = createBossFloorHP();
            currentDungeonFloorHp = dungeonHP[selectedFloor];
            dungeonGold[selectedFloor] = calculateBossGold();
        }
    }

    public float calculateGold()
    {
       float temp =  (dungeonGold[selectedFloor] * baseDungeonGold);
       return temp;
    }
    public void calculateStats()
    { 
        //simulate the battle
        currentDungeonFloorHp -= enemyPoolDMG;

        if (currentDungeonFloorHp <= 0)
        {
            click.gold += calculateGold();
            //dungeonNotRespawning = false;
        }
    }

    IEnumerator dungeonBattle()
    {
        while (true)
        {
            if (isBossLevel == true)
            {
                if (currentDungeonFloorHp <= 0)
                {
                    click.gold += calculateBossGold();
                    changeFloor(1);
                    isBossLevel = false;
                }
            }
            if (isBossLevel == false)
            {
                if (currentDungeonFloorHp <= 0)
                {
                    changeFloor(1);
                }
                //while the dungeon is up calculate the simuluation
            }
            if (inDungeon > 0)
            {
                calculateStats();
            }
            yield return new WaitForSeconds(1);
        }
    }
}