using UnityEngine;
using System.Collections;

public class OnFire : MonoBehaviour
{
    public bool onFire;
    public GameObject fire;
    Health health;
    Coroutine burning;

    void Start()
    {
        health = GetComponent<Health>();
    }
    public void Burn()
    {
        if(!onFire)
        {
            onFire = true;
            fire.SetActive(true);
            burning = StartCoroutine(Burning());
        }
        else
        {
            StopCoroutine(burning);
            onFire = true;
            fire.SetActive(true);
            burning = StartCoroutine(Burning());
        }
    }

    IEnumerator Burning()
    {
        for(int i = 0; i < 5; i++)
        {
            health.TookDamage(10);
            yield return new WaitForSeconds(1);
        }
        fire.SetActive(false);
        onFire = false;
    }
}
