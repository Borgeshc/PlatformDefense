using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckScore : MonoBehaviour
{
    Text score;
	void Start ()
    {
        score = GetComponent<Text>();
        score.text = "You destroyed " + PlayerPrefs.GetInt("Score") + " viruses!";

        StartCoroutine(LoadMainMenu());
	}

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(3);
        for(int i = 3; i > 0; i--)
        {
            score.text = "Returning to Main Menu in " + i;
            yield return new WaitForSeconds(1);
        }

        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(0);
    }
}
