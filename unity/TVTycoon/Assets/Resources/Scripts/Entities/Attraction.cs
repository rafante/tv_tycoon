using System.Collections.Generic;
using UnityEngine;

public class Attraction
{
    public int id;
    public string name;
    public string imagePath;
    public float audience;
    public int popularity;
    public int freshness;
    public float adsValue;
    public float valueGenerated;
    public int blocks;
    public AttractionType type;
    public List<AttractionChapter> chapters;

    public Attraction(int id, string name, AttractionType type, string imagePath = GamePaths.TEXTURES + "bgtTransparent",
        float audience = 0f, int popularity = 0, int freshness = 0, float adsValue = 0, float valueGenerated = 0)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.imagePath = imagePath;
        this.audience = audience;
        this.popularity = popularity;
        this.freshness = freshness;
        this.adsValue = adsValue;
        this.valueGenerated = valueGenerated;
        this.chapters = new List<AttractionChapter>();
    }

    public Sprite getImageBuffer()
    {
        return null;
    }
    
}

public enum AttractionType
{
    NEWSPAPER,
    TALK_SHOW,
    SOAP_OPERA,
    MOVIE,
    CARTOON
}