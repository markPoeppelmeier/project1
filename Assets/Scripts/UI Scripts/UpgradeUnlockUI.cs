using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUnlockUI : MonoBehaviour {

    public GlobalUpgrades globalUpgrades;
    public UnityEngine.UI.Text T2UpgradeText;
    public UnityEngine.UI.Text T3UpgradeText;
    public UnityEngine.UI.Text T4UpgradeText;
    public UnityEngine.UI.Text T5UpgradeText;
    public UnityEngine.UI.Text T6UpgradeText;

    public string[] tNunlockTierDes;

    // Use this for initialization
    void Start () {
        tNunlockTierDes = new string[6];
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 1; i < globalUpgrades.tNunlocked.Length; i++)
        {       
            tNunlockTierDes[i] = "You need to unlock " + Mathf.Max((globalUpgrades.tNrequired[i] - globalUpgrades.totalUpgrades),0) + " more upgrades in order to unlock Tier " + (i+1) + ".";
        }
        T2UpgradeText.text = tNunlockTierDes[1];
        T3UpgradeText.text = tNunlockTierDes[2];
        T4UpgradeText.text = tNunlockTierDes[3];
        T5UpgradeText.text = tNunlockTierDes[4];
        T6UpgradeText.text = tNunlockTierDes[5];
    }
}
