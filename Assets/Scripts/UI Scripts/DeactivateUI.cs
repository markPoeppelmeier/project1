using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeactivateUI : MonoBehaviour {

	public void deactivatePanel(){

		if (this.gameObject.name == "UpgradePanel") {
			this.gameObject.SetActive(false);
		}
		if (this.gameObject.name == "MinionPanel") {
			this.gameObject.SetActive(false);
		}
		if (this.gameObject.name == "DungeonPanel") {
			this.gameObject.SetActive(false);
		}
		if (this.gameObject.name == "ResearchPanel") {
			this.gameObject.SetActive(false);
		}
	}
}	