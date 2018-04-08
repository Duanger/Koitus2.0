using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FishAnimatorController : MonoBehaviour
{
	private Animator _fishAnim;
	//private Vector3 targetPosition;
	public float fishSwimSpeed = 0.05f;
	public float turningSpeed;
	public int CurrentSceneIndex;
	public string PlayNum;
	[HideInInspector]public bool LeftFacing;
	[HideInInspector]public bool rightFacing;
	void Start ()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			_fishAnim = GetComponent<Animator>();
			CurrentSceneIndex = 0;
			if (PlayNum == "1")
			{
			
				LeftFacing = true;
			}
			if (PlayNum == "2")
			{
			
				rightFacing = true;
				_fishAnim.SetBool("turnRight", true);
			}
		}

		if (SceneManager.GetActiveScene().buildIndex == 1)
		{
			
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (CurrentSceneIndex == 0)
		{
			IntroSwimming(fishSwimSpeed,turningSpeed,PlayNum);
		}
		
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
					_fishAnim.SetBool("turnRight", true);
					_fishAnim.SetBool("turnLeft", false);
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
					_fishAnim.SetBool("turnRight", false);
					_fishAnim.SetBool("turnLeft", true);
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
					_fishAnim.SetBool("turnLeft", true);
					_fishAnim.SetBool("turnRight", false);
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
					_fishAnim.SetBool("turnLeft", false);
					_fishAnim.SetBool("turnRight", true);
				}
			}
		}
		
	}

	void MainSwimming()
	{
		
	}
}
