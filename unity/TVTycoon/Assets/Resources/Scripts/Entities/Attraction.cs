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
    public AttractionType type = AttractionType.NEWSPAPER;

    public Attraction(int id, string name, string imagePath = GamePaths.TEXTURES + "bgtTransparent",
        float audience = 0f, int popularity = 0, int freshness = 0, float adsValue = 0, float valueGenerated = 0)
    {
        this.id = id;
        this.name = name;
        this.imagePath = imagePath;
        this.audience = audience;
        this.popularity = popularity;
        this.freshness = freshness;
        this.adsValue = adsValue;
        this.valueGenerated = valueGenerated;
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