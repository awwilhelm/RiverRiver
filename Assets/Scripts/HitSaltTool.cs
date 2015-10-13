using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class HitSaltTool : MonoBehaviour {

    private Tools toolScript;
    void Start()
    {
        toolScript = GameObject.Find("World").GetComponent<Tools>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Pollution.PollutionType.salt != other.GetComponent<Pollution>().GetPollutionType())
        {
            toolScript.TakeDamage(other.GetComponent<Pollution>().GetPollutionType());
        }
        SpawnManager.DestroyGarbage(other.gameObject);
    }
}
