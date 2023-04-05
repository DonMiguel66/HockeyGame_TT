using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    private void Awake()
    {
        if (SystemInfo.deviceModel.ToLower().Contains("google") ||
            SystemInfo.deviceName.ToLower().Contains("google"))
        {
            
        }
    }
}
