using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class VariantButtonView : GameButton
{
    [SerializeField] private GameObject _winConditionImage;
    [SerializeField] private GameObject _lossConditionImage;

    public GameObject WinConditionImage => _winConditionImage;

    public GameObject LossConditionImage => _lossConditionImage;

    public bool IsSelected { get; set; }

    private Vector3 _defaultScale;

    protected override void Awake()
    {
        base.Awake();
        _defaultScale = transform.localScale;
    }

    public void Init(UnityAction onSelected)
    {
        _button.onClick.AddListener(onSelected);
        //_button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (IsSelected)
        {
            _button.enabled = false;
            transform.DOScale(_defaultScale, 0.3f).OnComplete(() =>_button.enabled = true);
            //transform.localScale = _defaultScale;
        }
        else
        {
            _button.enabled = false;
            transform.DOScale(new Vector3(_defaultScale.x + 0.3f, _defaultScale.y + 0.3f, _defaultScale.z), 0.3f).OnComplete(() =>_button.enabled = true);
            //transform.localScale = new Vector3(_defaultScale.x + 0.3f, _defaultScale.y + 0.3f, _defaultScale.z);
        }
        IsSelected = !IsSelected;
    }

    public void SetWinOrLoss(bool isWin)
    {
        if(isWin)
        {
            _winConditionImage.SetActive(true);
            _lossConditionImage.SetActive(false);
        }
        else
        {
            _lossConditionImage.SetActive(true);
            _winConditionImage.SetActive(false);
        }
    }

    public void SetDefault()
    {
        _winConditionImage.SetActive(false);
        _lossConditionImage.SetActive(false);
        IsSelected = false;
        transform.localScale = _defaultScale;
    }
}