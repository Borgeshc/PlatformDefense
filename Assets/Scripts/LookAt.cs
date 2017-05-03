using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.LookAt(player.transform);
    }
}
