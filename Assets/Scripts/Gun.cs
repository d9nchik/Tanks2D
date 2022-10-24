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
        }
    }
}
