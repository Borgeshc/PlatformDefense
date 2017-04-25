using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text killCounter;
    public static int kills;

    public void Killed()
    {
        kills++;
        killCounter.text = kills.ToString();
    }
}
