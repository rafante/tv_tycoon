using UnityEngine;

public class BaseScreen : MonoBehaviour
{
	
	public void load()
	{
		var allCanvas = GetComponentsInChildren<Canvas>();
		var cam = GameManager.main != null
			? GameManager.main.activeCam
			: GameObject.FindGameObjectWithTag("ActiveCam").GetComponent<Camera>();
		foreach (Canvas canvasObj in allCanvas)
		{
			canvasObj.worldCamera = GameManager.main.activeCam;
			canvasObj.enabled = true;
		}
		//gameObject.SetActive(true);
	}

	public void unload()
	{
		var allCanvas = GetComponentsInChildren<Canvas>();
		var cam = GameManager.main != null
			? GameManager.main.activeCam
			: GameObject.FindGameObjectWithTag("InactiveCam").GetComponent<Camera>();
		foreach (Canvas canvasObj in allCanvas)
		{
			canvasObj.worldCamera = GameManager.main.inactiveCam;
			canvasObj.enabled = false;
		}
		//gameObject.SetActive(false);
	}
}
