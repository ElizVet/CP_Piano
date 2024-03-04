using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField]
    Transform target;
    float scrollSpeed = 5f;    // скорость вращения и передвижения камеры
    int rotationSensivity = 7;
    public int maxDistance = 15;
    public int minDistance = 7;

    void Start()
    {
        //transform.LookAt(target);
    }

    void Update()
    {
        // Движение камеры влево-право, вниз-вверх ADSW.
        if (!Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Horizontal"); 
            float y = Input.GetAxis("Vertical"); 
            if (x != 0 || y != 0)
            {
            Vector3 newPos = transform.position 
            + (transform.TransformDirection(new Vector3(x, 0, 0)) + Vector3.up * y) 
            / rotationSensivity;
            if (ControlDistanceMove(Vector3.Distance(newPos, target.position))) transform.position = newPos;
            }
        }
        // Приближение камеры колёсиком мыши.
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward 
            * Input.GetAxis("Mouse ScrollWheel") * scrollSpeed);
            if (ControlDistanceScroll(Vector3.Distance(newPos, target.position))) transform.position = newPos;
        }

        // Вращение вокруг установки.
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * scrollSpeed);
        }
    }

    // Функция ограничения пределов ПРОКРУТКИ камеры.
    bool ControlDistanceScroll (float distance)
    {
        // if (distance > minDistance && distance < maxDistance) 
        // {
        //     return true;
        // }
        return true;
    }
    // Функция ограничения пределов ДВИЖЕНИЯ камеры.
    bool ControlDistanceMove (float distance)
    {
        // if (distance > -2 && distance < 7) 
        // {
        //     return true;
        // }
        return true;
    }
}