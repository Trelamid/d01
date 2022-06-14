using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher4 : MonoBehaviour
{
    public GameObject platform;
    public Color _red;
    public Color _blue;
    public Color _yellow;

    private bool pressF;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("auf1");
        if (collision.gameObject.tag == "Player" && pressF)
        {
            pressF = false;
            Debug.Log("auf2");
            if (platform.gameObject.tag == "Platformblue")
            {
                platform.GetComponent<SpriteRenderer>().color = _red;
                platform.GetComponent<PlatformColor>().trColor = PlatformColor.Colorr.red;
                platform.gameObject.tag = "Platformred";
            }
            else if (platform.gameObject.tag == "Platformred")
            {
                Debug.Log("red");
                platform.GetComponent<SpriteRenderer>().color = _yellow;
                platform.GetComponent<PlatformColor>().trColor = PlatformColor.Colorr.yellow;
                platform.gameObject.tag = "Platformyellow";
            }
            else if (platform.gameObject.tag == "Platformyellow")
            {
                platform.GetComponent<SpriteRenderer>().color = _blue;
                platform.GetComponent<PlatformColor>().trColor = PlatformColor.Colorr.blue;
                platform.gameObject.tag = "Platformblue";
            }
            
            
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            pressF = true;
    }
}
