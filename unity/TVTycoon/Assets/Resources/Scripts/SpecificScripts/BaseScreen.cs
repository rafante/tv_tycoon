using UnityEngine;

public class BaseScreen : MonoBehaviour
{
	
	public void load()
	{
		var allCanvas = GetComponentsInChildren<Canvas>();
		foreach (Canvas canvasObj in allCanvas)
		{
			canvasObj.worldCamera = GameManager.main.activeCam;
		}
		gameObject.SetActive(true);
	}

	public void unload()
	{
		var allCanvas = GetComponentsInChildren<Canvas>();
		foreach (Canvas canvasObj in allCanvas)
		{
			canvasObj.worldCamera = GameManager.main.inactiveCam;
		}
		gameObject.SetActive(false);
	}
}
