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

        timeElapsed += Time.deltaTime;

        if (timeElapsed > 5)
        {
            timeElapsed = 0;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    protected override void Die()
    {
        base.Die();

        GameManager.Instance.UpdateGameState(GameState.Victory);
    }
}
