using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private KeyCode keyGunDown;
    [SerializeField]
    private KeyCode keyGunUp;
    [SerializeField]
    private KeyCode keyShoot;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firePoint;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(keyGunDown))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -30), rotationSpeed);
        } else if (Input.GetKey(keyGunUp))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 60), rotationSpeed);
        } else if (Input.GetKeyDown(keyShoot))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
