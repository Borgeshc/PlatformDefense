using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float baseHealth;
    public Image healthBar;
    ScoreManager scoreManager;
    public List<GameObject> frozen;
    public bool hasHitEffect;
    public GameObject secureLockExplosion;
    Tutorial tutorial;

    Animator anim;
    public float health;
    bool hitEffect;
    bool dying;
    bool secured;

    void Start()
    {
        if(transform.tag == "TutorialEnemy1" || transform.tag == "TutorialEnemy2" || transform.tag == "TutorialEnemy3")
        {
           tutorial = GameObject.Find("Player").GetComponent<Tutorial>();
        }
        health = baseHealth;
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        anim = GetComponent<Animator>();
    }

    public void TookDamage(int damage)
    {
        if(!secured)
        {
            health -= damage;
            healthBar.fillAmount = health / baseHealth;

            if (hasHitEffect && !hitEffect)
            {
                hitEffect = true;
                StartCoroutine(HitEffect());
            }

            if (transform.tag == "Enemy" && health <= 0)
            {
                StartCoroutine(Died());
            }
            else if (transform.tag == "Player" && health <= baseHealth * .1f)
            {
                secureLockExplosion.SetActive(true);
                secured = true;
                StartCoroutine(WaitForSceneLoad());
            }
            else if(transform.tag == "TutorialEnemy1" && health <= 0)
            {
                print("enemy 1 died");
                StartCoroutine(tutorial.Enemy1Died());
                StartCoroutine(Died());
            }
            else if (transform.tag == "TutorialEnemy2" && health <= 0)
            {
                StartCoroutine(tutorial.Enemy2Died());
                StartCoroutine(Died());
            }
        }
    }

    IEnumerator Died()
    {
        if(!dying)
        {
            dying = true;
            if (transform.tag == "Enemy" || transform.tag == "TutorialEnemy1" || transform.tag == "TutorialEnemy2")
            {
                if(frozen != null)
                {
                    for(int i = 0; i < frozen.Count; i++)
                    {
                        frozen[i].SetActive(false);
                    }
                }
                if(scoreManager !=  null)
                scoreManager.Killed();

                anim.SetBool("HasDied", true);
                yield return new WaitForSeconds(1.5f);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator HitEffect()
    {
        anim.SetBool("WasHit", true);
        yield return new WaitForSeconds(.5f);
        anim.SetBool("WasHit", false);
        hitEffect = false;
    }

    IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(5);
        PlayerPrefs.SetInt("Score", ScoreManager.kills);
        SceneManager.LoadScene("GameOver");
    }
}
