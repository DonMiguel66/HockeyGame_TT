using UnityEngine;

public class CreditsController
{
    private CreditsCounterView _creditsCounterView;

    private int _creditsCount;
    public CreditsController(CreditsCounterView creditsCounterView)
    {
        _creditsCounterView = creditsCounterView;
        SetDefaultCredits();
        _creditsCounterView.Init(_creditsCount);
    }

    public int CreditsCount => _creditsCount;

    public void ChangeCredits(int num)
    {
        _creditsCount += num;
        if (_creditsCount < 0)
        {
            _creditsCount = 0;
            Debug.Log("Zero credits");
        }
        _creditsCounterView.ChangeCreditsCount(_creditsCount);
    }

    public void SetDefaultCredits()
    {
        _creditsCount = 10;
        _creditsCounterView.ChangeCreditsCount(_creditsCount);
    }
}