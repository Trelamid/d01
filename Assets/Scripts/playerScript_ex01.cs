using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex01 : MonoBehaviour
{
    public enum ColorChar
    {
        yellow,
        red,
        blue
    }
    public float _speed;
    public float _jump;
    public ColorChar _color;
    private Quaternion _zeroRot;
    private bool _isJump = false;
    public bool isFinish;

    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        _zeroRot = new Quaternion(0, 0, 0, transform.rotation.w);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        transform.rotation = _zeroRot;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag is "Platform" or "Player")
        {
            _isJump = false;
        }

        if (collision.gameObject.CompareTag("Finish") && collision.gameObject.name == _color.ToString())
        {
            isFinish = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish") && other.gameObject.name == _color.ToString())
        {
            Debug.Log("Enter");
            isFinish = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish") && other.gameObject.name == _color.ToString())
        {
            Debug.Log("Exit");
            isFinish = false;
        }
    }

    // private void OnTriggerExit2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Finish" && other.gameObject.name == _color.ToString())
    //     {
    //         Debug.Log("111");
    //         isFinish = false;
    //     }
    // }

    void Move()
    {
        // if(Input.GetKey(KeyCode.RightArrow))
        //     _rigidbody2D.velocity =Vector2.right  *_speed * Time.deltaTime;
        // if(Input.GetKey(KeyCode.LeftArrow))
        //     _rigidbody2D.velocity = Vector2.left *_speed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal");
        // _rigidbody2D.MovePosition(Vector2.right * horizontal * _speed);
        transform.Translate(Vector3.right * horizontal * Time.deltaTime * _speed);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJump)
        {
            _isJump = true;
            // Debug.Log(1);
            _rigidbody2D.velocity = Vector2.up * _jump;
        }
    }
}