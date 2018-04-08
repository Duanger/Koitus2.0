using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.XR.WSA;

public class AudioManager : MonoBehaviour
{
	//audio sources for the specific parts of the track

	public GameObject item1;
	public GameObject item2;

	public AudioMixer master;
	
	public AudioSource itemTrack1;
	public AudioSource itemTrack2;
	public AudioSource drumTrack;
	
	public float volume = 0f;
	private float mixerVolScale = 0f;

	public Vector3 distanceVector;
	public Vector3 itemDistanceVector;
	public Vector3 itemDistanceVector2;

	public BoxCollider2D collider;

	public GameObject midpoint;

	private bool enteredBox = false;

	public bool colTest1;
	public bool colTest2;


	void start()
	{
		Debug.Log("ENTERED =" + enteredBox);
		mixerVolScale = -80f;
		master.SetFloat("castleVol", -80f);
		itemTrack1.mute = true;
		itemTrack2.mute = true;
		drumTrack.mute = true;
		
	}
	
	void OnTriggerEnter2D (Collider2D collision)
	{
		Debug.Log("engered");
		if (collision.gameObject.tag == "Fuck")
		{


			//master.SetFloat("castleVol", 0f);
			itemTrack1.mute = false;
			itemTrack2.mute = false;
			drumTrack.mute = false;
			
			enteredBox = true;
			play(volume);
			volume = 0.5f;
			volume--;
		}
		
		//volume = 0f;
	}


	private void Update()
	{
		Debug.Log("MIXERSCALE" + mixerVolScale);
		if (item1 == null || colTest1)
		{
			itemTrack1.volume = 0f;
		}

		if (item2 == null || colTest2)
		{
			itemTrack2.volume = 0f;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		Debug.Log("WALLCOL");
		if (collision.gameObject.tag == "Fuck")
		{
			if (enteredBox)
			{
				
				//master.SetFloat("castleVol", 0f);
				
				float distance = distanceVector.magnitude;
				drumTrack.volume = 1 / distance;
				Debug.Log("Fuck me");


				if (item1 != null || colTest1 == false)
				{
					float distance1 = itemDistanceVector.magnitude;
					itemTrack1.volume = 1 / distance1;
				}

				if (item2 != null || colTest2 == false)
				{
					float distance2 = itemDistanceVector2.magnitude;
					itemTrack2.volume = 1 / distance2;
				}

			}
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		//if (collision.gameObject.tag == "Fuck")
		//{
		volume = 0f;
		mixerVolScale -= 80;
		//master.SetFloat("castleVol", -80f);

		itemTrack1.mute = true;
		itemTrack2.mute = true;
		drumTrack.mute = true;
		
		//}
	}

	void play(float volume)
	{
		//audio.volume = volume;
		//audio.Play();
	}

	void FixedUpdate()
	{
		//track1.volume = volume;
		distanceVector = midpoint.GetComponent<Transform>().position - transform.position;
		itemDistanceVector = midpoint.GetComponent<Transform>().position - item1.transform.position;
		itemDistanceVector2 = midpoint.GetComponent<Transform>().position - item2.transform.position;
		Debug.Log(volume);
		
	}


}
