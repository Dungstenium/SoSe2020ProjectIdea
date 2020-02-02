using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] float damage = 10.0f;
    [SerializeField] float range = 100.0f;
    [SerializeField] GameObject shootingRay;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            StartCoroutine(ShootingEffect());
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
    IEnumerator ShootingEffect()
    {
        shootingRay.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        shootingRay.SetActive(false);
    }
}
