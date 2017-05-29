using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialChecker : MonoBehaviour
{

	public UnityEngine.UI.Button yesBtn;
	public UnityEngine.UI.Button noBtn;
	
	// Use this for initialization
	void Start () {
		if (GameManager.main.getTutorialSkipped())
		{
			UIFunctions.main.loadLevel("gameMenu");
			return;
		}
		yesBtn.onClick.AddListener(yesAction);
	}

	public void yesAction()
	{
		UIFunctions.main.loadLevel("identification");
	}
}
