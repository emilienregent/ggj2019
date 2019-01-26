using UnityEngine;
using System.Collections;
using System;

public class GameManager
{
    //Singleton
    private static GameManager _instance = null;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }

            return _instance;
        }
    }

    //Members
    public static int TIME_BEFORE_END = 5;

    private static GameState _gameState = default(GameState);
    public static GameState gameState { get { return _gameState; } }

    public event EventHandler Initialized;
    public event EventHandler<int> TimerUpdated;
    public event EventHandler<int> TimerEnded;

    private bool _isReady = false;
    public bool isReady { get { return _isReady; } }

    private int _elapsedTime = 0;
    public int elapsedTime { get { return _elapsedTime; } }

    //Methods
    public void Initialize()
    {
        _gameState = GameState.INITIALIZED;

        UnityEngine.Debug.Log("Game initialized.");

        Initialized?.Invoke(this, null);
    }

    public void UpdateTimer()
    {
        _elapsedTime++;

        if (_elapsedTime <= GameManager.TIME_BEFORE_END)
        {
            TimerUpdated?.Invoke(this, _elapsedTime);
        }
        else
        {
            TimerEnded?.Invoke(this, _elapsedTime);
        }
    }

    public void StartIntro()
    {
        _gameState = GameState.INTRO;

        UnityEngine.Debug.Log("Intro running.");
    }

    public void StartGame()
    {
        _gameState = GameState.RUNNING;

        UnityEngine.Debug.Log("Game running.");
    }

    public static void Destroy()
    {
        _instance = null;
    }
}