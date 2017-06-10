using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initializer : MonoBehaviour
{

	public List<ManagerBase> managers;
	
	// Use this for initialization
	void Awake ()
	{
		/*init();
		validateGame();
		foreach (var managerBase in managers)
		{
			UIFunctions.main.subscribeToScreenChange(managerBase);
		}*/
	}

	public void init()
	{
		managers = new List<ManagerBase>();
		loadManagers();
	}

	public void loadManagers()
	{
		managers.Add(GameManager.main);
		managers.Add(AttractionsManager.main);
	}

	public void validateGame()
	{
		UIFunctions[] uiFunctions = FindObjectsOfType<UIFunctions>();
		if (uiFunctions.Length == 0)
		{
			throw new Exception("There's no UIFunctions present in the scene");
		}else if (uiFunctions.Length > 1)
		{
			throw new Exception("There's more than one UIFunctions object in the scene and it was not supposed to happen");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
