using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefineryManager : MonoBehaviour {

    public float oreValueInRefinery;
    public float bins;
    public float binSize;
    public float currentStorage;
    public float totalStorage;

    public float refinePerSec;


    public Click click;

	// Use this for initialization
	void Start () {
        bins = 1;
        binSize = 1000;
        currentStorage = 0;
        refinePerSec = 10;
        totalStorage = bins * binSize;

        StartCoroutine(AutoRefineryUpdate());
    }
	
	// Update is called once per frame
	void Update ()
    {
        totalStorage = bins * binSize;
    }

    public void oreToGold()
    {
        float oreConvertedThisSecond = Mathf.Min(oreValueInRefinery, refinePerSec);
        oreValueInRefinery -= oreConvertedThisSecond;
        oreValueInRefinery = Mathf.Max(oreValueInRefinery, 0);
        click.gold += oreConvertedThisSecond;
    }

    IEnumerator AutoRefineryUpdate()
    {
        while (true)
        {
            oreToGold();
            yield return new WaitForSeconds(1);
        }
    }
}
