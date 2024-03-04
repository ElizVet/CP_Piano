using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SixthStep : MonoBehaviour
{
    public Text _practiceStepText;
    public InputField _inputField;
    public Text _answerInputField;
    public Text _answerInTable;
    public Text _resultInTable;

    bool progress;
    string key;
    int numberOctave;
    string randomKeyInRus;      // для того чтобы результат записывать в таблицу на рус
    int whiteOrBlack;
    static Renderer[] keyParts;
    static Color _origColor = new Color(0, 0, 0);

    public void Sixth()
    {
        // делаем неактивными все остальные задания
        MyGlobalVariables.SetUnactiveAllTasks();
        MyGlobalVariables.sixthStepFlag = true;

        // так как начинается новое задание, результат обнуляем:
        ClearFieldsForReuse();
        
        if(progress == true)
        {
            foreach (var item in keyParts)
            {
                item.material.color = _origColor;
            }
        }
        _practiceStepText.text = "На клавиатуре подсветилась клавиша. Найдите ее и введите русское название в поле для ввода.";
        GetRandomOneKey(out key, out numberOctave, out randomKeyInRus);

        whiteOrBlack = new System.Random().Next(1,3);
        if(whiteOrBlack == 2 && key != "B" && key != "E")
        {
            key = $"{key}{numberOctave}-1";
            randomKeyInRus = $"{randomKeyInRus}#";
        }
        else
            key = $"{key}{numberOctave}";
        
        UnityEngine.Debug.Log(key);
        keyParts = GameObject.Find(key).GetComponentsInChildren<Renderer>();
        
        foreach (var item in keyParts)
        {
            _origColor = item.material.color;
            item.material.color = new Color(33, 124, 163);
        }
        progress = true;
    }

    public void EditAnswerInTable()
    {
        if(MyGlobalVariables.sixthStepFlag == true && _answerInputField.text != "")
        {
            _answerInTable.text = _answerInputField.text;
            MyGlobalVariables.sixthStepFlag = false;
            _practiceStepText.text = "Ваш ответ записан в таблицу. Посмотрите свой результат в таблице. Поменять результат нельзя. Начните задание заново.";
            
            if(_answerInTable.text == randomKeyInRus)
            {
                MyGlobalVariables.resultAsPercentageSix = 100;
                _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageSix}%";
                foreach (var item in keyParts)
                {
                    item.material.color = _origColor;
                }
            }
            else
            {
                MyGlobalVariables.resultAsPercentageSix = 0;
                _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageSix}%";
                foreach (var item in keyParts)
                {
                    item.material.color = _origColor;
                }
            }
            _inputField.Select();
            _inputField.text = "";
        }
    }

    public void ClearFieldsForReuse()
    {
        MyGlobalVariables.resultAsPercentageSix = 0;
        _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageSix}%";
        _answerInTable.text = "";
        MyGlobalVariables._numberOctave = 9;
    }

    public static void SetOriginalColor()
    {
        if(MyGlobalVariables.sixthStepFlag == true) 
        {
            foreach (var item in keyParts)
            {
                item.material.color = _origColor;
            }
            MyGlobalVariables.sixthStepFlag = false;
        }
    }

    void GetRandomOneKey(out string key, out int numberOctave, out string randomKeyInRus)
    {
        int indexOfTheKey = new System.Random().Next(0, MyGlobalVariables.keysNames.Length);
        randomKeyInRus = MyGlobalVariables.keysRusNames[indexOfTheKey];
        key = MyGlobalVariables.keysNames[indexOfTheKey];

        numberOctave = new System.Random().Next(1, 7);
        //numberOctave = octavesNumber[numberOctave];
        string nameOctaveInRus = MyGlobalVariables.octavesRusNames[numberOctave];
    }

    
}
