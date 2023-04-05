using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private List<VariantButtonView> _variantButtonViews;
    [SerializeField] private PlayButtonView _playButtonView;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextRateButton;
    [SerializeField] private GameObject _blockVariantButtons;
    [SerializeField] private GameObject _blockRatesButtons;
    [SerializeField] private GameObject _restartPanel;
    
    public List<VariantButtonView> VariantButtonViews => _variantButtonViews;

    public PlayButtonView PlayButtonView => _playButtonView;

    public Button RestartButton => _restartButton;

    public Button NextRateButton => _nextRateButton;

    public void BlockPanels(bool isBlocked)
    {
        if(isBlocked)
        {
            //_blockVariantButtons.SetActive(true);
            _blockRatesButtons.SetActive(false);
            _nextRateButton.gameObject.SetActive(true);
            _playButtonView.gameObject.SetActive(false);
            foreach (var variantButtonView in _variantButtonViews)
            {
                variantButtonView.Button.enabled = false;
            }
        }
        else
        {
            //_blockVariantButtons.SetActive(false);
            _blockRatesButtons.SetActive(true);
            _nextRateButton.gameObject.SetActive(false);
            _playButtonView.gameObject.SetActive(true);
            foreach (var variantButtonView in _variantButtonViews)
            {
                variantButtonView.Button.enabled = true;
            }
        }
        
    }

    public void SetRestartPanel()
    {
        _restartButton.gameObject.SetActive(true);
        _restartPanel.SetActive(true);
        _blockRatesButtons.SetActive(true);
        _blockVariantButtons.SetActive(false);
    }
}