using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour {

    // Use this for initialization
    private GameObject[] textButton = new GameObject[7];
    private Color[] buttColor = new Color[3];
    private Global global;

    public GameObject FishButt1;
    public GameObject FishButt2;
    public GameObject FishButt3;
    public GameObject FishButt4;
    
	void Start ()
	{
	    global = GameObject.FindWithTag("Manager").GetComponent<Global>();
        textButton[0] = GameObject.FindGameObjectWithTag("StartButt");
        textButton[1] = GameObject.FindGameObjectWithTag("TutButt");
        textButton[2] = GameObject.FindGameObjectWithTag("ExitButt");
	    textButton[3] = FishButt1;
	    textButton[4] = FishButt2;
	    textButton[5] = FishButt3;
	    textButton[6] = FishButt4;
        buttColor[0] = textButton[0].GetComponent<Image>().color;
        buttColor[1] = textButton[1].GetComponent<Image>().color;
        buttColor[2] = textButton[2].GetComponent<Image>().color;
        for(int i = 3; i < textButton.Length; i++)
        {
           textButton[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    for(int i = 0; i < 3; i++)
	    {
	        if (textButton[i].activeSelf)
	        {
	            StartCoroutine(CheckAlpha());
	        }
	        else
	        {
	            StopAllCoroutines();
	        }
	    }

	    if (global.m_gameStarted)
	    {
	        SceneManager.LoadScene(1);
	    }
	    
        
    }

    IEnumerator CheckAlpha()
    {
        for(int i = 0; i < 3; i++)
        {
            float buttonAlpha = textButton[i].GetComponent<CanvasRenderer>().GetAlpha();
            if (buttonAlpha == 0f)
            {
                textButton[i].SetActive(false);
                for(int t = 3; t < textButton.Length; t++)
                {
                    textButton[t].SetActive(true);
                }
                Debug.Log("LOAD SCENE HERE");
            } 
        }

        yield return null;
    }
    public void onTextClick()
    {
        for (int i = 0; i < textButton.Length; i++)
        {
            if(gameObject.transform.GetChild(i).CompareTag("StartButt"))
            {
                StartCoroutine(fadingFunction());
            }
            if(gameObject.transform.GetChild(i).CompareTag("ExitButt"))
            {
                Application.Quit();
            }
            if(gameObject.transform.GetChild(i) == FishButt1)
            {
                global.OrangeDickChosen = true;
            }
            if(gameObject.transform.GetChild(i) == FishButt2)
            {
                global.OrangeVulveChosen = true;
            }
            if(gameObject.transform.GetChild(i) == FishButt3)
            {
                global.GreenDickChosen = true;
            }
            if(gameObject.transform.GetChild(i) == FishButt4)
            {
                global.GreenVulveChosen = true;
            }
        }
    }
    IEnumerator fadingFunction()
    {
        for (int i = 0; i < 3; i++)
        {
            textButton[i].GetComponent<Button>().enabled = false;
            textButton[i].GetComponent<Image>().CrossFadeAlpha(0f, 3f, false);
            textButton[i].GetComponentInChildren<Text>().CrossFadeAlpha(0f, 3f, false);
            //button[i].GetComponent<Text>().enabled = false;
            yield return null;
        }
        StopCoroutine(fadingFunction());
    }
}
