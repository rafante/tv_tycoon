using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{

	public GameObject[] objectsToPreserve;
	public static UIFunctions main;

	void Awake()
	{
		if (main == null)
			main = this;
	}
	
	public void loadLevel(string sceneName)
	{
		foreach (var obj in objectsToPreserve)
		{
			DontDestroyOnLoad(obj);
		}
		
		SceneManager.LoadScene(sceneName);
	}
}
