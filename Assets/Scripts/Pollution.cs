using UnityEngine;
using System;
using UnityEditor;
using System.Collections;


[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Pollution : MonoBehaviour {

	public enum PollutionType
    {
        salt,
        oil,
        sand,
        rock,
        lumber
    };

    void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
    public PollutionType pollutionType;

    public PollutionType GetPollutionType()
    {
        return pollutionType;
    }
}
