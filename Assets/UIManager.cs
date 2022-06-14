using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    public void SetDiedScreen() => gameOver.SetActive(true);
}
