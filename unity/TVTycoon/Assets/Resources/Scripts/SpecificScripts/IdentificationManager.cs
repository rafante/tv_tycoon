using System;
using UnityEngine;
using UnityEngine.UI;

public class IdentificationManager : MonoBehaviour
{

	public Canvas tutorialCanvas, backgroundCanvas;
	public InputField tvNameInp;
	public Button smCityChoice, mCityChoice, lCityChoice;

	void Awake()
	{
		if (GameManager.main.getCity() > 0)
		{
			UIFunctions.main.loadLevel("gameMenu");
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		setEvents();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			tutorialCanvas.enabled = false;
			//backgroundCanvas.enabled = false;
		}
	}

	public void setEvents()
	{
		tvNameInp.onEndEdit.AddListener(setTVName);
		smCityChoice.onClick.AddListener(selectSmallCity);
		mCityChoice.onClick.AddListener(selectMediumCity);
		lCityChoice.onClick.AddListener(selectLargeCity);
	}

	public void setTVName(string name)
	{
		GameManager.main.setTVName(name);
	}

	public void selectCity(int city)
	{
		GameManager.main.installIntoCity(city);
		//UIFunctions.main.loadLevel("weekDay");
	}

	public void selectSmallCity()
	{
		selectCity(1);
	}
	
	public void selectMediumCity()
	{
		selectCity(2);
	}
	
	public void selectLargeCity()
	{
		selectCity(3);
	}
}
