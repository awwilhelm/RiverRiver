using UnityEngine;
using System.Collections;

public class ScoreKeeping : MonoBehaviour {

    private static int villageHealth;

	// Use this for initialization
	void Start ()
    {
        villageHealth = 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static int GetVillageHealth()
    {
        return villageHealth;
    }

    public static void TakeDamageVillageHealth()
    {
        villageHealth--;
    }
}
