using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttractionsManager : ManagerBase
{
    private SortedList<int, Attraction> attractionsBuffer;
    private Attraction attractionBuffered;
    public Attraction curAttraction;
    public AttractionItem attractionItemPrefab;

    public int curAttractionId = 1;

    public static AttractionsManager main;

    void Start()
    {
        if (main == null)
        {
            main = this;
            main.init();
            UIFunctions.main.subscribeToScreenChange(main);
        }
    }

    public void init()
    {
        attractionsBuffer = new SortedList<int, Attraction>();
        attractionBuffered = null;
        curAttraction = null;

        //temporary
        attractionsBuffer.Add(1,
            new Attraction(getNewAttractionId(), "Bob Esponja", GamePaths.TEXTURES + "spongebob", 3, 1, 4));
    }

    private int getNewAttractionId()
    {
        return ++curAttractionId;
    }

    /*public void addAttractionItem(AttractionItem item)
    {
        item.transform.parent = attractionsListViewer.transform;
    }*/

    public void updateAttractionsBuffer()
    {
        //TODO: store attractions in memory in case of single player and get from server if multiplayer
    }

    public Attraction getAttraction(int attractionId)
    {
        if (attractionBuffered != null && attractionBuffered.id == attractionId)
            return attractionBuffered;
        attractionBuffered = attractionsBuffer.ContainsKey(attractionId) ? attractionsBuffer[attractionId] : null;
        return attractionBuffered;
    }

    public Attraction createNew()
    {
        return new Attraction(getNewAttractionId(), "");
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

    public float getAdsValue(int attractionId)
    {
        return getAttraction(attractionId).adsValue;
    }

    public override void beginGoToScreen(string screenName)
    {
    }

    public override void endGoToScreen(string screenName)
    {
        if (screenName.Equals(Screens.ATTRACTIONS_LIST))
            AttractionsListViewer.main.init();
    }

    public Attraction[] getAll()
    {
        updateAttractionsBuffer();
        return attractionsBuffer.Values.ToArray();
    }

    public void setAttraction(Attraction attraction = null)
    {
        Attraction attr = attraction == null ? createNew() : attraction;
        if (attraction == null)
            addAttraction(attr);
        AttractionEditor.main.set(attr);
        UIFunctions.main.goToScreen(Screens.ATTRACTION);
    }

    private void addAttraction(Attraction attr)
    {
        if(!attractionsBuffer.ContainsValue(attr))
            attractionsBuffer.Add(getNewAttractionId(), attr);
    }
}