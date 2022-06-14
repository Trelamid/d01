using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ButtonController : MonoBehaviour
{
    public int buttonID = 0;
    public bool state = false;
    public static List<ButtonController> buttons = new List<ButtonController>();

    private Light _light;
    // public static int countButtons = 0;

    private void Start()
    {
        buttons.Add(this);
        _light = GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            Debug.Log("StateButtons: " + StateButtons(new int[] {0, 1}));
            Debug.Log(StateButton(1));
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            if (state == false)
            {
                state = true;
                _light.color = Color.green;
            }
            else
            {
                state = false;
                _light.color = Color.red;
            }
            Debug.Log("button: " + buttonID + state);
        }
    }
    /// <summary>Получить состояние кнопки</summary>
    /// <param name="id">ID кнопки</param>
    /// <returns>Если хотя бы одна кнопка с id нажата, возвращает true, иначе - false</returns>
    public static bool StateButton(int id)
    {
        int len = buttons.Count;
        for (int i = 0; i < len; i++)
            if (buttons[i].buttonID == id && buttons[i].state)
                return true;
        return false;
    }
    /// <summary> Получить состояние всех кнопок </summary>
    /// <returns>Возвращает true, когда все кнопки на уровне нажаты</returns>
    public static bool StateAllButtons()
    {
        foreach (var button in buttons)
        {
            if (button.state != true)
                return (false);
        }
        return (true);
    }
    /// <summary> Получить состояние кнопок</summary>
    /// <param name="ids">id кнопок, которые нужно проверить</param>
    /// <returns>если все кнопки из массива нажаты, возвращает true, иначе - false</returns>
    public static bool StateButtons(int[] ids)
    {
        int i = 0;
        int length = ids.Length;
        int listLen = buttons.Count;
        while (i < length)
        {
            while (ids[i] > listLen) i++;
            if(!StateButton(ids[i++]))
                return (false);
        }
        return (true);
    }
}
