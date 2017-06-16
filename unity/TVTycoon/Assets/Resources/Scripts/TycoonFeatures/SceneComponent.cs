using UnityEngine;

public class SceneComponent : MonoBehaviour
{

	public ComponentType type;
	public Canvas selMarker;
	
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