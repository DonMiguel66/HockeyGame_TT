using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class GameplayController
{
    private BidController _bidController;
    private CreditsController _creditsController;
    private CreditsCounterView _creditsCounterView;
    private RateView _rateView;
    private GameView _gameView;

    private List<VariantButtonView> _variantButtonViews;
    private VariantButtonView _activeVariantButton;
    private VariantButtonView _winVariant;
    public GameplayController(CreditsCounterView creditsCounterView, RateView rateView, GameView gameView)
    {
        _gameView = gameView;
        _variantButtonViews = _gameView.VariantButtonViews;
        Debug.Log(_variantButtonViews.Count);
        _creditsCounterView = creditsCounterView;
        _rateView = rateView;
        _creditsController = new CreditsController(_creditsCounterView);
        _bidController = new BidController(_rateView, _creditsController);
        _gameView.PlayButtonView.Button.onClick.AddListener(CheckSelectedCard);
        _gameView.NextRateButton.onClick.AddListener(SetNewGameStep);
        _gameView.RestartButton.onClick.AddListener(RestartGame);
        
        
        _gameView.NextRateButton.gameObject.SetActive(false);
        _gameView.PlayButtonView.gameObject.SetActive(true);
        _gameView.RestartButton.gameObject.SetActive(false);
        //InitVariantButtons();
    }

    public void InitVariantButtons()
    {
        foreach (var variantButtonView in _variantButtonViews)
        {
            variantButtonView.Init((() => OnVariantButtonSelect(variantButtonView)));
        }
    }

    private void OnVariantButtonSelect(VariantButtonView variantButtonView)
    {
        Debug.Log(variantButtonView.name);
        /*if(_activeVariantButton == variantButtonView)
            return;
        if(_activeVariantButton == null)
            _activeVariantButton = variantButtonView;
        _activeVariantButton.OnClick();
        _activeVariantButton = variantButtonView;
        _activeVariantButton.OnClick();*/
        variantButtonView.OnClick();
        if(_activeVariantButton != null)
            _activeVariantButton.OnClick();
        _activeVariantButton = variantButtonView;
    }

    private void SetWinCard()
    {
        _winVariant = _variantButtonViews[new Random().Next(_variantButtonViews.Count)];
        foreach (var variantButtonView in _variantButtonViews)
        {
            variantButtonView.SetWinOrLoss(variantButtonView == _winVariant);
        }
    }

    private void CheckSelectedCard()
    {
        if(_activeVariantButton == null)
            return;
        _gameView.RestartButton.gameObject.SetActive(true);
        SetWinCard();
        if(_winVariant == _activeVariantButton)
            _creditsController.ChangeCredits(_bidController.CurrentRate);
        else
        {
            _creditsController.ChangeCredits(-_bidController.CurrentRate);
        }
        _gameView.BlockPanels(true);
        CheckCreditsToContinue();
    }

    private void SetNewGameStep()
    {
        _gameView.BlockPanels(false);
        _activeVariantButton = null;
        foreach (var variantButtonView in _variantButtonViews)
        {
            variantButtonView.SetDefault();
        }
        if (_creditsController.CreditsCount < _bidController.CurrentRate)
        {
            _bidController.SetRateToCredit();
        }
    }

    private void RestartGame()
    {
        _activeVariantButton = null;
        foreach (var variantButtonView in _variantButtonViews)
        {
            variantButtonView.SetDefault();
        }
        _gameView.BlockPanels(false);
        _creditsController.SetDefaultCredits();
        _bidController.SetDefaultRate();
        
        _gameView.NextRateButton.gameObject.SetActive(false);
        _gameView.PlayButtonView.gameObject.SetActive(true);
        _gameView.RestartButton.gameObject.SetActive(false);
    }

    private void CheckCreditsToContinue()
    {
        if(_creditsController.CreditsCount == 0)
        {
            _gameView.BlockPanels(true);
            _gameView.NextRateButton.gameObject.SetActive(false);
            _gameView.PlayButtonView.gameObject.SetActive(false);
            _gameView.RestartButton.gameObject.SetActive(true);
        }
    }
}