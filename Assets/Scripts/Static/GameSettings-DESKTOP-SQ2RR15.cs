using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    public static int planet; // 0 = mercury, 1 = venus 2 = earth (cannot be selected, but still tecnichally exists), 3 = mars, 4 = jupiter, 5 = saturn, 6 = uranus, 7 = neptune, 8 = pluto, 9 = planetX
    
    public static float gameDuration; // 2, 5 or 10 minutes    index 0 = 2 min,     index 1 = 5 min,      index 2 = 10 min
    
    public static bool photosensitive; // true or false ("epilepsy mode"):   index 0 = false, index 1 = true

    public static bool gameInPlay;

    public static bool alienSpawn;

    public static bool alienDespawn;

    public static bool skyboxActive;

    public static int planetIndex;

    public static bool canSetEnvironment;

}
