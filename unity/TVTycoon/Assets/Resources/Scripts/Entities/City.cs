using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    public static City small;
    public static City medium;
    public static City large;

    public float technologicalCost;
    public float maintenanceCost;
    public float salaryCost;
    public float installationCost;
    public int advertisers;

    // Use this for initialization
    void Awake()
    {
        if (small == null)
        {
            technologicalCost = 1;
            maintenanceCost = 1;
            salaryCost = 1;
            installationCost = 100000;
            advertisers = 50;
        }
        if (medium == null)
        {
            technologicalCost = 1;
            maintenanceCost = 1;
            salaryCost = 1;
            installationCost = 200000;
            advertisers = 100;
        }
        if (large == null)
        {
            technologicalCost = 1;
            maintenanceCost = 1;
            salaryCost = 1;
            installationCost = 300000;
            advertisers = 500;
        }
    }

    public static City get(int i)
    {
        switch (i)
        {
            case 1:
                return small;
            case 2:
                return medium;
            case 3:
                return large;
            default:
                return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}