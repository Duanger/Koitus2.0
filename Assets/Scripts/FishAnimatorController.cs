using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FishAnimatorController : MonoBehaviour
{
	private Animator anim;
	//private Vector3 targetPosition;
	public float fishSwimSpeed = 0.05f;
	public float turningSpeed;
	public string PlayNum;
	public bool LeftFacing;
	public bool rightFacing;
	void Start ()
	{
		anim = GetComponent<Animator>();
		if (PlayNum == "1")
		{
			
			LeftFacing = true;
		}
		if (PlayNum == "2")
		{
			
			rightFacing = true;
			anim.SetBool("turnRight", true);
		}

		//anim.SetBool("turnRight", true);


	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		IntroSwimming(fishSwimSpeed,turningSpeed,PlayNum);



	}

	void IntroSwimming(float moveSpeed, float turnSpeed, string playerNum)
	{
		if (playerNum == "1")
		{
			Vector3 targetPosition;
			if (LeftFacing)
			{
				rightFacing = false;
				targetPosition = Vector3.left * moveSpeed;
				transform.position += targetPosition;
				if (transform.position.x == -2.579994f)
				{
					rightFacing = true;
					anim.SetBool("turnRight", true);
					anim.SetBool("turnLeft", false);
				}
			}
			if (rightFacing)
			{
				LeftFacing = false;
				targetPosition = Vector3.right * moveSpeed;
				transform.position += targetPosition;
				if (transform.position.x == 2.730002f)
				{
					LeftFacing = true;
					anim.SetBool("turnRight", false);
					anim.SetBool("turnLeft", true);
				}
			}

		}

		if (playerNum == "2")
		{
			Vector3 targetPosition;
			if (rightFacing)
			{
				LeftFacing = false;
				targetPosition = Vector3.right * moveSpeed;
				transform.position += targetPosition;
				if (transform.position.x == 2.730002f)
				{
					LeftFacing = true;
					anim.SetBool("turnLeft", true);
					anim.SetBool("turnRight", false);
				}
			}

			if (LeftFacing)
			{
				rightFacing = false;
				targetPosition = Vector3.left * moveSpeed;
				transform.position += targetPosition;
				if (transform.position.x == -2.579994f)
				{
					rightFacing = true;
					anim.SetBool("turnLeft", false);
					anim.SetBool("turnRight", true);
				}
			}
		}
		
	}
}
