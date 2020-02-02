using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ammoCounterText;
    [SerializeField] int bulletCounter = 7;

    void Update()
    {
        ammoCounterText.text = bulletCounter.ToString();
    }
    public int GetBulletCounter()
    {
        return bulletCounter;
    }
    public void SetBulletCounter(int value)
    {
        bulletCounter = value;
    }
    public void ShootBullet()
    {
        bulletCounter--;
    }
}
