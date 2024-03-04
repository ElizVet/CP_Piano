using System;
using System.Collections;
using System.Collections.Generic;

public static class MyGlobalVariables
{
    public static string _nameOfKey = "AA";
    public static int _numberOctave = 9;

    public static int countAllTimes = 0;

    public static string[] keysRusNames = new string[7] { "до", "ре", "ми", "фа", "соль", "ля", "си" };
    public static string[] keysNames = new string[7] { "C", "D", "E", "F", "G", "A", "B" };

    public static string[] octavesRusNames = new string[7] { "контр", "большую", "маленькую", "первую", "вторую", "третью", "четвертую" };
    public static int[] octavesNumber = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

    public static string[] keysNamesForMajor = new string[5] { "C", "C#", "D", "D#", "E" };
    public static string[] keysRusNamesForMajor = new string[5] { "до", "до#", "ре", "ре#", "ми" };

    // для того, чтобы задания не пересекались
    // меняем на false, если внезапно перешли к другому заданию
    public static bool firstStepFlag = false; // true - если активное задание, false - пассивно
    public static bool secondStepFlag = false;
    public static bool thirdStepFlag = false;
    public static bool fourthStepFlag = false;
    public static bool fifthStepFlag = false;
    public static bool sixthStepFlag = false;
    public static bool seventhStepFlag = false;
    public static bool eighthStepFlag = false;

    public static void SetUnactiveAllTasks()
    {
        firstStepFlag = false;
        secondStepFlag = false;
        thirdStepFlag = false;
        fourthStepFlag = false;
        fifthStepFlag = false;
        sixthStepFlag = false;
        seventhStepFlag = false;
        eighthStepFlag = false;
    }

    public static string inputField = "";

    public static int resultAsPercentageOne = 0;
    public static int resultAsPercentageTwo = 0;
    public static int resultAsPercentageThree = 0;
    public static int resultAsPercentageFour = 0;
    public static int resultAsPercentageFive = 0;
    public static int resultAsPercentageSix = 0;
    public static int resultAsPercentageSeven = 0;
    public static int resultAsPercentageEight = 0;

    public static int CalculateOverallResult()
    {
        return (resultAsPercentageOne + 
        resultAsPercentageTwo + resultAsPercentageThree + 
        resultAsPercentageFour + resultAsPercentageFive + 
        resultAsPercentageSix + resultAsPercentageSeven + 
        resultAsPercentageEight) / 8;
    }

}
