using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSc : MonoBehaviour
{
    public GameObject _yellow;
    public GameObject _blue;
    public GameObject _red;
    private playerScript_ex00 _yellowSc;
    private playerScript_ex00 _blueSc;
    private playerScript_ex00 _redSc;
    
    private Rigidbody2D _yellowR;
    private Rigidbody2D _blueR;
    private Rigidbody2D _redR;

    private Coroutine moveCor;
    void Start()
    {
        _blueSc = _blue.GetComponent<playerScript_ex00>();
        _yellowSc = _yellow.GetComponent<playerScript_ex00>();
        _redSc = _red.GetComponent<playerScript_ex00>();

        _yellowR = _yellow.GetComponent<Rigidbody2D>();
        _blueR = _blue.GetComponent<Rigidbody2D>();
        _redR = _red.GetComponent<Rigidbody2D>();
        
        // _blue.GetComponent<Rigidbody2D>().WakeUp();
        // _yellow.GetComponent<Rigidbody2D>().Sleep();
        // _red.GetComponent<Rigidbody2D>().Sleep();

        // _blueR.isKinematic = false;
        // _yellowR.isKinematic = true;
        // _redR.isKinematic = true;
        
        _blueSc.enabled = true;
        _yellowSc.enabled = false;
        _redSc.enabled = false;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (_blueSc.enabled)
            MoveCamera(_blue.transform.position);
        else if(_yellowSc.enabled)
            MoveCamera(_yellow.transform.position);
        else if(_redSc.enabled)
            MoveCamera(_red.transform.position);

        if (_blueSc.isFinish && _yellowSc.isFinish && _redSc.isFinish)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        ChangeChar();
    }

    void MoveCamera(Vector3 aim)
    {
        transform.position = new Vector3(aim.x, aim.y, aim.z - 0.5f);
        // if(moveCor != null)
        //     StopCoroutine(moveCor);
        // moveCor = StartCoroutine(MoveCameraCor(aim));
    }
    IEnumerator MoveCameraCor(GameObject aim)
    {
        for (float i = 0; i < 1; i += 0.01f)
        {
            yield return new WaitForFixedUpdate();
            transform.position = Vector3.Lerp(transform.position, aim.transform.position, i);
        }
        yield break;
    }
    
    void ChangeChar()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // _blue.GetComponent<Rigidbody2D>().WakeUp();
            // _yellow.GetComponent<Rigidbody2D>().Sleep();
            // _red.GetComponent<Rigidbody2D>().Sleep();
            
            // _blueR.isKinematic = false;
            // _yellowR.isKinematic = true;
            // _redR.isKinematic = true;
            
            // _blueR.constraints = RigidbodyConstraints2D.FreezeRotation;
            // _yellowR.constraints = RigidbodyConstraints2D.FreezeAll;
            // _redR.constraints = RigidbodyConstraints2D.FreezeAll;
            
            _blueR.mass = 50;
            _yellowR.mass = 1000;
            _redR.mass = 1000;

            _blueSc.enabled = true;
            _yellowSc.enabled = false;
            _redSc.enabled = false;

            // MoveCamera(_blue);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _blueR.mass = 1000;
            _yellowR.mass = 25;
            _redR.mass = 1000;
            
            // Destroy(_blue.GetComponent<Rigidbody2D>());
            // Destroy(_yellow.GetComponent<Rigidbody2D>().WakeUp());
            // Destroy(_red.GetComponent<Rigidbody2D>());
            
            // _blueR.constraints = RigidbodyConstraints2D.FreezeAll;
            // _yellowR.constraints = RigidbodyConstraints2D.FreezeRotation;
            // _redR.constraints = RigidbodyConstraints2D.FreezeAll;
            
            _blueSc.enabled = false;
            _yellowSc.enabled = true;
            _redSc.enabled = false;
            
            // MoveCamera(_yellow);

        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            // _blue.GetComponent<Rigidbody2D>().Sleep();
            // _yellow.GetComponent<Rigidbody2D>().Sleep();
            // _red.GetComponent<Rigidbody2D>().WakeUp();
            
            // _blueR.isKinematic = true;
            // _yellowR.isKinematic = true;
            // _redR.isKinematic = false;
            
            _blueR.mass = 1000;
            _yellowR.mass = 1000;
            _redR.mass = 10;
            
            // _blueR.constraints = RigidbodyConstraints2D.FreezeAll;
            // _yellowR.constraints = RigidbodyConstraints2D.FreezeAll;
            // _redR.constraints = RigidbodyConstraints2D.FreezeRotation;
            
            _blueSc.enabled = false;
            _yellowSc.enabled = false;
            _redSc.enabled = true;
            
            // MoveCamera(_red);
        }
    }
}
