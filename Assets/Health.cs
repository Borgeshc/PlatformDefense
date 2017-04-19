using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    public float baseHealth;
    public Image healthBar;
    ScoreManager scoreManager;
    public List<GameObject> frozen;
    public bool hasHitEffect;
    public GameObject secureLockExplosion;

    Animator anim;
    public float health;
    bool hitEffect;
    bool dying;
    bool secured;

    void Start()
    {
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
            else if (transform.tag != "Enemy" && health <= baseHealth * .1f)
            {
                secureLockExplosion.SetActive(true);
                secured = true;
            }
        }
    }

    IEnumerator Died()
    {
        if(!dying)
        {
            dying = true;
            if (transform.tag == "Enemy")
            {
                if(frozen != null)
                {
                    for(int i = 0; i < frozen.Count; i++)
                    {
                        frozen[i].SetActive(false);
                    }
                }
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
}
