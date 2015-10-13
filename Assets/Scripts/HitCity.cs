using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class HitCity : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D other)
    {
        SpawnManager.DestroyGarbageAndTakeDamage(other.gameObject);
    }
}
