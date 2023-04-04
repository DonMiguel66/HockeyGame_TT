using System;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameButton :MonoBehaviour, IButton
{
    [SerializeField]protected Button _button;
    public Button Button
    {
        get => _button;
        set => _button = value;
    }

    protected virtual void Awake()
    {
        _button = GetComponent<Button>();
        //Debug.Log("Awake");
    }

    protected virtual void Start()
    {
    }

}