using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fishMovement : MonoBehaviour
{
    public float movementSpeed;
    public float turnSpeed;
    public string fishNumInput;
    Vector3 moveForward;
    public float dashSpeed;
    bool fishCanDash=true;
    public float dashCoolDownSeconds;
	public static float countObj = 0;
	public GameObject winFuck;
	public float numBer = 40f;

	public GameObject camera;

	private Global global;
	private bool leftFacing, rightFacing;
    // Use this for initialization
    void Start()
    {
	    global = GameObject.FindGameObjectWithTag("Manager").GetComponent<Global>();
		winFuck.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (countObj >= 4)
		{
			winFuck.SetActive(true);
			Camera.main.orthographicSize = 20f;
			camera.transform.position = new Vector3(0f, 0f, -10f);
		}
		numBer -= Time.deltaTime;
		if (numBer <= 0)
		{
			global.m_gameStarted = false;
			SceneManager.LoadScene(0);
		}
				
    }
    void FixedUpdate()
    {
        MoveTowards(movementSpeed, turnSpeed, fishNumInput);
        FishDash();
        
        
    }
   void LateUpdate()
    {
       
    }


    void MoveTowards(float myMoveSpeed, float myTurnSpeed, string fishNum)
    {
        moveForward = myMoveSpeed * new Vector3(Input.GetAxis("Horizontal" + fishNum), Input.GetAxis("Vertical" + fishNum), 0);
        transform.position += moveForward * Time.deltaTime;
        
        /*if (moveForward.x > 0f)
        {
            transform.up = new Vector3(1, 0, 0);
        }
        else if (moveForward.x < 0)
        {
            transform.up = new Vector3(-1, 0, 0);
        }

        transform.up = new Vector3(transform.up.x, 0, 0);*/

      

        //transform.up = new Vector3(moveForward.normalized.x,0,0) * Time.deltaTime;

        //if(transform.up.x>0)
        //{
        //    if(moveForward.x < 0)
        //    {
        //        transform.up = new Vector3(-1, 0, 0);
        //    }
        //}
        //else if(transform.up.x<0)
        //{
        //    if(moveForward.x>0)
        //    {
        //        transform.up = new Vector3(1, 0, 0);
        //    }
        //}
       


    }
   

    void FishDash()
    {
        if(Input.GetButtonDown("Dash"+fishNumInput)&&fishCanDash)
        {
            print("dash");
           GetComponent<Rigidbody2D>().AddForce(dashSpeed*new Vector2(moveForward.x, moveForward.y), ForceMode2D.Impulse);
            fishCanDash = false;
            StartCoroutine(dashCoolDown());
            //GetComponent<Rigidbody2D>().AddForce(dashSpeed * new Vector2(1,1), ForceMode2D.Impulse);
        }
    }
    IEnumerator dashCoolDown()
    {
       
        yield return new WaitForSeconds(dashCoolDownSeconds);
        fishCanDash = true;
    }

	void OnTriggerEnter2D(Collider2D item)
    {
		print("triggerenered");
		if (item.gameObject.tag == "Fuck")
		{

		}
		else {
			item.gameObject.SetActive(false);
			countObj++;
		}



        /*if (item.gameObject.tag == "Beads")
		{
			Global.me.beads = true;
			item.gameObject.SetActive(false);
			print("beads picked up");
		}
		else if (item.gameObject.tag == "Cake")
		{
			Global.me.ring1 = true;
			item.gameObject.SetActive(false);
			print("cake picked up");
		}
		else if (item.gameObject.tag == "Rings")
		{
			Global.me.ring2 = true;
			item.gameObject.SetActive(false);
			print("rings picked up");
		}
		else if (item.gameObject.tag == "FishFood")
		{
			Global.me.fishfood = true;
			item.gameObject.SetActive(false);
			print("fishfood picked up");
		}
		else if (item.gameObject.tag == "Mixtape")
		{
			Global.me.mixtape = true;
			item.gameObject.SetActive(false);
			print("mixtape picked up");
		}
		else if (item.gameObject.tag == "Perfume")
		{
			Global.me.perfume = true;
			item.gameObject.SetActive(false);
			print("perfume picked up");
		}
		else if (item.gameObject.tag == "WaterBottle")
		{
			Global.me.waterbottle = true;
			item.gameObject.SetActive(false);
			print("waterbottle picked up");
		}
		else if (item.gameObject.tag == "Certificate")
		{
			Global.me.certificate = true;
			item.gameObject.SetActive(false);
			print("certificate picked up");
		}*/
    }
}