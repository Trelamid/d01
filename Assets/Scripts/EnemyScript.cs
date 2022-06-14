using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bulletObj;
    [SerializeField] private GameObject _placeOfSpawn;
    [SerializeField] private playerScript_ex01.ColorChar target;

    [SerializeField] private float _rateOfFire = 2f;
    private float _rate = 0;

    private void FixedUpdate()
    {
        if ((_rate += Time.deltaTime) >= _rateOfFire)
        {
            var bul = Instantiate(_bulletObj[(int)target], _placeOfSpawn.transform.position, transform.rotation);
            bul.GetComponent<Bullet>().colorChar = target;
            bul.SetActive(true);
            _rate = 0;
        }
    }
    
}
