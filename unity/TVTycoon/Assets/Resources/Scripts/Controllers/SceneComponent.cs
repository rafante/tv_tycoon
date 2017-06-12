using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneComponent : MonoBehaviour
{

	public ComponentType type;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public enum ComponentType
{
	ACTOR, FURNITURE, ITEM
}