using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private float _elapsedTime = 0f;
    public float ElapsedTime => _elapsedTime;

    [SerializeField] private float _gameOverTime = 20f;
    [SerializeField] private GameObject _npc;

    private bool _isGameOver = false;
    public event Action OnGameOver;


    private void Awake()
    {
        SingletonInit();
    }

    private void Start()
    {
        ResetGame();
    }

    private void Update()
    {
        if (_elapsedTime >= _gameOverTime)
        {
            if (!_isGameOver)
            {
                _isGameOver = true;
                SetActiveNPC(false);
                OnGameOver?.Invoke();
            }
        }
        else
        {
            _elapsedTime += Time.deltaTime;
        }
    }


    public void ResetGame()
    {
        _elapsedTime = 0f;
        _isGameOver = false;
        SetActiveNPC(true);
    }


    private void SetActiveNPC(bool active) => _npc.SetActive(active);
}
