using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public GameObject frozen;
    public bool isQuarentine;
    public int damage;

    void Update()
    {
        if(target != null)
        {
            transform.LookAt(target.transform);
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if(isQuarentine)
            {
                GameObject clone = Instantiate(frozen, other.transform.position, Quaternion.identity)as GameObject;
                clone.transform.SetParent(other.transform);
                other.GetComponent<Movement>().speed -= other.GetComponent<Movement>().speed * .25f;
                other.GetComponent<Health>().TookDamage(15);

                Destroy(gameObject);
            }
            else
            {
                other.GetComponent<Health>().TookDamage(25);
                Destroy(gameObject);
            }
        }
    }
}
