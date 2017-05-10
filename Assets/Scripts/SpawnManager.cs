using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnpoints;
    public GameObject[] enemies;
    bool spawning;
    Health playerHealth;

    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
    }

    void Update()
    {
        if(!spawning)
        {
            spawning = true;
            StartCoroutine(Spawning());
        }
    }

    IEnumerator Spawning()
    {
        if(playerHealth.health > playerHealth.health * .8f)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
        else if (playerHealth.health > playerHealth.health * .5f)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
        else if (playerHealth.health > playerHealth.health * .25f)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
        spawning = false;
    }
}
