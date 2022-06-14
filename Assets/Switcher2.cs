using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher2 : MonoBehaviour
{
    public GameObject Door;
    private bool isDone;
    public PlatformColor.Colorr color;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isDone && collision.gameObject.GetComponent<playerScript_ex01>()._color.ToString() == color.ToString())
        {
            isDone = true;
            StartCoroutine(cor());
        }
    }

    IEnumerator cor()
    {
        for (int i = 0; i < 130; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Door.transform.position += Vector3.up*0.005f;
        }
        yield break;
    }
}
