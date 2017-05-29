using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerViewer : MonoBehaviour
{
	public static GameManagerViewer main;
	public UnityEngine.UI.Text tvNameLbl, audienceLbl, moneyLbl, popularityLbl;

	void Awake()
	{
		if (main == null)
			main = this;	
	}

	void FixedUpdate()
	{
		audienceLbl.text = GameManager.main.getAudience().ToString();
		popularityLbl.text = GameManager.main.getPopularity().ToString();
		moneyLbl.text = GameManager.main.getMoney().ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
	}
}
