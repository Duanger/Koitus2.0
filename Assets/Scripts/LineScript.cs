using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour {
    GameObject myFish1, myFish2;
    LineRenderer myLine;
    // Use this for initialization
    void Start () {
        myFish1 = GameObject.Find("Fish1");
        myFish2 = GameObject.Find("Fish2");
        myLine = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<LineRenderer>().SetPosition(0, myFish1.transform.position);
        GetComponent<LineRenderer>().SetPosition(1, myFish2.transform.position);
        Vector3 betweenFish = myFish1.transform.position - myFish2.transform.position;
        float distance = betweenFish.magnitude;
        myLine.SetWidth(0.2f*(1-distance/8),0.2f*(1-distance/8));
     
    }
}
