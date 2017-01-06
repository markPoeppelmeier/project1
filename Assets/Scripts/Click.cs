using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	public UnityEngine.UI.Text goldDisplay;
	public UnityEngine.UI.Text gpcDisplay;
	public UnityEngine.UI.Text gpsDisplay;
    public UnityEngine.UI.Text inDungeonDisplay;
    public float gold = 0.00f;
	public int goldperclick = 1;
	public int goldpersecond = 0;

    // Update is called once per frame
    void Update()
    {
        goldDisplay.text = "Gold: " + gold;
        //gpcDisplay.text = goldperclick + " gold/click";
    }
}
