using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckScore : MonoBehaviour
{
    
	void Start ()
    {
        GetComponent<Text>().text = "You destroyed " + PlayerPrefs.GetInt("Score") + " viruses!";
	}
}
