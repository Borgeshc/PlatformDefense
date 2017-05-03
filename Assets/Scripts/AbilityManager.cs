using UnityEngine;
using System.Collections;

public class AbilityManager : MonoBehaviour
{
    public static bool antiVirus;
    public static bool quarentine;
    public static bool firewall;

    public void CastAntiVirus()
    {
        antiVirus = true;
        StartCoroutine(GlobalCooldown());
    }

    public void CastQuarentine()
    {
        quarentine = true;
        StartCoroutine(GlobalCooldown());
    }

    public void CastFireWall()
    {
        firewall = true;
        StartCoroutine(GlobalCooldown());
    }

    IEnumerator GlobalCooldown()
    {
        yield return new WaitForSeconds(.04f);
        antiVirus = false;
        quarentine = false;
        firewall = false;
    }
}
