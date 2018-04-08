using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Midpoint : MonoBehaviour {

	
	public GameObject fish1, fish2;
	
// Use this for initialization
	void Start () {
		
	}
	
	
	void Update () 
	{
		Vector3 midpoint = (fish1.transform.position + fish2.transform.position) / 2f;
		transform.position = midpoint;
	}
}
