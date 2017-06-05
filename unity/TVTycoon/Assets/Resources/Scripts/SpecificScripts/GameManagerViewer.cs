using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerViewer : MonoBehaviour
{
	public static GameManagerViewer main;
	public static Scene currentScene;
	public static Scene lastScene;
	public Text tvNameLbl, audienceLbl, moneyLbl, popularityLbl;
	public Button backButton;

	void Awake()
	{
		if (main == null)
			main = this;
//		currentScene = SceneManager.GetActiveScene();
		backButton.onClick.AddListener(backLevel);
	}

	void FixedUpdate()
	{
		tvNameLbl.text = GameManager.main.getTVName();
		audienceLbl.text = GameManager.main.getAudience().ToString();
		popularityLbl.text = GameManager.main.getPopularity().ToString();
		moneyLbl.text = GameManager.main.getMoney().ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
	}

	void OnDestroy()
	{
		lastScene = currentScene;
	}

	public void backLevel()
	{
		
	}
}
