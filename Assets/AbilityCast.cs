using UnityEngine;
using System.Collections;

public class AbilityCast : MonoBehaviour
{
    public GameObject firewall;
    public GameObject antivirus;
    public GameObject quarentine;

    public GameObject antivirusSpawn;
    public GameObject quarentineSpawn;
    public LayerMask layerMask;

    RaycastHit hit;
    bool casting;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 500, layerMask))
        {
            if(hit.transform.tag.Equals("Enemy") && !casting)
            {
                casting = true;
                if(AbilityManager.antiVirus)
                {
                    print("Casting Anti Virus");
                    GameObject clone = Instantiate(antivirus, antivirusSpawn.transform.localPosition, antivirusSpawn.transform.rotation) as GameObject;
                    clone.transform.position = antivirusSpawn.transform.position + transform.forward * 2;
                    clone.GetComponent<Projectile>().target = hit.transform.gameObject;

                }
                if(AbilityManager.quarentine)
                {
                    print("Casting Quarentine");
                    GameObject clone2 = Instantiate(quarentine, quarentineSpawn.transform.localPosition, quarentineSpawn.transform.rotation) as GameObject;
                    clone2.transform.position = quarentineSpawn.transform.position + transform.forward * 2;
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
        yield return new WaitForSeconds(.03f);
        casting = false;
    }
}
