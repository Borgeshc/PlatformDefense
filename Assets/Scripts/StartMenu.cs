using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Image circle;
    RaycastHit hit;

	void Update ()
    {
	    if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2000))
        {
            if(hit.transform.tag == "LookHere")
            {
                print("Hit button");
                StartCoroutine(Fill());
            }
            else
            {
                ResetFill();
            }
        }
	}

    IEnumerator Fill()
    {
        while (circle.fillAmount < 1)
        {
            circle.fillAmount += .01f * Time.deltaTime;
            yield return new WaitForSeconds(.001f);
        }

        if(circle.fillAmount == 1)
        {
            SceneManager.LoadScene(1);
        }
    }

    void ResetFill()
    {
        circle.fillAmount = 0f;
    }
}
