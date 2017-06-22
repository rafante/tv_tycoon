using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Clock))]
public class GameManager : ManagerBase
{
    private bool tutorialSkipped;
    private float money = 500000f;
    private float audience = 0f;
    private int popularity = 0;
    private int curDay = 0;
    private string tvName = "";
    private int city;
    public Camera activeCam, inactiveCam;
    public static GameManager main;

    void Start()
    {
        if (main == null)
        {
            main = this;
            main.init();
            UIFunctions.main.subscribeToScreenChange(main);
            UIFunctions.main.unloadOutScreens();
            City city1 = City.createCity("Teste1", CityType.LARGE, "teste");
            City city2 = City.createCity("Teste2", CityType.MEDIUM, "teste2");
            City city3 = City.createCity("Teste3", CityType.SMALL, "teste3");
        }  
    }

    public void teste()
    {
        
    }
    
    public void init()
    {
        activeCam = GameObject.FindGameObjectWithTag("ActiveCam").GetComponent<Camera>();
        inactiveCam = GameObject.FindGameObjectWithTag("InactiveCam").GetComponent<Camera>();
    }

    void OnDestroy()
    {
        save();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setTVName(string tvName)
    {
        Debug.Log(tvName);
        this.tvName = tvName;
    }

    public bool earnMoney(float amount)
    {
        money += amount;
        return true;
    }

    public bool spend(float amount)
    {
        if (amount > money)
            return false;
        money -= amount;
        return true;
    }

    public void looseMoney(float amount)
    {
        money -= amount;
    }

    public void changePopularity(int amount)
    {
        popularity += amount;
        if (popularity >= 10)
            popularity = 10;
        if (popularity <= -10)
            popularity = -10;
    }

    public void changeAudience(float amount)
    {
        audience += amount;
        if (audience >= 100)
            audience = 100;
        if (audience < 0)
            audience = 0;
    }

    public void setCity(int i)
    {
        city = i;
    }

    public string getTVName()
    {
        return tvName;
    }

    public int getCity()
    {
        return city;
    }

    public bool getTutorialSkipped()
    {
        return tutorialSkipped;
    }

    public float getMoney()
    {
        return money;
    }

    public int getPopularity()
    {
        return popularity;
    }

    public float getAudience()
    {
        return audience;
    }

    public void save()
    {
        PlayerPrefs.SetInt("tutorialSkipped", tutorialSkipped ? 1 : 0);
        PlayerPrefs.SetFloat("money", money);
        PlayerPrefs.SetFloat("audience", audience);
        PlayerPrefs.SetInt("popularity", popularity);
        PlayerPrefs.SetInt("city", city);
        PlayerPrefs.SetString("tvName", tvName);
        PlayerPrefs.Save();
    }

    public void load()
    {
        tutorialSkipped = PlayerPrefs.GetInt("tutorialSkipped") == 1;
        money = PlayerPrefs.GetFloat("money");
        audience = PlayerPrefs.GetFloat("audience");
        popularity = PlayerPrefs.GetInt("popularity");
        city = PlayerPrefs.GetInt("city");
        tvName = PlayerPrefs.GetString("tvName");
    }

    public void installIntoCity(int i)
    {
        float installCost = City.get(i).installationCost;
        spend(installCost);
    }

    public void setLookingDay(int day)
    {
        curDay = day;
    }

    public override void beginGoToScreen(string screenName)
    {
        
    }

    public override void endGoToScreen(string screenName)
    {
        
    }
}