using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class AttractionsListViewer : MonoBehaviour
{
    public AttractionItem attractionItemPrefab;
    public static AttractionsListViewer main;

    void Awake()
    {
        main = this;
    }

    public void init()
    {
        showAttractions();
    }

    public void showAttractions()
    {
        Attraction[] attractions = AttractionsManager.main.getAll();
        clearItems();

        foreach (var attraction in attractions)
        {
            AttractionItem attractionItem = Instantiate(attractionItemPrefab);
            attractionItem.set(attraction);
            attractionItem.btnAttraction.onClick.AddListener(() =>
            {
                AttractionsManager.main.setAttraction(attraction);
            });
            addAttractionItem(attractionItem);
        }
        AttractionItem addItem = Instantiate(attractionItemPrefab);
        addItem.set(null);
        addItem.btnCreate.onClick.AddListener(() =>
        {
            AttractionsManager.main.setAttraction();
        });
        addAttractionItem(addItem);
    }

    public void addAttractionItem(AttractionItem item)
    {
        VerticalLayoutGroup layout = GetComponent<VerticalLayoutGroup>();
        RectTransform rectTransform = layout.GetComponent<RectTransform>();
        Vector2 newOffset = rectTransform.offsetMin;
        newOffset.y -= item.GetComponent<RectTransform>().rect.height;
        rectTransform.offsetMin = newOffset;

        item.transform.SetParent(transform);
        item.transform.localScale = new Vector3(1, 1, 1);
        item.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void clearItems()
    {
        AttractionItem[] items = GetComponentsInChildren<AttractionItem>();
        foreach (var item in items)
        {
            DestroyImmediate(item.gameObject);
        }
    }
}