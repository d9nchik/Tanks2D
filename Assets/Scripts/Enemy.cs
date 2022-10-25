using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tank
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firePoint;
    private float timeElapsed;


    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > 5)
        {
            timeElapsed = 0;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
