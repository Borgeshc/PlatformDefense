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
            other.GetComponent<Health>().TookDamage(50);
        }
    }
}
