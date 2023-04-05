using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainView : MonoBehaviour
{
    [SerializeField] private RateView _rateView;
    [SerializeField] private CreditsCounterView _creditsCounterView;
    [SerializeField] private GameView _gameView;

    private GameplayController _gameplayController;
    private void Awake()
    {
        _gameplayController = new GameplayController(_creditsCounterView, _rateView,_gameView);
    }

    private void Start()
    {
        _gameplayController.InitVariantButtons();
    }

    private void OnDestroy()
    {
        _gameplayController.Dispose();
    }
}
