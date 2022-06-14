using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher3 : MonoBehaviour
{
    public GameObject blueDoor;
    public GameObject yellowDoor;
    public GameObject redDoor;
    private bool isDone;
    public PlatformColor.Colorr color;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isDone)
        {
            isDone = true;
            if (collision.gameObject.GetComponent<playerScript_ex01>()._color.ToString() ==
                PlatformColor.Colorr.blue.ToString())
            {
                gameObject.GetComponent<SpriteRenderer>().color = blueDoor.GetComponent<SpriteRenderer>().color;
                StartCoroutine(cor(blueDoor));

            }
            else if (collision.gameObject.GetComponent<playerScript_ex01>()._color.ToString() ==
                PlatformColor.Colorr.yellow.ToString())
            {
                gameObject.GetComponent<SpriteRenderer>().color = yellowDoor.GetComponent<SpriteRenderer>().color;
                StartCoroutine(cor(yellowDoor));
            }
            else if (collision.gameObject.GetComponent<playerScript_ex01>()._color.ToString() ==
                PlatformColor.Colorr.red.ToString())
            {
                gameObject.GetComponent<SpriteRenderer>().color = redDoor.GetComponent<SpriteRenderer>().color;
                StartCoroutine(cor(redDoor));
            }
        }
    }

    IEnumerator cor(GameObject Door)
    {
        for (int i = 0; i < 130; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Door.transform.position += Vector3.up*0.005f;
        }
        yield break;
    }
}
