using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityCast : MonoBehaviour
{
    public GameObject firewall;
    public GameObject antivirus;
    public GameObject quarentine;

    public GameObject antivirusSpawn;
    public GameObject quarentineSpawn;
    public LayerMask layerMask;

    public GameObject reticleHolder;
    public Image reticleImage; 
    bool isSelecting;
    
    Tutorial tutorial;

    RaycastHit hit;
    bool casting;

    void Start()
    {
        if(Application.loadedLevel == 1)
        tutorial = GetComponentInParent<Tutorial>();
    }

    void Update()
    {
        if (Application.loadedLevel == 1)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 500, layerMask))
            {
               
            }
            else
            {
                ResetFill();
                if(reticleHolder != null)
                reticleHolder.SetActive(false);
            }
        } 
        if (Physics.Raycast(transform.position, transform.forward, out hit, 500, layerMask))
        {
            if(hit.transform.tag.Equals("Enemy") && !casting)
            {
                casting = true;
                if(AbilityManager.antiVirus)
                {
                    GameObject clone = Instantiate(antivirus, antivirusSpawn.transform.localPosition, antivirusSpawn.transform.rotation) as GameObject;
                    clone.transform.position = antivirusSpawn.transform.position + transform.forward * 2;
                    clone.GetComponent<Projectile>().target = hit.transform.gameObject;

                }
                if(AbilityManager.quarentine)
                {
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
                    Instantiate(firewall, hit.point + Vector3.up * 2, Quaternion.identity);
                }
                StartCoroutine(GlobalCooldown());
            }
            else if(hit.transform.tag.Equals("TutorialEnemy1") && !casting)
            {
                casting = true;

                if (AbilityManager.quarentine)
                {
                    GameObject clone2 = Instantiate(quarentine, quarentineSpawn.transform.localPosition, quarentineSpawn.transform.rotation) as GameObject;
                    clone2.transform.position = quarentineSpawn.transform.position + transform.forward * 2;
                    clone2.GetComponent<Projectile>().target = hit.transform.gameObject;
                }
                StartCoroutine(GlobalCooldown());

            }
            else if ( hit.transform.tag.Equals("TutorialEnemy2") && !casting)
            {
                casting = true;

                if (AbilityManager.antiVirus)
                {
                    GameObject clone = Instantiate(antivirus, antivirusSpawn.transform.localPosition, antivirusSpawn.transform.rotation) as GameObject;
                    clone.transform.position = antivirusSpawn.transform.position + transform.forward * 2;
                    clone.GetComponent<Projectile>().target = hit.transform.gameObject;

                }
                StartCoroutine(GlobalCooldown());

            }
            else if (hit.transform.tag == "LookHere")
            {
                print("asdas");
                if (!isSelecting)
                    StartCoroutine(Selecting());

                reticleHolder.SetActive(true);
            }
            else
            {
                ResetFill();
                reticleHolder.SetActive(false);
            }
        }
    }

    IEnumerator GlobalCooldown()
    {
        yield return new WaitForSeconds(.03f);
        casting = false;
    }

    IEnumerator Selecting()
    {
        isSelecting = true;
        while (reticleImage.fillAmount < 1)
        {
            reticleImage.fillAmount += .01f;
            yield return new WaitForSeconds(.01f);
        }
        isSelecting = false;
    }

    void ResetFill()
    { 
        if(reticleImage != null)
       reticleImage.fillAmount = 0f;
    } 
}
