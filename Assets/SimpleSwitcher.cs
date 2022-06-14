using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSwitcher : MonoBehaviour
{
    public GameObject Door;
    private bool isDone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isDone)
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
