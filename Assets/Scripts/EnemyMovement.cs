using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public GameObject Dungeon;
	public GameObject Enemy;
    
    //Enemy stats
    float speed = 10.00f;
   
    //referencing other classes

    private void Start()
    {
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, Dungeon.transform.position, step);
    }

    public void incrementUnitsInDungeon()
    {
        //Send the dead unit's info to the dungeon script.
        GameObject myObject = GameObject.Find("DungeonPanel");
        myObject.GetComponent<DungeonManager>().inDungeon += 1;
    }
    
    //collision logic
    void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.tag == "Dungeon")
        {
            GameObject myObject = GameObject.Find("EnemySpawner");
            myObject.GetComponent<EnemyManager>().enemiesInField -= 1;
            Destroy (this.gameObject);
            incrementUnitsInDungeon();
		}
	}
}