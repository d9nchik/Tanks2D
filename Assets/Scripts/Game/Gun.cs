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
    private bool isActive = true;

    void Start()
    {
        GameManager.OnGameStateChange += GameManager_OnGameStateChange;
    }

    private void GameManager_OnGameStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.Play:
                isActive = true;
                break;
            case GameState.MainMenu:
            case GameState.Victory:
            case GameState.Lose:
            case GameState.Shop:
            case GameState.Pause:
                isActive = false;
                break;
        }
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= GameManager_OnGameStateChange;
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }

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
