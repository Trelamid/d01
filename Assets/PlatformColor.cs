using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColor : MonoBehaviour
{
    public enum Colorr
    {
        blue,yellow,red
    }

    // [SerializeField] private List<GameObject> characters;

    public Colorr trColor;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" &&
            collision.gameObject.GetComponent<playerScript_ex01>()._color.ToString() != trColor.ToString())
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" &&
            collision.gameObject.GetComponent<playerScript_ex01>()._color.ToString() != trColor.ToString())
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" &&
            collision.gameObject.GetComponent<playerScript_ex01>()._color.ToString() != trColor.ToString())
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
