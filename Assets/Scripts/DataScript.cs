using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataScript
{
    public static int currentLevel;

    public static int maxLevel;

    public static int boneCount;

    public static int expectedBoneCount;

    public static bool isGamePaused;

    public static int totalLevelCount;

    public static Color boneColor;

    public static Color groundColor;

    //public static Color backgroundColor;                    //deprecated use backgroundimagepath instead

    public static string skyboxPath;

    public static Color backgroundPanelImageColor;

    public static string levelColorCode;

    public static bool canMove;                     // controls turn based system of bore(puppy) and bad dogs

    public static int[] starsForAllLevels;

    public static int currentTotalStarCount;

    public static int starsNeededToMoveNewHome;
}
