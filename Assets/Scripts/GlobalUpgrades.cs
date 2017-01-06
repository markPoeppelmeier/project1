using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalUpgrades : MonoBehaviour {

    public int totalUpgrades;
    public int[] tNrequired;
    public bool[] tNunlocked;

    public void Start()
    {
        tNrequired = new int[6];
        for (int i = 0; i < tNrequired.Length; i++)
        {
            tNrequired[i] = i*20;
        }

        tNunlocked = new bool[6];

        for (int i = 0; i < tNunlocked.Length; i++)
        {
            tNunlocked[i] = false;
        }
    }

    public void Update()
    {
        for (int i = 0; i < tNrequired.Length; i++)
        {
            if(totalUpgrades >= tNrequired[i])
            {
                tNunlocked[i] = true;
            }
        }
    }
}
