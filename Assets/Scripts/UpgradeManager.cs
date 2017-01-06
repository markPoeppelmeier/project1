using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

	public Click click;
    public GlobalUpgrades globalUpgrades;

	public Text itemName;
    public Text itemSummary;
    public Text itemLevel;
	public Text itemPower;
	public Text itemCost;
	public float cost;

	public int count = 0;
    public int upgradeLimit;

    public float upgradeIncAtk;
    public int upgradeIncCap;
    public float upgradeIncRate;

    public int unlockCount;
    public bool isUnlocked;

    private float baseCost;
	public Color notAffordable;
	public Color affordable;

    //Upgrade bar UI stuff
    public int fillAmount;
    public Image upgradeBar;

    void Start () {
		baseCost = cost;
        isUnlocked = false;
        updateUpgradeBar();
    }

	void Update(){

        isUnlocked = checkLockStatus();

        if (itemSummary.text == "ATK")
        {
            itemLevel.text = "Lvl: " + (count) + " (" + itemSummary.text + " +" + (count * upgradeIncAtk) + ")";
        }
        if (itemSummary.text == "MINERS")
        {
            itemLevel.text = "Lvl: " + (count) + " (" + itemSummary.text + " +" + (count * upgradeIncCap) + ")";
        }
        
        itemCost.text = "Cost: " + cost;
        if(count >= upgradeLimit)
        {
            itemCost.text = "DONE";
        }

		if (click.gold >= cost && count < upgradeLimit && isUnlocked == true) {
			GetComponent<Image>().color = affordable;
		}
		else {
			GetComponent<Image>().color = notAffordable;
		}
    }

    public bool checkLockStatus()
    {
        if (globalUpgrades.totalUpgrades >= unlockCount)
        {
            isUnlocked = true;
        }
        return isUnlocked;
    }

    public void PurchasedUgrade()
    {
		if (click.gold >= cost && isUnlocked == true && count < upgradeLimit)
        {
			click.gold -= cost;
			count += 1;
			cost = Mathf.Round (baseCost * Mathf.Pow (1.15f, count));
            globalUpgrades.totalUpgrades += 1;
            updateUpgradeBar();
        }
	}

    //Upgrade bar
    public void updateUpgradeBar()
    {
        upgradeBar.fillAmount = Map(count, 0, upgradeLimit, 0, 1);
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
