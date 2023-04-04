using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RateView : MonoBehaviour
{
    [SerializeField] private TMP_Text _rateCountText;
    [SerializeField] private Button _increaseBidButton;
    [SerializeField] private Button _decreaseBidButton;


    public TMP_Text RateCountText => _rateCountText;

    public Button IncreaseBid => _increaseBidButton;

    public Button DecreaseButton => _decreaseBidButton;

    public void Init(UnityAction onIncreaseRate, UnityAction onDecreaseRate, int currentRate)
    {
        _increaseBidButton.onClick.AddListener(onIncreaseRate);
        _decreaseBidButton.onClick.AddListener(onDecreaseRate);
        ChangeRateCurrentNum(currentRate);
    }

    public void ChangeRateCurrentNum(int currentRate)
    {
        _rateCountText.text = currentRate.ToString();
    }
}