using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class City
{
    public static City small;
    public static City medium;
    public static City large;

    public float technologicalCost;
    public float maintenanceCost;
    public float salaryCost;
    public float installationCost;

    private static List<City> citiesBuffer = new List<City>();
    private static int maxGroupsForGender = 10;
    private float immigrationRate;
    private string name, seed;
    private DateTime createTime, lastUpdateTime, nextUpdateTime;
    private long updateStamp;
    private PeopleGroup[] peopleGroups;

    public City()
    {
        createTime = DateTime.Now;
        lastUpdateTime = createTime;
        updateStamp = 1000;
        Clock.main.scheduleTimeAction(1800, updateImmigration, this);
    }

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

    public void update(int interval)
    {
        updateImmigration(interval);
    }

    public int getCurPopulation()
    {
        int population = 0;
        foreach (var peopleGroup in peopleGroups)
        {
            population += peopleGroup.number;
        }
        return population;
    }

    private void updateImmigration(object data)
    {
        int leavingPeople = Mathf.RoundToInt(getCurPopulation() * immigrationRate);
        List<City> cities = getSuitableCitiesToImmigrate();
        Random random = new Random(seed.GetHashCode());

        if (cities.Count > 0)
        {
            int _leavingPeople = leavingPeople;
            foreach (var peopleGroup in peopleGroups)
            {
                int maxPeople = _leavingPeople > peopleGroup.number ? peopleGroup.number : _leavingPeople;
                int people = random.Next(1, maxPeople);
                PeopleGroup group = peopleGroup.getPeople(people);
                City destination = cities[random.Next(0, cities.Count)];

                immigrate(group, destination);
            }
        }
    }

    public void immigrate(PeopleGroup peopleGroup, City destination)
    {
        for (int i = 0; i < destination.peopleGroups.Length; i++)
        {
            if (destination.peopleGroups[i].Equals(peopleGroup))
            {
                destination.peopleGroups[i] += peopleGroup;
                return;
            }
        }
        Array.Resize(ref destination.peopleGroups, destination.peopleGroups.Length + 1);
        destination.peopleGroups[destination.peopleGroups.Length - 1] = peopleGroup;
    }

    public List<City> getSuitableCitiesToImmigrate()
    {
        return citiesBuffer;
    }

    public static void addCity(City city)
    {
        if (!citiesBuffer.Contains(city))
        {
            citiesBuffer.Add(city);
        }
    }

    public static void removeCity(City city)
    {
        if(!citiesBuffer.Contains(city))
            throw new Exception("Tried to remove a city from buffer but there's no such city in the buffer");
        citiesBuffer.Remove(city);
    }

    public static int getRandomPopulation(CityType cityType, string seed)
    {
        Random r = new Random(seed.GetHashCode());
        switch (cityType)
        {
            case CityType.SMALL:
                return r.Next(100, 25000);
            case CityType.MEDIUM:
                return r.Next(25000, 100000);
            case CityType.LARGE:
                return r.Next(100000, 1500000);
            case CityType.CAPITAL:
                return r.Next(1500000, 5000000);
            case CityType.METROPOLITAN:
                return r.Next(500000, 2000000);
            case CityType.METROPOLIS:
                return r.Next(5000000, 20000000);
            default:
                throw new ArgumentOutOfRangeException("cityType", cityType, null);
        }
    }

    public static City createCity(string name, CityType cityType, string seed)
    {
        City city = new City();
        city.seed = seed;
        int population = getRandomPopulation(cityType, city.seed);
        city.name = name;

        Random random = new Random();
        int maleNumber = random.Next(1, population);
        int femaleNumber = population - maleNumber;

        int maleGroups = random.Next(1, maxGroupsForGender + 1);
        int femaleGroups = random.Next(1, maxGroupsForGender + 1);
        city.peopleGroups = new PeopleGroup[maleGroups + femaleGroups];

        int groupIndex = 0;

        for (int i = 0; i < maleGroups; i++)
        {
            int _maleNumber;
            if (i == maleGroups - 1)
            {
                _maleNumber = maleNumber;
            }
            else
            {
                _maleNumber = random.Next(1, maleNumber);
                maleNumber -= _maleNumber;
            }

            city.peopleGroups[groupIndex] = new PeopleGroup(People.randomPeople(city.seed), _maleNumber);
            city.peopleGroups[groupIndex].people.gender = PeopleGender.MALE;

            groupIndex++;
        }

        for (int i = 0; i < femaleGroups; i++)
        {
            int _femaleNumber;
            if (i == maleGroups - 1)
            {
                _femaleNumber = femaleNumber;
            }
            else
            {
                _femaleNumber = random.Next(1, femaleNumber);
                femaleNumber -= _femaleNumber;
            }

            city.peopleGroups[groupIndex] = new PeopleGroup(People.randomPeople(city.seed), _femaleNumber);

            groupIndex++;
        }

        return city;
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
        }
        if (medium == null)
        {
            medium = new City();
            medium.technologicalCost = 1;
            medium.maintenanceCost = 1;
            medium.salaryCost = 1;
            medium.installationCost = 200000;
        }
        if (large == null)
        {
            large = new City();
            large.technologicalCost = 1;
            large.maintenanceCost = 1;
            large.salaryCost = 1;
            large.installationCost = 300000;
        }
    }
}

public struct PeopleGroup
{
    public People people;
    public int number;

    public PeopleGroup(People people, int number)
    {
        this.people = people;
        this.number = number;
    }

    public PeopleGroup getPeople(int i)
    {
        return new PeopleGroup(people, i > number ? number : i);
    }

    public static PeopleGroup operator +(PeopleGroup thisGroup, PeopleGroup otherGroup)
    {
        if (thisGroup.people.Equals(otherGroup.people))
            thisGroup.number += otherGroup.number;
        return thisGroup;
    }
}

public enum CityType
{
    SMALL,
    MEDIUM,
    LARGE,
    CAPITAL,
    METROPOLITAN,
    METROPOLIS
}