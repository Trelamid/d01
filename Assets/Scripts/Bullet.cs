using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public playerScript_ex01.ColorChar colorChar;

	private void Start()
	{
		StartCoroutine(BulletLife());
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (other.gameObject.GetComponent<playerScript_ex01>()._color == colorChar)
			{
				other.gameObject.GetComponent<playerScript_ex01>().Kill();
			}
		}
		Destroy(gameObject);
	}

	private void Update()
	{
		transform.Translate(Vector3.left * Time.deltaTime * 2);
	}

	private IEnumerator BulletLife()
	{
		yield return new WaitForSeconds(2f);
		gameObject.SetActive(false);
		Destroy(gameObject);
	}
	
}
