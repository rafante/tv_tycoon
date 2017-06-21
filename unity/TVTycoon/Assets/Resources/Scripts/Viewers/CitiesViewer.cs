using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CitiesViewer : MonoBehaviour
{
    public List<City> cities;
    public GameObject cityViewerPrefab;

    void Start()
    {
        cities = new List<City>();
    }

    public void addRandomCity()
    {
        CityViewer cityViewer = Instantiate(cityViewerPrefab).GetComponent<CityViewer>();
        cityViewer.city = City.createCity(WordGenerator.RandomString(10),
            (CityType) Random.Range(0, Enum.GetNames(typeof(CityType)).Length), "teste");
        //cities.Add(cityViewer.city);
        cityViewer.gameObject.transform.SetParent(transform);
        cityViewer.transform.localScale = new Vector3(1, 1, 1);
        cityViewer.transform.localPosition = Vector3.zero;
        cityViewer.init();
    }
}