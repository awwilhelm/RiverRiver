using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    private static ArrayList pollutants;
    private ArrayList spawners;
    private float lastTime;
    private GameObject spawnerGameObject;
    private Spawner spawnerScript;
    public float  SPEED = 0.01f;
    //private const float SPEED = 0.01f;//0.01
    private const float CREATE_TIME = 2f;
	// Use this for initialization
	void Start () {
        pollutants = new ArrayList();
        spawners = new ArrayList();
        lastTime = -CREATE_TIME;
        spawnerGameObject = GameObject.Find("Spawner");
        spawnerScript = spawnerGameObject.GetComponent<Spawner>();
        foreach (Transform spawner in (spawnerGameObject.transform))
        {
            spawners.Add(spawner.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Mathf.Abs(Time.time - lastTime) > CREATE_TIME)
        {
            lastTime = Time.time;
            int randomSpawner = Random.Range(0, spawners.Count);
            GameObject temp = spawners[randomSpawner] as GameObject;
            if(!spawnerScript.IsThereTruckAnimation())
            {
                spawnerScript.AddGarbage(temp);
            }
        }
        if (pollutants.Count > 0)
        {
            foreach (GameObject pollutant in pollutants)
            {
                pollutant.transform.position = new Vector3(pollutant.transform.position.x, pollutant.transform.position.y - SPEED, pollutant.transform.position.z);
            }
        }
	}

    public static void AddPollutantToArray(GameObject pollutant)
    {
        pollutants.Add(pollutant);
    }

    public static ArrayList GetPollutantArray()
    {
        return pollutants;
    }

    public static void DestroyGarbage(GameObject pollutant)
    {
        pollutants.Remove(pollutant);
        Destroy(pollutant);
    }

    public static void DestroyGarbageAndTakeDamage(GameObject pollutant)
    {
        DestroyGarbage(pollutant);
        ScoreKeeping.TakeDamageVillageHealth();
    }
}
