using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{

	public GameObject[] objectsToPreserve;
	
	public List<BaseScreen> previousScreens;
	public List<BaseScreen> nextScreens;
	public BaseScreen mainScreen;
	public BaseScreen lastScreen;
	public BaseScreen currentScreen;
	public ScreenIndex[] allScreens;
	public Canvas gameManagerViewer;
	
	public List<IScreenHandler> subscribers;

	public static UIFunctions main;

	void Awake()
	{
		if (main == null)
		{
			main = this;
			main.init();
		}
	}

	public void init()
	{
		main.previousScreens = new List<BaseScreen>();
		main.nextScreens = new List<BaseScreen>();
		main.currentScreen = mainScreen;
		subscribers = new List<IScreenHandler>();
	}

	/*void Start()
	{
		unloadOutScreens();
	}*/

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
		notifyBegin(screenName);
		BaseScreen screen = findScreenByName(screenName);
		if(screen == currentScreen)
			return;
		lastScreen = currentScreen;
		screen.load();
		previousScreens.Add(currentScreen);
		currentScreen.unload();
		currentScreen = screen;
		notifyEnd(screenName);
	}

	public void notifyBegin(string screenName)
	{
		foreach (var subscriber in subscribers)
		{
			subscriber.beginGoToScreen(screenName);
		}
	}

	public void notifyEnd(string screenName)
	{
		foreach (var subscriber in subscribers)
		{
			subscriber.endGoToScreen(screenName);
		}
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

	public void subscribeToScreenChange(IScreenHandler handler)
	{
		if (!subscribers.Contains(handler))
		{
			subscribers.Add(handler);
		}
	}
}

[Serializable]
public class ScreenIndex
{
	public string name;
	public BaseScreen screen;
}