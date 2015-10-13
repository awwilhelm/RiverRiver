using UnityEngine;
using System.Linq;
using System.Collections;

public class Tools : MonoBehaviour {

    public enum ToolType
    {
        brush,
        strainer,
        hammer,
        hatchet
    };

    public GameObject saltToolGameObject;

    private ToolType currentTool;
    private bool saltToolUsed;
    private bool saltToolActivated;
    private bool saltCurrentlyTurnedOff;
    public int saltHealth;

    private const float DEATH_TIMER = 5;
    private const int STARTING_HEALTH = 5;

    void Start ()
    {
        currentTool = ToolType.brush;
        saltToolUsed = false;
        saltToolActivated = false;
        saltHealth = STARTING_HEALTH;
        saltCurrentlyTurnedOff = false;
    }

    void Update()
    {
        if (!saltCurrentlyTurnedOff)
        {
            if (Input.GetAxisRaw("SaltTool") != 0 && !saltToolUsed)
            {
                saltToolUsed = true;
                ToggleSaltTool();
            }
            if (Input.GetAxisRaw("SaltTool") == 0)
            {
                saltToolUsed = false;
            }
        }
    }
	
    public ToolType GetCurrentTool()
    {
        return currentTool;
    }

    public void SetCurrentTool(int newTool)
    {
        currentTool = (ToolType)newTool;
    }

    private void ToggleSaltTool()
    {
        saltToolActivated = saltToolActivated ? false : true;
        saltToolGameObject.SetActive(saltToolActivated);
    }

    public void TakeDamage(Pollution.PollutionType type)
    {
        switch(type)
        {
            case Pollution.PollutionType.oil:
                saltHealth -= 1;
                break;
            case Pollution.PollutionType.sand:
                saltHealth -= 2;
                break;
            case Pollution.PollutionType.rock:
                saltHealth -= 3;
                break;
            case Pollution.PollutionType.lumber:
                saltHealth -= 4;
                break;
        }

        if(saltHealth <= 0)
        {
            saltHealth = 0;
            StartCoroutine(TurnOffSalt());
        }
    }

    private IEnumerator TurnOffSalt()
    {
        saltToolGameObject.SetActive(false);
        saltCurrentlyTurnedOff = true;

        yield return new WaitForSeconds(DEATH_TIMER);

        saltHealth = STARTING_HEALTH;

        saltToolGameObject.SetActive(true);
        saltCurrentlyTurnedOff = false;
    }
}
