using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerObject : MonoBehaviour
{
    
    #region Появление/исчезание окна

    public void OpenOrCloseInfoWindow(GameObject infoWindow)
    {
        if(infoWindow.activeInHierarchy != true)
        {
            infoWindow.SetActive(true); //   АКТИВИРОВАТЬ ОБЪЕКТ, ЧТОБЫ ОТКРЫТЬ ОКНО.  
        }
        else
        {
            infoWindow.SetActive(false); //   АКТИВИРОВАТЬ ОБЪЕКТ, ЧТОБЫ ОТКРЫТЬ ОКНО.  
        }
    }

    #endregion

    #region Изменение цвета элемента установки
    
    static Color _origColorForChange = new Color(0, 0, 0);

    public void ChangeElementColor(GameObject partOfPiano)
    {
        _origColorForChange = partOfPiano.GetComponent<Renderer>().material.color;
        partOfPiano.GetComponent<Renderer>().material.color = new Color(33, 124, 163);
    }
    public void ReturnTheOriginalColor(GameObject partOfPiano)
    {
        partOfPiano.GetComponent<Renderer>().material.color = _origColorForChange;
    }

    #endregion

    #region Изменение информации об элементах установки в окошке
    
    [SerializeField]
    Text workStepText;
    
    public void ChangeInfoAboutPianoPart(GameObject partOfPiano)
    {
        if(partOfPiano.name == "MainPart")
        {
            workStepText.text = workStepText.text = 
            "Это корпус пианино. " +
                "Внутри находятся главные его части для воспроизведения звука " +
                "(футор, дека, чугунная рама, молоточки и тд).";
        }
        if(partOfPiano.name == "MusicStand")
        {
            workStepText.text = workStepText.text = 
            "Пюпитр - подставка для нот.";
        }
        if(partOfPiano.name == "Pedal1")
        {
            workStepText.text = workStepText.text = 
            "Педали изменяют звучание пианино. " +
            "Правая поднимает все демпферы. " +
            "Левая сдвигает молоточки вправо. " +
            "Средняя  оставляет звучать струну, демпферы которой были подняты в момент нажатия педали.";
        }
        if(partOfPiano.name == "Keyboard")
        {
            workStepText.text = workStepText.text = 
            "На подставке находится клавиатура пианино. " +
            "Она содержит 9 октав (0-8). В первой(0) из которых 3 клавиши, а в последней(8) - одна.";
        }
        if(partOfPiano.name == "OneLineOctave") // OneLineOctave
        {
            workStepText.text = workStepText.text = 
            "Интервалы между 2-мя одинаковыми нотами назыв-ся октавами. " +
            "Чтобы определить одну из них, достаточно на клавиатуре найти ноту «до» и, " +
            "двигаясь вниз или вверх по белым клавишам, " +
            "отсчитать восемь штук, дойдя до след-й одноименной ноты.";
        }
    }

    public void ReturnTheOriginalInfo()
    {
        workStepText.text = 
        "Симулятор предназначен для проведения лабораторного " +
        "практикума в виртуальном режиме с установкой, представленной на экране компьютера. " +
        "Для начала воспользуйтесь кнопкой в левом верхнем углу.";
    }

    #endregion

    #region Появление-исчезание sub-панели

        [SerializeField]
        GameObject practiceButton;
        
        public void SetActiveOrUnactiveSubpanel(GameObject subpanel)
        {
            if(subpanel.activeInHierarchy != true)
            {
                subpanel.SetActive(true);
                
                practiceButton.SetActive(false);
            }
            else
            {
                subpanel.SetActive(false);
                workStepText.text = 
                "Если Вы закончили изучать основные элементы установки и готовы приступить к" +
                " практической работе, кликните на кнопку 'Практика' на всплывающей панели справа.";
                
                practiceButton.SetActive(true);
            }
        }

    #endregion


    public static void LockTheNoteKeysForInputField()
    {
        MyGlobalVariables._numberOctave = 9;
    }
}
