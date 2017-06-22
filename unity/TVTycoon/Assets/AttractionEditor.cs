using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttractionEditor : MonoBehaviour
{
    public Attraction attraction;
    public Image image;
    public Sprite imageBuffer;
    public Text audienceTxt, popularityTxt, freshnessTxt, adsValueTxt, valueGeneratedTxt;
    public static AttractionEditor main;

    // Use this for initialization
    void Awake()
    {
        main = this;
    }

    public void init(Attraction attraction)
    {
        this.attraction = attraction;
        image.sprite = Resources.Load<Sprite>(attraction.imagePath);
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (attraction != null)
        {
//            audienceTxt.text = attraction.audience.ToString();
//            popularityTxt.text = attraction.popularity.ToString();
//            freshnessTxt.text = attraction.freshness.ToString();
//            adsValueTxt.text = attraction.adsValue.ToString();
//            valueGeneratedTxt.text = attraction.valueGenerated.ToString();
        }
    }

    public void set(Attraction attr)
    {
        init(attr);
    }
}