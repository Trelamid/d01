using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _players;
    private List<MonoBehaviour> _playersScripts;
    private List<playerScript_ex01> _playersScripts2;
    private int activePlayer = 0;
    private Vector3 offset = new Vector3(0, 0, -8);
    
    private void Start()
    {
        _playersScripts = new List<MonoBehaviour>();
        foreach (GameObject player in _players)
        {
            if (player.GetComponent<playerScript_ex00>())
                _playersScripts.Add(player.GetComponent<playerScript_ex00>());
            else 
                _playersScripts.Add(player.GetComponent<playerScript_ex01>());
        }
    }

    private void LateUpdate()
    {
        if (_players[activePlayer].transform.position.y < -1) return;
        Vector3 posToSO = _players[activePlayer].transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, posToSO, 0.05f);
        transform.position = smoothPosition;
    }

    private void Update()
    {
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
}
