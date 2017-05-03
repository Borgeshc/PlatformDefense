using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public GameObject frozen;
    public bool isQuarentine;
    public int damage;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        if(target != null)
        {
            transform.LookAt(target.transform);
            transform.position = transform.position + speed * Time.deltaTime * transform.forward;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" || other.tag == "TutorialEnemy1" || other.tag == "TutorialEnemy2")
        {
            if(isQuarentine)
            {
                GameObject clone = Instantiate(frozen, other.transform.position, Quaternion.identity)as GameObject;
                clone.transform.SetParent(other.transform);
                other.GetComponent<Health>().frozen.Add(clone);
                if(other.GetComponent<Movement>() != null)
                other.GetComponent<Movement>().speed -= other.GetComponent<Movement>().speed * .25f;
                other.GetComponent<Health>().TookDamage(15);

                Destroy(gameObject);
            }
            else
            {
                other.GetComponent<Health>().TookDamage(50);
                Destroy(gameObject);
            }
        }
    }
}
