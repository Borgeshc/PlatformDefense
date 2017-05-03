using UnityEngine;
using System.Collections;

public class keepactive : MonoBehaviour
{
    public GameObject objectToActivate;

	void Update ()
    {
        if (!objectToActivate.activeInHierarchy)
            objectToActivate.SetActive(true);
	}
}
