using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CityViewer : MonoBehaviour
{
    public City city;
    public Text name, population;
    public PeopleGroupsViewer peopleGroupsViewer;

    public void init()
    {
        if (peopleGroupsViewer == null)
            peopleGroupsViewer = GetComponent<PeopleGroupsViewer>();
        peopleGroupsViewer.setPeopleGroups(city.getPeopleGroups());
    }

    void OnGUI()
    {
        if (city != null)
        {
            name.text = city.getName();
            population.text = city.getCurPopulation().ToString("N1", new CultureInfo("pt-BR"));
        }
    }
}