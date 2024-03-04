using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanel : MonoBehaviour
{
    RectTransform UIGameobject; // трансформация UI Панели
    float width;    // ширина панели
    float changeX;  // смещение панели
    float speedPanel;   // скорость закрытия панели
 
    enum states      {  // перечисление состояний панели
        open,   //открыта
        close,  //закрыта
        opening, //открывается
        closing //закрывается
    }
    states state = states.close; // изначальное состояние закрытое


    void Start()
    {
        UIGameobject = gameObject.GetComponent<RectTransform>();
        width = UIGameobject.sizeDelta.x - 40;
        speedPanel = 6; // скорость движения панели
    }

    void FixedUpdate()
    {
        if (state == states.closing) // закрытие
        {
            // anchoredPosition - позиция центра RectTransform с учетом опорной точки привязки
            float x = UIGameobject.anchoredPosition.x; 
            float y = UIGameobject.anchoredPosition.y;
            
            // задаем изменение позиции.
            x += speedPanel;
            changeX += speedPanel;
            
            // применяем изменение позиции панели
            UIGameobject.anchoredPosition = new Vector2(x, y);
            
            if (changeX > width)
            {
                state = states.close;
                changeX = 0; // смещение прекращается
            }
        }
        if (state == states.opening)
        {
            float x = UIGameobject.anchoredPosition.x;
            float y = UIGameobject.anchoredPosition.y;
            x -= speedPanel;
            changeX += speedPanel;
            UIGameobject.anchoredPosition = new Vector2(x, y);
            if (changeX > width)
            {
                state = states.open; // статус меняется на открыто
                changeX = 0; // смешение прекращается
            }
        }
            if (state == states.closing)
        {
            float x = UIGameobject.anchoredPosition.x; 
            float y = UIGameobject.anchoredPosition.y;
            
            x += speedPanel;
            changeX += speedPanel;

            UIGameobject.anchoredPosition = new Vector2(x, y);
            if (changeX > width)
            {
                state = states.close;
                changeX = 0;
            }
        }

        if (state == states.opening) // открытие
        {
            float x = UIGameobject.anchoredPosition.x;
            float y = UIGameobject.anchoredPosition.y;
            x -= speedPanel;
            changeX += speedPanel;
            UIGameobject.anchoredPosition = new Vector2(x, y);
            if (changeX > width)
            {
                state = states.open; // статус меняется на открыто
                changeX = 0; // смешение прекращается
            }
        }
    }

    public void OpenOrClosePanel()
    {
        if (state == states.close) 
            state = states.opening;
        if (state == states.open) 
            state = states.closing;
    }
}
