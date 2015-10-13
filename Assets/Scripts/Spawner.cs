using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject salt;
    public GameObject oil;
    public GameObject sand;
    public GameObject rock;
    public GameObject lumber;
    private SpawnManager spawnManagerScript;
    private int type;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        temp.z = 0;
        //print(temp.x + " " + temp.y);
	}

    public bool IsThereTruckAnimation()
    {
        return false;
    }

    public void AddGarbage(GameObject spawner)
    {
        float tempx = Random.Range(spawner.transform.GetComponent<SpriteRenderer>().bounds.min.x, spawner.transform.GetComponent<SpriteRenderer>().bounds.max.x);
        float tempy = Random.Range(spawner.transform.GetComponent<SpriteRenderer>().bounds.min.y, spawner.transform.GetComponent<SpriteRenderer>().bounds.max.y);
        int instantiateType = Random.Range(0, 4);
        if((Pollution.PollutionType)instantiateType == Pollution.PollutionType.salt && Random.Range(0, 4) >= 2)
        {
            instantiateType = Random.Range(0, 4);
        }
        GameObject tempInstantiate;
        switch ((Pollution.PollutionType)instantiateType)
        {
            case Pollution.PollutionType.salt:
                tempInstantiate = Instantiate(salt, new Vector3(tempx, tempy, 0), Quaternion.identity) as GameObject;
                break;
            case Pollution.PollutionType.oil:
                tempInstantiate = Instantiate(oil, new Vector3(tempx, tempy, 0), Quaternion.identity) as GameObject;
                break;
            case Pollution.PollutionType.sand:
                tempInstantiate = Instantiate(sand, new Vector3(tempx, tempy, 0), Quaternion.identity) as GameObject;
                break;
            case Pollution.PollutionType.rock:
                tempInstantiate = Instantiate(rock, new Vector3(tempx, tempy, 0), Quaternion.identity) as GameObject;
                break;
            default:
                tempInstantiate = Instantiate(lumber, new Vector3(tempx, tempy, 0), Quaternion.identity) as GameObject;
                break;
        }

        SpawnManager.AddPollutantToArray(tempInstantiate);
    }

    public void AddGarbageToLocation(Vector3 pos, Pollution.PollutionType polType)
    {
        if (polType > 0)
        {
            polType = (Pollution.PollutionType)Random.Range(-1, (int)polType);
            if (polType >= 0)
            {
                GameObject tempInstantiate;
                switch (polType)
                {
                    case Pollution.PollutionType.salt:
                        tempInstantiate = Instantiate(salt, pos, Quaternion.identity) as GameObject;
                        break;
                    case Pollution.PollutionType.oil:
                        tempInstantiate = Instantiate(oil, pos, Quaternion.identity) as GameObject;
                        break;
                    case Pollution.PollutionType.sand:
                        tempInstantiate = Instantiate(sand, pos, Quaternion.identity) as GameObject;
                        break;
                    case Pollution.PollutionType.rock:
                        tempInstantiate = Instantiate(rock, pos, Quaternion.identity) as GameObject;
                        break;
                    case Pollution.PollutionType.lumber:
                        tempInstantiate = Instantiate(lumber, pos, Quaternion.identity) as GameObject;
                        break;
                    default:
                        tempInstantiate = null;
                        break;
                }
                if (tempInstantiate)
                {
                    SpawnManager.AddPollutantToArray(tempInstantiate);
                }
            }
        }
    }

    public void SetType(int newType)
    {
        type = newType;
    }
}
