using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City
{
    public static City small;
    public static City medium;
    public static City large;

    public float technologicalCost;
    public float maintenanceCost;
    public float salaryCost;
    public float installationCost;
    public int advertisers;

    public static City get(int i)
    {
        if (small == null || medium == null || large == null)
            setCities();
        switch (i)
        {
            case 1:
                return small;
            case 2:
                return medium;
            case 3:
                return large;
            default:
                Debug.Log("cidade " + i);
                return null;
        }
    }

    public static void setCities()
    {
        if (small == null)
        {
            small = new City();
            small.technologicalCost = 1;
            small.maintenanceCost = 1;
            small.salaryCost = 1;
            small.installationCost = 100000;
            small.advertisers = 50;
        }
        if (medium == null)
        {
            medium = new City();
            medium.technologicalCost = 1;
            medium.maintenanceCost = 1;
            medium.salaryCost = 1;
            medium.installationCost = 200000;
            medium.advertisers = 100;
        }
        if (large == null)
        {
            large = new City();
            large.technologicalCost = 1;
            large.maintenanceCost = 1;
            large.salaryCost = 1;
            large.installationCost = 300000;
            large.advertisers = 500;
        }
    }
}