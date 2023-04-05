using System;
using System.IO;
using UnityEngine;

public class CreditsController : IDisposable
{
    private CreditsCounterView _creditsCounterView;

    private Credits _currentCreditsCount;
    private Credits _topCreditsCount;
    
    private DataManager<Credits> _dataManager = new DataManager<Credits>();
    private readonly string _jsonScoresPath = Path.Combine(Application.persistentDataPath, "TopCredits.json");
    public CreditsController(CreditsCounterView creditsCounterView)
    {
        _currentCreditsCount = new Credits();
        _topCreditsCount = new Credits();
        _creditsCounterView = creditsCounterView;
        SetDefaultCredits();
        _creditsCounterView.Init(_currentCreditsCount.value);
        if (!File.Exists(_jsonScoresPath)) return;
        _topCreditsCount = _dataManager.LoadFromJson(_jsonScoresPath);

        _creditsCounterView.ChangeTopCreditsCount(_topCreditsCount.value);
    }

    public int CurrentCreditsCount => _currentCreditsCount.value;
    public int TopCreditsCount => _topCreditsCount.value;

    public void ChangeCredits(int num)
    {
        _currentCreditsCount.value += num;
        if (_currentCreditsCount.value < 0)
        {
            _currentCreditsCount.value = 0;
            Debug.Log("Zero credits");
        }
        _creditsCounterView.ChangeCurrentCreditsCount(_currentCreditsCount.value);
    }

    public void SetDefaultCredits()
    {
        SaveTopCredits();
        _currentCreditsCount.value = 10;
        _creditsCounterView.ChangeCurrentCreditsCount(_currentCreditsCount.value);
    }

    public bool CheckNewRecord()
    {
        if (_topCreditsCount.value > _currentCreditsCount.value || _currentCreditsCount.value<= 10) return false;
        _topCreditsCount.value = _currentCreditsCount.value;
        _creditsCounterView.ChangeTopCreditsCount(_topCreditsCount.value);
        return true;
    }
    
    public void SaveTopCredits()
    {
        Debug.Log("Save");
        if (!CheckNewRecord()) return;
        _dataManager.SaveToJson(_currentCreditsCount, _jsonScoresPath);
    }
    
    public void Dispose()
    {
        SaveTopCredits();
    }
}


[Serializable]
public class Credits
{
    public int value;
}