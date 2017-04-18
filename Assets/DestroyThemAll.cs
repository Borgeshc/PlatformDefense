using UnityEngine;
using System.Collections;

public class DestroyThemAll : MonoBehaviour
{
	void Update ()
    {
        if(transform.localScale.x > -1500)
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(-1500, -1500, -1500), .05f * Time.deltaTime);
	    //for(int i = 0; i < 1500; i++)
     //   {
     //       yield return new WaitForSeconds(.001f);
     //       transform.localScale -= Vector3.one;
     //   }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Health>().TookDamage(200);
        }
    }
}
