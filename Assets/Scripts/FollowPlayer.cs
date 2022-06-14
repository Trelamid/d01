using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _players;
    private List<Character> _playersScripts;
    // private List<playerScript_ex01> _playersScripts2;
    private int activePlayer = 0;
    private Vector3 offset = new Vector3(0, 0, -8);
    private bool _pause = false;
    
    private void Start()
    {
        _playersScripts = new List<Character>();
        foreach (GameObject player in _players)
        {
            if (player.GetComponent<playerScript_ex00>())
                _playersScripts.Add(player.GetComponent<playerScript_ex00>());
            else if(player.GetComponent<playerScript_ex01>())
                _playersScripts.Add(player.GetComponent<playerScript_ex01>());
        }
    }

    private void LateUpdate()
    {
        if (_players[activePlayer].transform.position.y < -1) return;
        Vector3 posToSO = _players[activePlayer].transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, posToSO, 0.05f);
        transform.position = smoothPosition;
        transform.position = _players[activePlayer].transform.position + offset;
    }

    private void Update()
    {
        if (_playersScripts[0].isFinish && _playersScripts[1].isFinish && _playersScripts[2].isFinish)
        {
            if (5 > SceneManager.GetActiveScene().buildIndex)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (_pause) return;
        if (Input.GetKey(KeyCode.Alpha1))
        {
            activePlayer = 0;
            _playersScripts[0].enabled = true;
            _playersScripts[1].enabled = false;
            _playersScripts[2].enabled = false;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            activePlayer = 1;
            _playersScripts[0].enabled = false;
            _playersScripts[1].enabled = true;
            _playersScripts[2].enabled = false;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            activePlayer = 2;
            _playersScripts[0].enabled = false;
            _playersScripts[1].enabled = false;
            _playersScripts[2].enabled = true;
        }
    }

    public void Freeze()
    {
        _pause = true;
        _playersScripts[0].enabled = false;
        _playersScripts[1].enabled = false;
        _playersScripts[2].enabled = false;
    }
}
