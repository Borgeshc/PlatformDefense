using UnityEngine;
using System.Collections;

public class AbilityCast : MonoBehaviour
{
    public GameObject firewall;
    public GameObject antivirus;
    public GameObject quarentine;

    public GameObject antivirusSpawn;
    public GameObject quarentineSpawn;

    RaycastHit hit;
    bool casting;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 500))
        {
            if(hit.transform.tag.Equals("Enemy") && !casting)
            {
                casting = true;
                if(AbilityManager.antiVirus)
                {
                    print("Casting Anti Virus");
                    GameObject clone = Instantiate(antivirus, antivirusSpawn.transform.position, Quaternion.identity) as GameObject;
                    clone.GetComponent<Projectile>().target = hit.transform.gameObject;

                }
                if(AbilityManager.quarentine)
                {
                    print("Casting Quarentine");
                    GameObject clone2 = Instantiate(quarentine, quarentineSpawn.transform.position, Quaternion.identity) as GameObject;
                    clone2.GetComponent<Projectile>().target = hit.transform.gameObject;
                }
                StartCoroutine(GlobalCooldown());
            }
            else if (hit.transform.tag.Equals("Ground") && !casting)
            {
                casting = true;
                if (AbilityManager.firewall)
                {
                    print("Casting FireWall");
                    Instantiate(firewall, hit.point + Vector3.up * 2, Quaternion.identity);
                }
                StartCoroutine(GlobalCooldown());
            }
        }
    }

    IEnumerator GlobalCooldown()
    {
        yield return new WaitForSeconds(.05f);
        casting = false;
    }
}
