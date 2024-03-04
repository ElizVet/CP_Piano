using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondStep : MonoBehaviour
{
    public Text _practiceStepText;
    public Text _resultInTable;

    bool progress;
    string key;

    public void Second()
    {
        SixthStep.SetOriginalColor(); // нужно убрать цвет клавиши, если 6 задание не закончено

        MyGlobalVariables.SetUnactiveAllTasks();
        MyGlobalVariables.secondStepFlag = true;

        ClearFieldsForReuse();

        MyGlobalVariables.countAllTimes = 0;
        
        _practiceStepText.text = PrintMessageWithRandomOneKeyInAllOctaves(out key);
        MyGlobalVariables._nameOfKey = "AA";    
        progress = true;

        cOctave = false;
        gOctave = false;
        sOctave = false;
        olOctave = false;
        twlOctave = false;
        thlOctave = false;
        folOctave = false;
    }

    public void Update() 
    {
        if(MyGlobalVariables.secondStepFlag == true)
        {
            if(progress == true)
            {
                CheckTheClick();
                MyGlobalVariables._nameOfKey = "AA";
            }
        }
    }

    bool scOctave = true;
    bool cOctave = false;
    bool gOctave = false;
    bool sOctave = false;
    bool olOctave = false;
    bool twlOctave = false;
    bool thlOctave = false;
    bool folOctave = false;
    bool filOctave = true;

    void CheckTheClick()
    {
        if(MyGlobalVariables._nameOfKey == $"{key}0")
        {
            scOctave = true;
        }
        if(MyGlobalVariables._nameOfKey == $"{key}1")
        {
            cOctave = true;
        }
        if(MyGlobalVariables._nameOfKey == $"{key}2")
        {
            gOctave = true;
        }
        if(MyGlobalVariables._nameOfKey == $"{key}3")
        {
            sOctave = true;
        }
        if(MyGlobalVariables._nameOfKey == $"{key}4")
        {
            olOctave = true;
        }
        if(MyGlobalVariables._nameOfKey == $"{key}5")
        {
            twlOctave = true;
        }
        if(MyGlobalVariables._nameOfKey == $"{key}6")
        {
            thlOctave = true;
        }
        if(MyGlobalVariables._nameOfKey == $"{key}7")
        {
            folOctave = true;
        }
        if(MyGlobalVariables._nameOfKey == $"{key}8")
        {
            filOctave = true;
        }

        if(scOctave && cOctave && gOctave && sOctave && olOctave && twlOctave && thlOctave && folOctave && filOctave)
        {
            EditResultInTable();
        }
    }

    string PrintMessageWithRandomOneKeyInAllOctaves(out string key)
    {
        int indexOfTheKey = new System.Random().Next(0, MyGlobalVariables.keysNames.Length);
        string randomKeyInRus = MyGlobalVariables.keysRusNames[indexOfTheKey];
        key = MyGlobalVariables.keysNames[indexOfTheKey];

        return $"Сыграйте ноту '{randomKeyInRus}' на всех октавах.";
    }

    int CalculateTheTaskResult()
    {
        if(MyGlobalVariables.countAllTimes >= 0 && MyGlobalVariables.countAllTimes <= 8)
        {
            _practiceStepText.text = "Супер. Посмотрите результат в таблице.";
            return 100;
        }
        else if(MyGlobalVariables.countAllTimes >= 9 && MyGlobalVariables.countAllTimes <= 10)
        {
            _practiceStepText.text = "Супер. Посмотрите результат в таблице.";
            return 90;
        }
        else if(MyGlobalVariables.countAllTimes >= 11 && MyGlobalVariables.countAllTimes <= 12)
        {
            _practiceStepText.text = "Супер. Посмотрите результат в таблице.";
            return 80;
        }
        else if(MyGlobalVariables.countAllTimes >= 13 && MyGlobalVariables.countAllTimes <= 14)
        {
            _practiceStepText.text = "Хорошо. Посмотрите результат в таблице.";
            return 70;
        }
        else if(MyGlobalVariables.countAllTimes >= 15 && MyGlobalVariables.countAllTimes <= 16)
        {
            _practiceStepText.text = "Хорошо. Посмотрите результат в таблице.";
            return 60;
        }
        else if(MyGlobalVariables.countAllTimes >= 17 && MyGlobalVariables.countAllTimes <= 18)
        {
            _practiceStepText.text = "Хорошо. Посмотрите результат в таблице.";
            return 50;
        }
        else if(MyGlobalVariables.countAllTimes >= 19 && MyGlobalVariables.countAllTimes <= 20)
        {
            _practiceStepText.text = "Нормально. Посмотрите результат в таблице.";
            return 40;
        }
        else if(MyGlobalVariables.countAllTimes >= 21 && MyGlobalVariables.countAllTimes <= 22)
        {
            _practiceStepText.text = "Нормально. Посмотрите результат в таблице.";
            return 30;
        }
        else if(MyGlobalVariables.countAllTimes >= 23 && MyGlobalVariables.countAllTimes <= 24)
        {
            _practiceStepText.text = "Плохо. Посмотрите результат в таблице.";
            return 20;
        }
        else if(MyGlobalVariables.countAllTimes >= 25 && MyGlobalVariables.countAllTimes <= 26)
        {
            _practiceStepText.text = "Плохо. Посмотрите результат в таблице.";
            return 10;
        }
        else 
        {
            _practiceStepText.text = "Плохо. Посмотрите результат в таблице.";
            return 0;
        }
    }

    public void EditResultInTable()
    {
        if(MyGlobalVariables.secondStepFlag == true)
        {
            MyGlobalVariables.resultAsPercentageTwo = CalculateTheTaskResult();
            _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageTwo}%";

            MyGlobalVariables.secondStepFlag = false;
            progress = false;   // задание закончилось
        }
    }

    public void ClearFieldsForReuse()
    {
        MyGlobalVariables.resultAsPercentageTwo = 0;
        _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageTwo}%";
        MyGlobalVariables._numberOctave = 9;
    }

}
