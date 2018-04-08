using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemLogic : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D item)
	{

		if (item.gameObject.tag == "Beads")
		{
			Global.me.beads = true;
			item.gameObject.SetActive(false);
			print("beads picked up");
		}
		if (item.gameObject.tag == "Cake")
		{
			Global.me.ring1 = true;
			item.gameObject.SetActive(false);
			print("cake picked up");
		}
		if (item.gameObject.tag == "Rings")
		{
			Global.me.ring2 = true;
			item.gameObject.SetActive(false);
			print("rings picked up");
		}
		if (item.gameObject.tag == "FishFood")
		{
			Global.me.fishfood = true;
			item.gameObject.SetActive(false);
			print("fishfood picked up");
		}
		if (item.gameObject.tag == "Mixtape")
		{
			Global.me.mixtape = true;
			item.gameObject.SetActive(false);
			print("mixtape picked up");
		}
		if (item.gameObject.tag == "Perfume")
		{
			Global.me.perfume = true;
			item.gameObject.SetActive(false);
			print("perfume picked up");
		}
		if (item.gameObject.tag == "WaterBottle")
		{
			Global.me.waterbottle = true;
			item.gameObject.SetActive(false);
			print("waterbottle picked up");
		}
		if (item.gameObject.tag == "Certificate")
		{
			Global.me.certificate = true;
			item.gameObject.SetActive(false);
			print("certificate picked up");
		}
	}
}
