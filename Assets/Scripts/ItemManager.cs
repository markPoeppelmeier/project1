﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {


	public UnityEngine.UI.Text itemInfo;
	public Click click;
	public float cost;
	public int upgradeValue;
	public int count;
	public string itemName;
	private float baseCost;
	public Color notAffordable;
	public Color affordable;

	void Start () {
		baseCost = cost;
	}

	void Update() {
		itemInfo.text = itemName + "\nCost: " + cost + "\ntickValue: " + "/s";

		if (click.gold >= cost) {
			GetComponent<Image>().color = affordable;
		}
		else {
			GetComponent<Image>().color = notAffordable;
		}
	}

	public void PurchasedItem(){
		if (click.gold >= cost) {
			click.gold -= cost;
			count += 1;
			cost = Mathf.Round (baseCost * Mathf.Pow (1.15f, count));
		}
	}	
}