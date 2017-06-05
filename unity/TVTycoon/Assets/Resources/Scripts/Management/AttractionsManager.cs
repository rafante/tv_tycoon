using System.Collections.Generic;
using UnityEngine;

public class AttractionsManager
{
    public static AttractionsManager main;
    private SortedList<int, Attraction> attractionsBuffer;
    private Attraction attractionBuffered;

    private AttractionsManager()
    {
        if(main == null)
            main = new AttractionsManager();
        attractionsBuffer = new SortedList<int, Attraction>();
        attractionBuffered = null;
    }

    public Attraction getAttraction(int attractionId)
    {
        if (attractionBuffered != null && attractionBuffered.id == attractionId)
            return attractionBuffered;
        attractionBuffered = attractionsBuffer.ContainsKey(attractionId) ? attractionsBuffer[attractionId] : null;
        return attractionBuffered;
    }

    public Sprite getImage(int attractionId)
    {
        return Resources.Load<Sprite>(getAttraction(attractionId).imagePath);
    }

    public string getName(int attractionId)
    {
        return getAttraction(attractionId).name;
    }

    public float getAudience(int attractionId)
    {
        return getAttraction(attractionId).audience;
    }

    public int getPopularity(int attractionId)
    {
        return getAttraction(attractionId).popularity;
    }

    public float getValue(int attractionId)
    {
        return getAttraction(attractionId).value;
    }
}