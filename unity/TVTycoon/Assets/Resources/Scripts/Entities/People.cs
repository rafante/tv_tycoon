using System;

public class People
{
    public PeopleGender gender;
    public AgeGroup ageGroup;
    public ProfessionGroup profession;
    public Nationality nationality;
    public PoliticalRate politicalRate;
    public MusicalGroup[] musicalTaste;
    public PersonalityRate[] personalities;

    //TODO: Implement
//    public FoodTaste[] foodTastes;

    public static People randomPeople(string seed)
    {
        int chance = 0;
        Random random = new Random(seed.GetHashCode());
        People people = new People();
        chance = random.Next(0, Enum.GetNames(typeof(PeopleGender)).Length);
        people.gender = (PeopleGender) chance;

        chance = random.Next(0, Enum.GetNames(typeof(AgeGroup)).Length);
        people.ageGroup = (AgeGroup) chance;

        chance = random.Next(1, 4);
        people.musicalTaste = new MusicalGroup[chance];
        for (int i = 0; i < people.musicalTaste.Length; i++)
        {
            chance = random.Next(0, Enum.GetNames(typeof(MusicalGroup)).Length);
            people.musicalTaste[i] = (MusicalGroup) chance;
        }

        chance = random.Next(1, 3);
        people.personalities = new PersonalityRate[chance];
        int points = 10;
        for (int i = 0; i < people.personalities.Length; i++)
        {
            int _points;
            if (i == people.personalities.Length - 1)
            {
                _points = points;
            }
            else
            {
                chance = random.Next(0, Enum.GetNames(typeof(PersonalityTrace)).Length);
                _points = random.Next(1, points + 1);
            }
            if (_points <= 0)
                _points = 1;

            people.personalities[i] = new PersonalityRate((PersonalityTrace) chance, _points);
            points -= _points;
        }

        chance = random.Next(0, Enum.GetNames(typeof(Nationality)).Length);
        people.nationality = (Nationality) chance;
        
        chance = random.Next(0, Enum.GetNames(typeof(PoliticalInclination)).Length);
        people.politicalRate = new PoliticalRate((PoliticalInclination) chance, random.Next(1, 11));

        return people;
    }
}

public struct PoliticalRate
{
    public PoliticalInclination inclination;
    public int points;

    public PoliticalRate(PoliticalInclination inclination, int points)
    {
        this.inclination = inclination;
        this.points = points;
    }
}

public struct PersonalityRate
{
    public PersonalityTrace trace;
    public int points;

    public PersonalityRate(PersonalityTrace trace, int points)
    {
        this.trace = trace;
        this.points = points;
    }
}

public enum PeopleGender
{
    MALE,
    FEMALE
}

public enum AgeGroup
{
    BABY,
    INFANT,
    TEENAGER,
    YOUNG,
    ADULT,
    HALF_AGE,
    OLD
}

public enum ProfessionGroup
{
    NONE,
    EMPLOYER,
    SERVICES,
    COMMERCE,
    INDUSTRY,
    UNEMPLOYED
}

public enum MusicalGroup
{
    NONE,
    JAPANESE,
    COUNTRY,
    BLUES,
    JAZZ
}

public enum PoliticalInclination
{
    RIGHT,
    LEFT,
    CENTRE,
    STATIST
}

public enum PersonalityTrace
{
    ARCHITECT,
    LOGIC,
    COMMANDER,
    INNOVATOR,
    ATTORNEY,
    MEDIATOR,
    PROTAGONIST,
    ACTIVIST,
    LOGISTIC,
    DEFENDER,
    EXECUTIVE,
    COSUL,
    VIRTUOUS,
    ADVENTURER,
    ENTREPRENEUR,
    ENTERTAINER
}

public enum Nationality
{
    NORTH,
    NORTH_EAST,
    NORTH_WEST,
    SOUTH,
    SOUTH_EAST,
    SOUTH_WEST,
    EAST,
    WEST
}