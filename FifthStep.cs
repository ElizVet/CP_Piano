using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FifthStep : MonoBehaviour
{
    public Text _practiceStepText;
    public InputField _inputField;
    public Text _answerInputField;
    public Text _answerInTable;
    public Text _resultInTable;
    bool progress;
    GameObject keyObject;
    string key;
    int numberOctave;
    string randomKeyInRus;      // для того чтобы результат записывать в таблицу на рус
    int whiteOrBlack;

    public void Fifth()
    {
        SixthStep.SetOriginalColor(); // нужно убрать цвет клавиши, если 6 задание не закончено
        
        // делаем неактивными все остальные задания
        MyGlobalVariables.SetUnactiveAllTasks();
        MyGlobalVariables.fifthStepFlag = true;

        // так как начинается новое задание, результат обнуляем:
        ClearFieldsForReuse();
        
        GetRandomOneKey(out key, out numberOctave, out randomKeyInRus);

        _practiceStepText.text = $"Нажмите на кнопку Play, чтобы прозвучала нота. " +
        $"Найдите ноту на {numberOctave} октаве и введите ее русское название в поле для ввода.";

        whiteOrBlack = new System.Random().Next(1,3);
        if(whiteOrBlack == 2 && key != "B" && key != "E")
        {
            key = $"{key}{numberOctave}-1";
            randomKeyInRus = $"{randomKeyInRus}#";
        }
        else
            key = $"{key}{numberOctave}";

        keyObject = GameObject.Find(key);
        progress = true;
    }

    public void EditAnswerInTable()
    {
        if(MyGlobalVariables.fifthStepFlag == true && _answerInputField.text != "")
        {
            _answerInTable.text = _answerInputField.text;
            MyGlobalVariables.fifthStepFlag = false;
            _practiceStepText.text = "Ваш ответ записан в таблицу. Посмотрите свой результат в таблице. Поменять результат нельзя. Начните задание заново.";
            if(_answerInTable.text == randomKeyInRus)
            {
                MyGlobalVariables.resultAsPercentageFive = 100;
                _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageFive}%";
            }
            else
            {
                MyGlobalVariables.resultAsPercentageFive = 0;
                _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageFive}%";
            }
            _inputField.Select();
            _inputField.text = "";
        }
    }

    public void Play()
    {
        if(progress)
        {
            keyObject.GetComponent<AudioSource>().PlayOneShot(keyObject.GetComponent<AudioSource>().clip);
        }
    }

    public void ClearFieldsForReuse()
    {
        MyGlobalVariables.resultAsPercentageFive = 0;
        _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageFive}%";
        _answerInTable.text = "";
        MyGlobalVariables._numberOctave = 9;
    }

    void GetRandomOneKey(out string key, out int numberOctave, out string randomKeyInRus)
    {
        int indexOfTheKey = new System.Random().Next(0, MyGlobalVariables.keysNames.Length);
        randomKeyInRus = MyGlobalVariables.keysRusNames[indexOfTheKey];
        key = MyGlobalVariables.keysNames[indexOfTheKey];

        numberOctave = new System.Random().Next(1, 7);
        string nameOctaveInRus = MyGlobalVariables.octavesRusNames[numberOctave];
    }
}
