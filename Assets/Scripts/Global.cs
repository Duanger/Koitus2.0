using UnityEngine;
using System.Collections;

public class Global : MonoBehaviourSingleton<Global> //acts almost like a bank for the global variables to be called later
{
	public static Global me;

	public bool beads = false; 
	public bool ring1 = false; 
	public bool ring2 = false; 
	public bool fishfood = false; 
	public bool mixtape = false;
	public bool perfume = false;
	public bool waterbottle = false;
	public bool certificate = false;
	public bool orangeChosen;
	public bool greenChosen;
	public bool OrangeDickChosen;
	public bool OrangeVulveChosen;
	public bool GreenDickChosen;
	public bool GreenVulveChosen;
	public bool m_gameStarted;

	private int timesLoaded = 0;
	private void Awake()
	{
		me = this; //awakens the script
		DontDestroyOnLoad(gameObject);
		

		
	}

	private void FixedUpdate()
	{
		if (OrangeDickChosen || OrangeVulveChosen)
		{
			orangeChosen = true;
		}

		if (GreenDickChosen || GreenVulveChosen)
		{
			greenChosen = true;
		}

		if (greenChosen && orangeChosen)
		{
			m_gameStarted = true;
			OrangeDickChosen = false;
			GreenDickChosen = false;
			GreenVulveChosen = false;
			OrangeVulveChosen = false;
			orangeChosen = false;
			greenChosen = false;
		}
	}
}