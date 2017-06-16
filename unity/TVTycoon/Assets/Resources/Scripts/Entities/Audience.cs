using System;

public class Audience
{
    public AgeGroup age;
    public GenderGroup gender;
    public ProfessionGroup profession;
    public MusicalGroup musical;
    public int peopleNumber;
    
    private Audience()
    {
        
    }

    public Audience createAudience(int population, CityType cityType)
    {
        int audienceGroupsNumber = new Random().Next(2, 11);
        Audience[] audiences = new Audience[audienceGroupsNumber];
        float malePerc = 100 - new Random().Next(1, 100);
        float femalePerc = 100 - malePerc;
        return null;
    }

    public void update()
    {
        
    }
}

public enum AgeGroup
{
    OLD, ADULT, YOUNG, TEEN, CHILD, BABY
}

public enum GenderGroup
{
    MALE, FEMALE
}

public enum ProfessionGroup
{
    NONE, EMPLOYER, SERVICES, COMMERCE, INDUSTRY, UNEMPLOYED
}

public enum MusicalGroup
{
    NONE, JAPANESE, COUNTRY, BLUES, JAZZ
}