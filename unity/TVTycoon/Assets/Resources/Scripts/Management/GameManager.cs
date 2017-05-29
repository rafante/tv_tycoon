using UnityEngine;

[RequireComponent(typeof(City))]
public class GameManager : MonoBehaviour
{
    private bool tutorialSkipped;
    private float money = 500000f;
    private float audience = 0f;
    private int popularity = 0;
    private string tvName;
    private int city;
    public static GameManager main;

    // Use this for initialization
    void Awake()
    {
        if (main == null)
            main = this;
    }

    void Start()
    {
        load();
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
}