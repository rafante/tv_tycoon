using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeekDayManager : MonoBehaviour
{

	public UnityEngine.UI.Button sundayBtn, mondayBtn, tuesdayBtn, wednesdayBtn, thursdayBtn, fridayBtn, saturdayBtn;

	void Start()
	{
		
	}

	public void moveToWeekDay(int day)
	{
		GameManager.main.setLookingDay(day);
		UIFunctions.main.loadLevel("dayGrid");
	}

	public void checkDayGrid(int i)
	{
		GameManager.main.setLookingDay(i);
		UIFunctions.main.loadLevel("dayGrid");
	}

}
