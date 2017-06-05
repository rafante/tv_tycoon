using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience
{

    private static Audience audience;

    private Audience()
    {
        if (audience == null)
        {
            audience = new Audience();
        }   
    }

    public static Audience get()
    {
        return audience;
    }

    public void update()
    {
        
    }
}

public class AudienceGroup
{
    
}