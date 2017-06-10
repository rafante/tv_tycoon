using System.Collections.Generic;
using UnityEngine;

public class AttractionsManager : ManagerBase
{
    private SortedList<int, Attraction> attractionsBuffer;
    private SortedList<int, AttractionItem> attractionItems;
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
        attractionItems = new SortedList<int, AttractionItem>();
        attractionBuffered = null;
        curAttraction = null;

        //temporary
        attractionsBuffer.Add(1, new Attraction(getNewAttractionId(), "Bob Esponja", GamePaths.TEXTURES + "spongebob", 3,1,4));
    }

    private int getNewAttractionId()
    {
        return ++curAttractionId;
    }

    public void showAttractions()
    {
        AttractionsListViewer.main.clearItems();
        updateAttractionsBuffer();
        foreach (var attraction in attractionsBuffer)
        {
            AttractionItem attractionItem = Instantiate(attractionItemPrefab);
            attractionItem.set(attraction.Value);
            AttractionsListViewer.main.addAttractionItem(attractionItem);
        }
        AttractionItem addItem = Instantiate(attractionItemPrefab);
        addItem.set(null);
        addItem.btnCreate.onClick.AddListener(btnCreateAction);
        AttractionsListViewer.main.addAttractionItem(addItem);
    }

    public void btnCreateAction()
    {
        UIFunctions.main.goToScreen(Screens.ATTRACTION);
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

    public float getValue(int attractionId)
    {
        return getAttraction(attractionId).value;
    }

    public override void beginGoToScreen(string screenName)
    {
    }

    public override void endGoToScreen(string screenName)
    {
        if (!screenName.Equals(Screens.ATTRACTIONS_LIST))
            return;
        showAttractions();
    }
}