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
        item.transform.parent = transform;
        item.transform.localScale = new Vector3(1, 1, 1);
        item.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
    }
}