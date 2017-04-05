using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float baseHealth;
    public Image healthBar;

    Animator anim;
    float health;
    bool hitEffect;

    void Start()
    {
        health = baseHealth;
        anim = GetComponent<Animator>();
    }

    public void TookDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health;

        if(!hitEffect)
        {
            hitEffect = true;
            StartCoroutine(HitEffect());
        }

        if(health <= 0)
        {
            StartCoroutine(Died());
        }
    }

    IEnumerator Died()
    {
        anim.SetBool("HasDied", true);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    IEnumerator HitEffect()
    {
        anim.SetBool("WasHit", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("WasHit", false);
    }
}
