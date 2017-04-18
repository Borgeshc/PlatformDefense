using UnityEngine;
using System.Collections;

public class Firewall : MonoBehaviour
{
    void Start()
    {
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
