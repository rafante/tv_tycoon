using System.Collections.Generic;
using UnityEngine;

public class PeopleGroupsViewer : MonoBehaviour
{
    public List<PeopleGroup> peopleGroups;
    public PeopleGroupViewer viewer;

    void Start()
    {
        peopleGroups = new List<PeopleGroup>();
    }

    public void setPeopleGroups(List<PeopleGroup> peopleGroups)
    {
        this.peopleGroups = peopleGroups;
        foreach (var peopleGroup in this.peopleGroups)
        {
            PeopleGroupViewer item = Instantiate(viewer);
            item.peopleGroup = peopleGroup;
            
            item.gameObject.transform.SetParent(transform);
            item.transform.localScale = new Vector3(1, 1, 1);
            item.transform.localPosition = Vector3.zero;
        }
    }
}