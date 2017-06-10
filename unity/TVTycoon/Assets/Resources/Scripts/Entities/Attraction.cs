using UnityEngine;

public class Attraction
{

    public int id;
    public string name;
    public string imagePath;
    public float audience;
    public int popularity;
    public float value;

    public Attraction(int id, string name, string imagePath = GamePaths.TEXTURES + "bgtTransparent", float audience = 0f, int popularity = 0, float value = 0)
    {
        this.id = id;
        this.name = name;
        this.imagePath = imagePath;
        this.audience = audience;
        this.popularity = popularity;
        this.value = value;
    }
    
}