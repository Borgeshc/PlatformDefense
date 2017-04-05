using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    [HideInInspector]
    public float speed;
    GameObject player;
    Animator anim;
    bool attacking;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }
	void Update ()
    {
        if(transform.position.z - player.transform.position.z > 7)
        {
            anim.SetBool("IsMoving", true);
            transform.Translate(-transform.forward * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("IsMoving", false);
            if(!attacking)
            {
                attacking = true;

                StartCoroutine(Attack());
            }
        }
	}

    IEnumerator Attack()
    {
        anim.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("IsAttacking", false);
        attacking = false;
    }
}
