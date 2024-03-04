using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdStep : MonoBehaviour
{
    public Text _practiceStepText;
    public Text _resultInTable;
    bool progress;
    string key;
    static int numberOctave;
    static int nO;

    bool keyOne = false;
    bool keyTwo = false;
    bool keyThree = false;
    bool keyOct = false;

    public void Third()
    {
        SixthStep.SetOriginalColor(); // нужно убрать цвет клавиши, если 6 задание не закончено

        // делаем неактивными все остальные задания
        MyGlobalVariables.SetUnactiveAllTasks();
        MyGlobalVariables.thirdStepFlag = true;

        ClearFieldsForReuse();

        MyGlobalVariables.countAllTimes = 0;
        _practiceStepText.text = PrintMessageWithRandomOneKey(out key, out int numberOctave) + GenerateMajorForKey(key);
        progress = true;
        nO = numberOctave;

        keyOne = false;
        keyTwo = false;
        keyThree = false;
        keyOct = false;
    }

    void Update()
    {
        if(MyGlobalVariables.thirdStepFlag == true)
        {
            if(progress)
            {
                ClickKeys(key);
            }
        }
    }

    string PrintMessageWithRandomOneKey(out string key, out int numberOctave)
    {
        int indexOfTheKey = new System.Random().Next(0, MyGlobalVariables.keysNamesForMajor.Length);
        string randomKeyInRus = MyGlobalVariables.keysRusNamesForMajor[indexOfTheKey];
        key = MyGlobalVariables.keysNamesForMajor[indexOfTheKey];

        numberOctave = new System.Random().Next(1, 7);
        //numberOctave = octavesNumber[numberOctave];
        string nameOctaveInRus = MyGlobalVariables.octavesRusNames[numberOctave];

        return $"Постройте '{randomKeyInRus}' мажорный аккорд," +
        $" используя {nameOctaveInRus}({numberOctave}) октаву на клавиатуре. ";
    }

    string GenerateMajorForKey(string key)
    {
        if(key == "C")
        {
            return "Подсказка: C (до), E (ми), G (соль).";
        }
        else if(key == "C#")
        {
            return "Подсказка: C# (до#), F (фа), G# (соль#).";
        }
        else if(key == "D")
        {
            return "Подсказка: D (ре), F# (фа#), A (ля).";
        }
        else if(key == "D#")
        {
            return "Подсказка: D# (ре#), G (соль), A# (ля#).";
        }
        else if(key == "E")
        {
            return "Подсказка: E (ми), G# (соль#), B (си).";
        }
        else
        {
            return "ошибка";
        }
    }

    void ClickKeys(string key)
    {
        if(key == "C")
        {
            if(Input.GetKeyDown(GetKeyCode(nO)))
            {
                keyOct = true;
            }
            if(keyOct && Input.GetKeyDown(KeyCode.C) && Input.GetKeyDown(KeyCode.B) && Input.GetKeyDown(KeyCode.M))
            {
                _practiceStepText.text = "Супер. Посмотрите результат.";
                UnityEngine.Debug.Log("одновременно");
                MyGlobalVariables.resultAsPercentageThree = 100;
                EditResultInTable();
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.C))
                {
                    keyOne = true;
                }
                if(Input.GetKeyDown(KeyCode.B))
                {
                    keyTwo = true;
                }
                if(Input.GetKeyDown(KeyCode.M))
                {
                    keyThree = true;
                }
                if(keyOct && keyOne && keyTwo && keyThree)
                {
                    _practiceStepText.text = "Хорошо. Посмотрите результат в таблице.";
                    UnityEngine.Debug.Log("не одновременно");
                    MyGlobalVariables.resultAsPercentageThree = 50;
                    EditResultInTable();
                }
            }
        }
        if(key == "C#") 
        {
            if(Input.GetKeyDown(GetKeyCode(nO)))
            {
                keyOct = true;
            }
            if(keyOct && Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.N) && Input.GetKeyDown(KeyCode.K))
            {
                _practiceStepText.text = "Супер. Посмотрите результат.";
                UnityEngine.Debug.Log("одновременно");
                MyGlobalVariables.resultAsPercentageThree = 100;
                EditResultInTable();
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    keyOne = true;
                }
                if(Input.GetKeyDown(KeyCode.N))
                {
                    keyTwo = true;
                }
                if(Input.GetKeyDown(KeyCode.K))
                {
                    keyThree = true;
                }
                if(keyOct && keyOne && keyTwo && keyThree)
                {
                    _practiceStepText.text = "Хорошо. Посмотрите результат.";
                    UnityEngine.Debug.Log("не одновременно");
                    MyGlobalVariables.resultAsPercentageThree = 50;
                    EditResultInTable();
                }
            }
        }
        if(key == "D") 
        {
            if(Input.GetKeyDown(GetKeyCode(nO)))
            {
                keyOct = true;
            }
            if(keyOct && Input.GetKeyDown(KeyCode.V) && Input.GetKeyDown(KeyCode.J) && Input.GetKeyDown(KeyCode.Comma))
            {
                _practiceStepText.text = "Супер. Посмотрите результат.";
                UnityEngine.Debug.Log("одновременно");
                MyGlobalVariables.resultAsPercentageThree = 100;
                EditResultInTable();
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.V))
                {
                    keyOne = true;
                }
                if(Input.GetKeyDown(KeyCode.J))
                {
                    keyTwo = true;
                }
                if(Input.GetKeyDown(KeyCode.Comma))
                {
                    keyThree = true;
                }
                if(keyOct && keyOne && keyTwo && keyThree)
                {
                    _practiceStepText.text = "Хорошо. Посмотрите результат.";
                    UnityEngine.Debug.Log("не одновременно");
                    MyGlobalVariables.resultAsPercentageThree = 50;
                    EditResultInTable();
                }
            }
        }
        if(key == "D#") 
        {
            if(Input.GetKeyDown(GetKeyCode(nO)))
            {
                keyOct = true;
            }
            if(keyOct && Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.M) && Input.GetKeyDown(KeyCode.L))
            {
                _practiceStepText.text = "Супер. Посмотрите результат.";
                UnityEngine.Debug.Log("одновременно");
                MyGlobalVariables.resultAsPercentageThree = 100;
                EditResultInTable();
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.G))
                {
                    keyOne = true;
                }
                if(Input.GetKeyDown(KeyCode.M))
                {
                    keyTwo = true;
                }
                if(Input.GetKeyDown(KeyCode.L))
                {
                    keyThree = true;
                }
                if(keyOct && keyOne && keyTwo && keyThree)
                {
                    _practiceStepText.text = "Хорошо. Посмотрите результат.";
                    UnityEngine.Debug.Log("не одновременно");
                    MyGlobalVariables.resultAsPercentageThree = 50;
                    EditResultInTable();
                }
            }
        }
        if(key == "E") 
        {
            if(Input.GetKeyDown(GetKeyCode(nO)))
            {
                keyOct = true;
            }
            if(keyOct && Input.GetKeyDown(KeyCode.B) && Input.GetKeyDown(KeyCode.K) && Input.GetKeyDown(KeyCode.Period))
            {
                _practiceStepText.text = "Супер. Посмотрите результат.";
                UnityEngine.Debug.Log("одновременно");
                MyGlobalVariables.resultAsPercentageThree = 100;
                EditResultInTable();
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.B))
                {
                    keyOne = true;
                }
                if(Input.GetKeyDown(KeyCode.K))
                {
                    keyTwo = true;
                }
                if(Input.GetKeyDown(KeyCode.Period))
                {
                    keyThree = true;
                }
                if(keyOct && keyOne && keyTwo && keyThree)
                {
                    _practiceStepText.text = "Хорошо. Посмотрите результат.";
                    UnityEngine.Debug.Log("не одновременно");
                    MyGlobalVariables.resultAsPercentageThree = 50;
                    EditResultInTable();
                }
            }
        }
    }

    KeyCode GetKeyCode(int numberOctave)
    {
        if(numberOctave == 0)
        {
            return KeyCode.Keypad0;
        }
        else if(numberOctave == 1)
        {
            return KeyCode.Keypad1;
        }
        else if(numberOctave == 2)
        {
            return KeyCode.Keypad2;
        }
        else if(numberOctave == 3)
        {
            return KeyCode.Keypad3;
        }
        else if(numberOctave == 4)
        {
            return KeyCode.Keypad4;
        }
        else if(numberOctave == 5)
        {
            return KeyCode.Keypad5;
        }
        else if(numberOctave == 6)
        {
            return KeyCode.Keypad6;
        }
        else if(numberOctave == 7)
        {
            return KeyCode.Keypad7;
        }
        else
        {
            return KeyCode.Keypad8;
        }
    }

    public void EditResultInTable()
    {
        if(MyGlobalVariables.thirdStepFlag == true)
        {
            _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageThree}%";

            MyGlobalVariables.thirdStepFlag = false;
            progress = false;   // задание закончилось
        }
    }

    public void ClearFieldsForReuse()
    {
        MyGlobalVariables.resultAsPercentageThree = 0;
        _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageThree}%";
        MyGlobalVariables._numberOctave = 9;
    }

}
