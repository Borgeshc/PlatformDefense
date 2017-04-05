using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnpoints;
    public GameObject[] enemies;

    IEnumerator Start()
    {
        for(int i = 0; i < 100; i++)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(4);
        }
    }
}
