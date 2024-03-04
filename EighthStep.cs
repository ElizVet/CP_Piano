using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EighthStep : MonoBehaviour
{
    public Text _practiceStepText;
    public Text _resultInTable;

    public void Eighth()
    {
        if(SeventhStep.done)
        {
            SixthStep.SetOriginalColor(); // нужно убрать цвет клавиши, если 6 задание не закончено

            // делаем неактивными все остальные задания
            MyGlobalVariables.SetUnactiveAllTasks();
            MyGlobalVariables.eighthStepFlag = true;

            // так как начинается новое задание, результат обнуляем:
            ClearFieldsForReuse();

            _practiceStepText.text = "Сыграйте следующую последовательность. Чтобы начать, нажмите пробел.";
            StartCoroutine(routine: CoroutineSample());
        }
        else
        {
            _practiceStepText.text = "Пройдите предыдущее задание, потом попробуйте снова.";
        }
    }

    private IEnumerator CoroutineSample()
    {
        if(MyGlobalVariables.eighthStepFlag)
        {
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.Space));
            
            _practiceStepText.text = "Выберите 4 октаву.";
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.Keypad4));

            _practiceStepText.text = "до. фа. фа-соль-фа-ми-ре. ре. (точки означают приостановку, чтобы придерживаться ритма)";

            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.C));
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.N));
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.N));
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.M));
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.N));
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.B));
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.V));
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.V));
            yield return new WaitForSeconds(0.2f);

            MyGlobalVariables.resultAsPercentageEight = 25;
            EditResultInTable();
            _practiceStepText.text = "ре. соль. соль-ля-соль-фа-ми. до.";

            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.V));
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.M));
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.M));
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.Comma));
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.M));
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.N));
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.B));
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.C));
            yield return new WaitForSeconds(0.2f);

            MyGlobalVariables.resultAsPercentageEight = 50;
            EditResultInTable();
            _practiceStepText.text = "до. ля. ля-ля#-ля-соль-фа. ре.";

            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.C));
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.Comma));
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.Comma));
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.L));
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.Comma));
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.M));
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.N));
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.V));
            yield return new WaitForSeconds(0.2f);

            MyGlobalVariables.resultAsPercentageEight = 75;
            EditResultInTable();
            _practiceStepText.text = "до-до. ре. соль. ми. фа.";
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.C));
            yield return new WaitForSeconds(0.1f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.C));
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.V));
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.M));
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.B));
            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil( predicate: () => Input.GetKeyDown(KeyCode.N));
            yield return new WaitForSeconds(0.2f);

            MyGlobalVariables.resultAsPercentageEight = 100;
            EditResultInTable();
            _practiceStepText.text = "Юху! Вы прошли это задание! Посмотрите результат в таблице.";
            MyGlobalVariables.eighthStepFlag = false;
        }
    }

    public void EditResultInTable()
    {
        if(MyGlobalVariables.eighthStepFlag == true)
        {
            _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageEight}%";
        }
    }

    public void ClearFieldsForReuse()
    {
        MyGlobalVariables.resultAsPercentageEight = 0;
        _resultInTable.text = $"{MyGlobalVariables.resultAsPercentageEight}%";
        MyGlobalVariables._numberOctave = 9;
    }


}
