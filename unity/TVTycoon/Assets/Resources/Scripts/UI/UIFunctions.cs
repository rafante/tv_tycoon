using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{

	public GameObject[] objectsToPreserve;
	public static UIFunctions main;
	public List<BaseScreen> previousScreens;
	public List<BaseScreen> nextScreens;
	public BaseScreen mainScreen;
	public BaseScreen lastScreen;
	public BaseScreen currentScreen;
	public ScreenIndex[] allScreens;
	public Canvas gameManagerViewer;

	void Awake()
	{
		if (main == null)
			main = this;
		previousScreens = new List<BaseScreen>();
		nextScreens = new List<BaseScreen>();
		currentScreen = mainScreen;
	}

	void Start()
	{
		unloadOutScreens();
	}

	public void unloadOutScreens()
	{
		foreach (var screenIndex in allScreens)
		{
			if(screenIndex.screen != currentScreen)
				screenIndex.screen.unload();
		}
	}
	
	public void startGameViewer()
	{
		gameManagerViewer.enabled = true;
	}

	public void resetNavigation()
	{
		previousScreens.Clear();
		previousScreens.Add(findScreenByName("gameMenu"));
		lastScreen = previousScreens[0];
	}

	public void goToScreen(string screenName)
	{
		BaseScreen screen = findScreenByName(screenName);
		if(screen == currentScreen)
			return;
		lastScreen = currentScreen;
		screen.load();
		previousScreens.Add(currentScreen);
		currentScreen.unload();
		currentScreen = screen;
	}

	public BaseScreen findScreenByName(string screenName)
	{
		foreach (var screenInd in allScreens)
		{
			if (screenInd.name.Equals(screenName))
				return screenInd.screen;
		}
		throw new Exception("Screen " + screenName + " not found");
	}

	public void goBack(int i)
	{
		if(i == 0)
			throw new Exception("Navigate can't receive parameter zero");
		if (i > previousScreens.Count)
			throw new Exception("Tried navigate through screens, but there's no screens in list");
		
		screenNavigation(i, previousScreens);
	}

	private void screenNavigation(int i, List<BaseScreen> scenes)
	{
		BaseScreen screen = scenes[scenes.Count - i];
		screen.load();
		lastScreen = currentScreen;
		lastScreen.unload();
		currentScreen = screen;
		scenes.Remove(screen);
		
	}
	
	public void loadLevel(string sceneName)
	{
		foreach (var obj in objectsToPreserve)
		{
			DontDestroyOnLoad(obj);
		}
		
		SceneManager.LoadScene(sceneName);
	}

	public void testAjax()
	{
		StartCoroutine(ajax());
		// https://tvtycoon.herokuapp.com/
	}

	IEnumerator ajax()
	{
		yield return new WaitForEndOfFrame();
		WWW www = new WWW("https://tvtycoon.herokuapp.com");
		yield return www;
		Debug.Log(www.text);
	}
}

[Serializable]
public class ScreenIndex
{
	public string name;
	public BaseScreen screen;
}