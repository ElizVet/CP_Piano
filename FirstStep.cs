using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstStep : MonoBehaviour
{
    public Text _practiceStepText;
    public Text _resultInTable;
    public Text overallResult;

    bool progress;
    string key;
    int numberOctave;

    public void First()
    {
        SixthStep.SetOriginalColor(); // нужно убрать цвет клавиши, если 6 задание не закончено
        
        // делаем неактивными все остальные задания
        MyGlobalVariables.SetUnactiveAllTasks();
        MyGlobalVariables.firstStepFlag = true;

        ClearFieldsForReuse();

        MyGlobalVariables.countAllTimes = 0;
        _practiceStepText.text = PrintMessageWithRandomOneKey(out key, out numberOctave);
        
        // нажатая в последний раз клавиша 
        // меняем ее на случай, если она была равна той, которую нужно нажать
        MyGlobalVariables._nameOfKey = "AA";    
        progress = true;    // началось задание
    }

    public void Update() 
    {
        if(MyGlobalVariables.firstStepFlag == true) 
        {
            if(progress == true)
            {
                if (MyGlobalVariables.countAllTimes <= 10) 
                {
                    if (MyGlobalVariables._nameOfKey == $"{key}{numberOctave}")
                    {
                        EditResultInTable();
                        if(MyGlobalVariables.resultAsPercentageOne >= 80)
                            _practiceStepText.text = "Супер. Посмотрите результат в таблице.";
                        else if(MyGlobalVariables.resultAsPercentageOne >= 50)
                            _practiceStepText.text = "Хорошо. Посмотрите результат в таблице.";
                        else if(MyGlobalVariables.resultAsPercentageOne >= 30)
                            _practiceStepText.text = "Нормально. Посмотрите результат в таблице.";
                        else if(MyGlobalVariables.resultAsPercentageOne >= 0)
                            _practiceStepText.text = "Плохо. Посмотрите результат в таблице.";
                        MyGlobalVariables._nameOfKey = "AA";
                    }
                    else
                    {
                        progress = true;
                    }
                } 
                else 
                {
                    _practiceStepText.text = "У Вас было 10 попыток. Нажмите на кнопку с этим заданием, чтобы попробовать снова.";
                    MyGlobalVariables.firstStepFlag = false;
                    progress = false;   // задание закончилось
                }
            }
        }
        overallResult.text = $"Итого Вы набрали: {MyGlobalVariables.CalculateOverallResult()}%";
    }

    public void EditResultInTable()
    {
        if(MyGlobalVariables.firstStepFlag == true)
        {
            MyGlobalVariables.resultAsPercentageOne = CalculateTheTaskResult();
            _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageOne}%";

            MyGlobalVariables.firstStepFlag = false;
            progress = false;   // задание закончилось
        }
    }

    public void ClearFieldsForReuse()
    {
        MyGlobalVariables.resultAsPercentageOne = 0;
        _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageOne}%";
        MyGlobalVariables._numberOctave = 9;
    }

    string PrintMessageWithRandomOneKey(out string key, out int numberOctave)
    {
        int indexOfTheKey = new System.Random().Next(0, MyGlobalVariables.keysNames.Length);
        string randomKeyInRus = MyGlobalVariables.keysRusNames[indexOfTheKey];
        key = MyGlobalVariables.keysNames[indexOfTheKey];

        numberOctave = new System.Random().Next(1, 7);
        //numberOctave = octavesNumber[numberOctave];
        string nameOctaveInRus = MyGlobalVariables.octavesRusNames[numberOctave];

        return $"Сыграйте ноту '{randomKeyInRus}'," +
        $" используя {nameOctaveInRus}({numberOctave}) октаву.";
    }

    int CalculateTheTaskResult()
    {
        return 100 - 10 * (MyGlobalVariables.countAllTimes - 1);
    }

}
