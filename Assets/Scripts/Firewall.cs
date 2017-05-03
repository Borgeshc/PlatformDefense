using UnityEngine;
using System.Collections;

public class Firewall : MonoBehaviour
{
    void Start()
    {
        if(Application.loadedLevel == 1)
        {
            GameObject.Find("Player").GetComponent<Tutorial>().FirewallActivated();
        }
        Destroy(gameObject, 6);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if(other.GetComponent<Movement>().isBomb)
            {
                other.GetComponent<Health>().TookDamage(100);
            }
            else
            other.GetComponent<OnFire>().Burn();
        }
    }
}
