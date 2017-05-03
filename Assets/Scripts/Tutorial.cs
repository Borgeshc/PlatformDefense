using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public Animator redDotAnim;
    public GameObject startButton;
    public GameObject tutorialEnemy1;
    public GameObject tutorialEnemy2;
    public GameObject tutorialEnemy3;
    public GameObject leftHandAnim;
    public GameObject rightHandAnim;
    public GameObject firewallHand1;
    public GameObject firewallHand2;
    public Text redDotText;
    Coroutine redDotTutorial;
    bool isTime;
    
	void Start ()
    {
        redDotTutorial = StartCoroutine(RedDotTutorial());
	}

    IEnumerator RedDotTutorial()
    {
        redDotText.text = "Place the reticle over the enemy to target him.";
        yield return new WaitForSeconds(2.5f);
        leftHandAnim.SetActive(true);
        redDotText.text = "Use the motion below with your left hand to quarentine the virus.";
        yield return new WaitForSeconds(1);
        tutorialEnemy1.SetActive(true);
    }
    public IEnumerator Enemy1Died()
    {
        leftHandAnim.SetActive(false);
        redDotText.text = "Nice!";
        yield return new WaitForSeconds(1);
        rightHandAnim.SetActive(true);
        tutorialEnemy2.SetActive(true);
        redDotText.text = "Target the new enemy and do the same motion with your right hand instead to shoot your laser.";
    }

    public IEnumerator Enemy2Died()
    {
        redDotText.text = "One last thing.";
        yield return new WaitForSeconds(1);
        rightHandAnim.SetActive(false);
        firewallHand1.SetActive(true);
        firewallHand2.SetActive(true);
        redDotText.text = "Your last ability is the Firewall. Aim your reticle at the ground to target the spot you want and raise either hand as shown in the image.";
        isTime = true;
    }

    public void FirewallActivated()
    {
        if(isTime)
        {
            firewallHand1.SetActive(false);
            firewallHand2.SetActive(false);
            redDotText.text = "Okay, you are ready!";
            StartCoroutine(StartGame());
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2);
        for(int i = 3; i > 0; i--)
        {
            redDotText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        SceneManager.LoadScene("PlatformDefense");
    }
}
