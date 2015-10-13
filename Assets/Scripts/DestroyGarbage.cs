using UnityEngine;
using System.Collections;

public class DestroyGarbage : MonoBehaviour {

    public Sprite SaltSprite;
    public Sprite OilSprite;
    public Sprite SandSprite;
    public Sprite RockSprite;
    public Sprite LumberSprite;

    private Spawner spawnerScript;

    // Use this for initialization
    void Start ()
    {
        spawnerScript = GameObject.Find("Spawner").GetComponent<Spawner>();
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            for (int i = SpawnManager.GetPollutantArray().Count - 1; i >= 0; i--)
            {
                GameObject garbage = (SpawnManager.GetPollutantArray())[i] as GameObject;
                //TODO: change to be the current sprite
                Sprite currentSprite = GetSprite(garbage);
                float width = garbage.transform.localScale.x * (currentSprite.bounds.max.x - currentSprite.bounds.min.x);
                float height = garbage.transform.localScale.y * (currentSprite.bounds.max.y - currentSprite.bounds.min.y);
                Rect garbageRect = new Rect(garbage.transform.position.x - width / 2, garbage.transform.position.y - height / 2, width, height);

                if (garbageRect.Contains(mousePos) && CanDestroy(garbage))
                {
                    //TODO: Check if it can break down
                    spawnerScript.AddGarbageToLocation(garbage.transform.position, garbage.GetComponent<Pollution>().GetPollutionType());
                    SpawnManager.DestroyGarbage(garbage);
                }
            }
        }
    }

    private bool CanDestroy(GameObject gar)
    {
        if ((int)gar.GetComponent<Pollution>().GetPollutionType() == (int)GetComponent<Tools>().GetCurrentTool())
        {
            return true;
        }
        return false;
    }

    private Sprite GetSprite(GameObject pollutant)
    {
        if (pollutant.GetComponent<Pollution>().GetPollutionType() == Pollution.PollutionType.salt)
        {
            return SaltSprite;
        } else if (pollutant.GetComponent<Pollution>().GetPollutionType() == Pollution.PollutionType.oil)
        {
            return OilSprite;
        } else if(pollutant.GetComponent<Pollution>().GetPollutionType() == Pollution.PollutionType.sand)
        {
            return SandSprite;
        } else if (pollutant.GetComponent<Pollution>().GetPollutionType() == Pollution.PollutionType.rock)
        {
            return RockSprite;
        } else if (pollutant.GetComponent<Pollution>().GetPollutionType() == Pollution.PollutionType.lumber)
        {
            return LumberSprite;
        }
        return OilSprite;
    }
}
