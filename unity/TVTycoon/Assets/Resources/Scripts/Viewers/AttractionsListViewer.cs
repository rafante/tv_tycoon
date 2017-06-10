using UnityEngine;
using UnityEngine.UI;

public class AttractionsListViewer : VerticalLayoutGroup
{
    public static AttractionsListViewer main;

    void Awake()
    {
        if (main == null)
        {
            main = this;
            main.init();
        }
    }

    public void init()
    {
    }

    public void addAttractionItem(AttractionItem item)
    {
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