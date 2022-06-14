using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public int distance = 3;

    private bool reverse;

    private int rev = 1;

    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > startPos.x + distance)
            rev = -1;
        else if (transform.position.x < startPos.x - distance)
            rev = 1;
        
        transform.Translate(Vector2.right * rev * Time.deltaTime);
    }
}
