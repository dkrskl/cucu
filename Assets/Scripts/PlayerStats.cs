using UnityEngine;

public static class PlayerStats
{
    public static int clicks = 0;

    
    public static int Clicks
    {
        get
        {
            return clicks;
        }
        set
        {
            clicks = value;
        }
    }
}
