using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class People
{
    public PeopleGender gender;
    public AgeGroup ageGroup;
    public ProfessionGroup profession;
    public Nationality nationality;
    public PoliticalRate politicalRate;
    public List<MusicalRate> musicalTaste;
    public List<PersonalityRate> personalities;

    public override string ToString()
    {
        string text =
            "PeopleGroup: \n gender: $gender \n ageGroup: $ageGroup \n profession: $profession \n nationality: $nationality" +
            " \n politicalRate: $politicalRate";

        text = text.Replace("$gender", gender.ToString());
        text = text.Replace("$ageGroup", ageGroup.ToString());
        text = text.Replace("$profession", profession.ToString());
        text = text.Replace("$nationality", nationality.ToString());
        text = text.Replace("$politicalRate", politicalRate.ToString());

        text += "\n musicalTaste:";
        foreach (var musicalRate in musicalTaste)
        {
            text += "\n  " + musicalRate.ToString();
        }

        text += "\n personalities:";
        foreach (var personality in personalities)
        {
            text += "\n  " + personality.ToString();
        }
        return text;
    }
    //TODO: Implement
//    public FoodTaste[] foodTastes;


    public static People randomPeople(string seed)
    {
        int chance = 0;
        People people = new People();

        int gender = Enum.GetNames(typeof(PeopleGender)).Length;
        chance = Random.Range(0, gender);
        people.setGender((PeopleGender) chance);

        int ageGroup = Enum.GetNames(typeof(AgeGroup)).Length;
        chance = Random.Range(0, ageGroup);
        people.setAgeGroup((AgeGroup) chance);

        int profession = Enum.GetNames(typeof(ProfessionGroup)).Length;
        chance = Random.Range(0, profession);
        people.setProfessionGroup((ProfessionGroup) chance);

        chance = Random.Range(1, 4);
        int size = chance;
        int musicalGroupSize = Enum.GetNames(typeof(MusicalGroup)).Length;
        people.musicalTaste = new List<MusicalRate>();

        int mPoints = 10;
        for (int i = 0; i < size; i++)
        {
            int _mPoints = Random.Range(1, 10);

            if (i == size)
            {
                if (Random.Range(0, 101) < 30
                ) // if it's the last, there's a chance that it uses all remaining points
                    _mPoints = mPoints;
                else if (_mPoints == 0) //if not, ensure it's going to have at least 1 point in something
                    _mPoints = 1;
            }

            if (mPoints <= 0) // if there's no more points, abort
                break;

            chance = Random.Range(0, musicalGroupSize);
            MusicalGroup musicalGroup = (MusicalGroup) chance;
            people.addMusicalRate(new MusicalRate(musicalGroup, _mPoints));

            mPoints -= _mPoints;
        }

        chance = Random.Range(1, 3);
        size = chance;
        int personalityTraceSize = Enum.GetNames(typeof(PersonalityTrace)).Length;
        people.personalities = new List<PersonalityRate>();

        mPoints = 10;
        for (int i = 0; i < size; i++)
        {
            int _mPoints = Random.Range(1, 10);

            if (i == size)
            {
                if (Random.Range(0, 101) < 30
                ) // if it's the last, there's a chance that it uses all remaining points
                    _mPoints = mPoints;
                else if (_mPoints == 0) //if not, ensure it's going to have at least 1 point in something
                    _mPoints = 1;
            }

            if (mPoints <= 0) // if there's no more points, abort
                break;

            chance = Random.Range(0, personalityTraceSize);
            PersonalityTrace personalityTrace = (PersonalityTrace) chance;
            people.addPersonalityRate(new PersonalityRate(personalityTrace, _mPoints));

            mPoints -= _mPoints;
        }

        int nationality = Enum.GetNames(typeof(Nationality)).Length;
        chance = Random.Range(0, nationality);
        people.setNationality((Nationality) chance);

        int politicalInclination = Enum.GetNames(typeof(PoliticalInclination)).Length;
        chance = Random.Range(0, politicalInclination);
        people.politicalRate = new PoliticalRate((PoliticalInclination) chance, Random.Range(1, 11));
        people.setPoliticalRate((PoliticalInclination) chance, Random.Range(1, 11));

        return people;
    }

    public void setGender(PeopleGender gender)
    {
        this.gender = gender;
    }

    public void setAgeGroup(AgeGroup ageGroup)
    {
        this.ageGroup = ageGroup;
        setProfessionGroup(profession);
    }

    public void setProfessionGroup(ProfessionGroup profession)
    {
        if ((int) ageGroup > (int) AgeGroup.TEENAGER)
            this.profession = profession;
        else
            this.profession = ProfessionGroup.NONE;
    }

    public void setNationality(Nationality nationality)
    {
        this.nationality = nationality;
    }

    public void setPoliticalRate(PoliticalInclination trace, int points)
    {
        if ((int) ageGroup < (int) AgeGroup.TEENAGER)
            points = 0;
        politicalRate = new PoliticalRate(trace, points);
    }

    public void addMusicalRate(MusicalRate musicalRate)
    {
        if ((int) ageGroup < (int) AgeGroup.TEENAGER)
            musicalRate.points = 0;
        for (int i = 0; i < musicalTaste.Count; i++)
        {
            if (musicalTaste[i].musicalGroup == musicalRate.musicalGroup)
            {
                musicalTaste[i].points += musicalRate.points;
                return;
            }
        }
        musicalTaste.Add(musicalRate);
    }

    public void addPersonalityRate(PersonalityRate personalityRate)
    {
        for (int i = 0; i < personalities.Count; i++)
        {
            if (personalities[i].trace == personalityRate.trace)
            {
                personalities[i].points += personalityRate.points;
                return;
            }
        }
        personalities.Add(personalityRate);
    }
}

public class MusicalRate
{
    public MusicalGroup musicalGroup;
    public int points;

    public MusicalRate(MusicalGroup musicalGroup, int points)
    {
        this.musicalGroup = musicalGroup;
        this.points = points;
    }

    public override string ToString()
    {
        return musicalGroup.ToString() + " : " + points;
    }
}

public class PoliticalRate
{
    public PoliticalInclination inclination;
    public int points;

    public PoliticalRate(PoliticalInclination inclination, int points)
    {
        this.inclination = inclination;
        this.points = points;
    }

    public override string ToString()
    {
        return inclination.ToString() + " : " + points;
    }
}

public class PersonalityRate
{
    public PersonalityTrace trace;
    public int points;

    public PersonalityRate(PersonalityTrace trace, int points)
    {
        this.trace = trace;
        this.points = points;
    }

    public override string ToString()
    {
        return trace.ToString() + " : " + points;
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