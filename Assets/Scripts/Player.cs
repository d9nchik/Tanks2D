using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Tank
{
    private readonly float speedForce = 15f;
    private readonly float maxSpeed = 10f;
    private Rigidbody2D rb;
    private bool isActive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        float moveX = Input.GetAxis("Horizontal");// -1 to 1

        rb.AddForce(moveX * speedForce * Vector2.right);


        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    protected override void Die()
    {
        base.Die();
        GameManager.Instance.UpdateGameState(GameState.Lose);
    }
}
