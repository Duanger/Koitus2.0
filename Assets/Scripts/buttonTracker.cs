using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonTracker : MonoBehaviour
{

	private Global glob;

	private void Start()
	{
		glob = GameObject.FindGameObjectWithTag("Manager").GetComponent<Global>();
	}

	public void OnButtClick()
	{
		if (gameObject.CompareTag("dickButt1"))
		{
			glob.OrangeDickChosen = true;
		}
		if (gameObject.CompareTag("dickButt2"))
		{
			glob.GreenDickChosen = true;
		}
		if (gameObject.CompareTag("vuvlButt1"))
		{
			glob.OrangeVulveChosen = true;
		}
		if (gameObject.CompareTag("vuvlButt2"))
		{
			glob.GreenVulveChosen = true;
		}
		
	}
}
