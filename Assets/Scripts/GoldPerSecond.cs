using UnityEngine;
using System.Collections;

public class GoldPerSecond : MonoBehaviour {

	public UnityEngine.UI.Text gpsDisplay;
	public Click click;
    public EnemyManager enemyManager;
	public DungeonManager dungeonManager;

    void Start(){
		StartCoroutine (AutoTick ());
	}

	void Update(){
		gpsDisplay.text = "Gold/sec: " + GetGoldPerSec ();
	}

	public float GetGoldPerSec(){
		return (dungeonManager.inDungeon * enemyManager.enemyDMG);
	}

	public void AutoGoldPerSec(){
		click.gold += GetGoldPerSec ();
	}

	IEnumerator AutoTick() {
		while (true) {
			//AutoGoldPerSec();
			yield return new WaitForSeconds(1);
		}
	}
}
