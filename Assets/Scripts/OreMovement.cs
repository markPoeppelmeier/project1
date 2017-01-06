using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMovement : MonoBehaviour {

    //Reference where the ore is
    public GameObject Refinery;
    public GameObject Ore;

    //Ore stats
    float speed = 5.00f;
    public float oreValue;
    public float tempOreValue; 
    //referencing other classes

    private void Start()
    {
        oreValue = GameObject.Find("OreSpawner").GetComponent<OreManager>().calcOreValue();
        tempOreValue = 0;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        Ore.transform.position = Vector3.MoveTowards(Ore.transform.position, Refinery.transform.position, step);
    }

    public void addOretoProcessor()
    {
        //Send the ore's info to the refinery script.
        //If there is enough room, put all of the ore in. If there is just a bit of room, put the remainer ore in. If there is no room do nothing.
        
        GameObject myObject = GameObject.Find("RefinerySpawner");
        if (myObject.GetComponent<RefineryManager>().currentStorage <= myObject.GetComponent<RefineryManager>().totalStorage)
        {
            
            tempOreValue = myObject.GetComponent<RefineryManager>().totalStorage - myObject.GetComponent<RefineryManager>().currentStorage;
           
            if (myObject.GetComponent<RefineryManager>().currentStorage + oreValue <= myObject.GetComponent<RefineryManager>().totalStorage)
            {
                tempOreValue = oreValue;
            }
        }
        myObject.GetComponent<RefineryManager>().oreValueInRefinery += tempOreValue;
    }

    //collision logic
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Refinery")
        {
            addOretoProcessor();
            Destroy(this.gameObject);
        }
    }
}
