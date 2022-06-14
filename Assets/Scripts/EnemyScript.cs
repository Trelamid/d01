using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject _bulletObj;
    [SerializeField] private GameObject _placeOfSpawn;

    private void Start()
    {
        Instantiate(_bulletObj, transform);
    }
}
