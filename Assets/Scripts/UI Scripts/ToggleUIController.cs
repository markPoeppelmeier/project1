using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUIController : MonoBehaviour {
    public RectTransform rt;
    public Vector2 open;
    public Vector2 closed;
    public string name;
    public bool IsOpen = false;
    public GameObject[] myobject;

	void Start ()
    {
        rt = GetComponent<RectTransform>();
        open = new Vector2(-0.0f, -10.0f);
        closed = new Vector2(500.0f, -10.0f);
        name = this.gameObject.name;
    }

    public void Toggle()
    {
        if (IsOpen)
        {
            rt.anchoredPosition = closed;
            IsOpen = false;
        }
        else
        {
            rt.anchoredPosition = open;
            IsOpen = true;
        }

        myobject = GameObject.FindGameObjectsWithTag("UpgradePanel");
        foreach (GameObject a in myobject)
        {
            if (a.GetComponent<ToggleUIController>().IsOpen && a.name != name)
            {
                Debug.Log(a.name);
                a.GetComponent<RectTransform>().anchoredPosition = closed;
                a.GetComponent<ToggleUIController>().IsOpen = false;
            }
        }
    }
}
