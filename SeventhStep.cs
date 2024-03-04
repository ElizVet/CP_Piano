using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeventhStep : MonoBehaviour
{
    public Text _practiceStepText;
    public InputField _inputField;
    public Text _answerInputField;
    public Text _answerInTable;
    public Text _resultInTable;

    public GameObject keyC; // до
    public GameObject keyD; // ре
    public GameObject keyE; // ми
    public GameObject keyF; // фа
    public GameObject keyG; // соль
    public GameObject keyA; // ля
    public GameObject blackKeyA; // ля#

    bool flag = true;
    public static bool done = false;

    public void Seventh()
    {
        SixthStep.SetOriginalColor(); // нужно убрать цвет клавиши, если 6 задание не закончено

        // делаем неактивными все остальные задания
        MyGlobalVariables.SetUnactiveAllTasks();
        MyGlobalVariables.seventhStepFlag = true;
        
        // так как начинается новое задание, результат обнуляем:
        ClearFieldsForReuse();

        _practiceStepText.text = "Угадайте название следующей мелодии. Когда будете готовы услышать, нажмите пробел.";

        if(MyGlobalVariables.seventhStepFlag)
        {
            StartCoroutine(routine: CoroutineSample());
        }
    }

    private IEnumerator CoroutineSample()
    {
        if(MyGlobalVariables.seventhStepFlag)
        {
        if(flag)
        {
            flag = false;

            if(MyGlobalVariables.seventhStepFlag == false)
            {   
                flag = true;
                yield break;
            }

            #region автоматическая игра 
            
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.Space));

            PlayAudioAndAnimationKey(keyC);
            yield return new WaitForSeconds(0.6f);

            PlayAudioAndAnimationKey(keyF);
            yield return new WaitForSeconds(0.6f);

            PlayAudioAndAnimationKey(keyF);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(keyG);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(keyF);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(keyE);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(keyD);
            yield return new WaitForSeconds(0.6f);

            PlayAudioAndAnimationKey(keyD);
            yield return new WaitForSeconds(0.6f);

            // //////////////////////

            PlayAudioAndAnimationKey(keyD);
            yield return new WaitForSeconds(0.6f);

            PlayAudioAndAnimationKey(keyG);
            yield return new WaitForSeconds(0.6f);

            PlayAudioAndAnimationKey(keyG);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(keyA);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(keyG);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(keyF);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(keyE);
            yield return new WaitForSeconds(0.6f);

            // //////////////////////

            PlayAudioAndAnimationKey(keyC);
            yield return new WaitForSeconds(0.6f);

            PlayAudioAndAnimationKey(keyC);
            yield return new WaitForSeconds(0.6f);

            PlayAudioAndAnimationKey(keyA);
            yield return new WaitForSeconds(0.6f);

            PlayAudioAndAnimationKey(keyA);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(blackKeyA);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(keyA);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(keyG);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(keyF);
            yield return new WaitForSeconds(0.6f);

            PlayAudioAndAnimationKey(keyD);
            yield return new WaitForSeconds(0.6f);

            PlayAudioAndAnimationKey(keyC);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(keyC);
            yield return new WaitForSeconds(0.4f);

            PlayAudioAndAnimationKey(keyD);
            yield return new WaitForSeconds(0.6f);

            PlayAudioAndAnimationKey(keyG);
            yield return new WaitForSeconds(0.6f);

            PlayAudioAndAnimationKey(keyE);
            yield return new WaitForSeconds(0.6f);

            PlayAudioAndAnimationKey(keyF);

            yield return new WaitForSeconds(0.5f);
            _practiceStepText.text = "Введите название мелодии.";

            #endregion
            
            flag = true;
            done = true;
            MyGlobalVariables.seventhStepFlag = false;
        }
        }
    }

    public void PlayAudioAndAnimationKey(GameObject key){
        key.GetComponent<AudioSource>().PlayOneShot(key.GetComponent<AudioSource>().clip);
        key.GetComponent<Animation>().Play();
    }

    public void EditAnswerInTable()
    {
        if(_practiceStepText.text == "Введите название мелодии." && _answerInputField.text != "")
        {
            _answerInTable.text = _answerInputField.text;
            _practiceStepText.text = "Ваш ответ записан в таблицу. Посмотрите свой результат в таблице. Поменять результат нельзя. Начните задание заново.";

            if(_answerInTable.text == "merry christmas" || _answerInTable.text == "merry cristmas" ||
                _answerInTable.text == "Merry christmas" || _answerInTable.text == "Merry Christmas" ||
                _answerInTable.text == "Merry Cristmas" || _answerInTable.text == "мери кристмас")
            {
                MyGlobalVariables.resultAsPercentageSeven = 100;
                _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageSeven}%";
            }
            else
            {
                MyGlobalVariables.resultAsPercentageSeven = 0;
                _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageSeven}%";
            }
            MyGlobalVariables.seventhStepFlag = false;
            _inputField.Select();
            _inputField.text = "";
        }
    }

    public void ClearFieldsForReuse()
    {
        MyGlobalVariables.resultAsPercentageSeven = 0;
        _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageSeven}%";
        _answerInTable.text = "";
        MyGlobalVariables._numberOctave = 9;

    }

}
