using UnityEngine;

public class BidController
{
    private RateView _rateView;
    private CreditsController _creditController;
    private int _currentRate;

    private int _rateStep = 1;
    public BidController(RateView rateView, CreditsController creditController)
    {
        _rateView = rateView;
        _creditController = creditController;
        _rateView.Init(IncreaseBid, DecreaseBid, _currentRate);
        SetDefaultRate();
    }

    public int CurrentRate => _currentRate;

    private void IncreaseBid()
    {
        if (_creditController.CreditsCount <= _currentRate)
        {
            //Debug.Log("Credits = 0");
            return;
        }
        _currentRate = CurrentRate + _rateStep;
        //_creditController.ChangeCredits(-_rateStep);
        _rateView.ChangeRateCurrentNum(CurrentRate);
        Debug.Log("Increase " + CurrentRate);
    }

    private void DecreaseBid()
    {
        _currentRate = CurrentRate - _rateStep;
        if (CurrentRate <= 0)
        {
            _currentRate = 0;
            return;
        }
        //_creditController.ChangeCredits(_rateStep);
        _rateView.ChangeRateCurrentNum(CurrentRate);
        Debug.Log("Decrease " + CurrentRate);
    }

    public void SetRateToCredit()
    {
        _currentRate = _creditController.CreditsCount;
        _rateView.ChangeRateCurrentNum(_currentRate);
    }

    public void SetDefaultRate()
    {
        _currentRate = 1;
        _rateView.ChangeRateCurrentNum(_currentRate);
    }
}