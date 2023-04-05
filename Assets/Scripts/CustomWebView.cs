using System.Collections.Generic;
using UnityEngine;

public class CustomWebView : MonoBehaviour
{
    /*private const string DEFAULT_URL = "https://www.google.com";

    [SerializeField]private string _urlInput;

    public string URLInput
    {
        get => _urlInput;
        set => _urlInput = value;
    }

    private void Awake()
    {
        //_urlInput = DEFAULT_URL;
    }

    public void OpenWebView()
    {
        if (string.IsNullOrEmpty(_urlInput) == false)
        {
            GpmWebView.ShowUrl(_urlInput, GetConfiguration(), OnWebViewCallback, GetCustomSchemeList());
        }
        else
        {
            Debug.LogError("[SampleWebView] Input url is empty.");
        }
    }
    private GpmWebViewRequest.Configuration GetConfiguration()
    {
        GpmWebViewRequest.CustomSchemePostCommand customSchemePostCommand = new GpmWebViewRequest.CustomSchemePostCommand();
        customSchemePostCommand.Close("CUSTOM_SCHEME_POST_CLOSE");

        return new GpmWebViewRequest.Configuration()
        {
            style =  GpmWebViewStyle.FULLSCREEN,
            orientation = GpmOrientation.UNSPECIFIED,
            isClearCache = true,
            isClearCookie = false,
            title = string.Empty,
            navigationBarColor = "#4B96E6",

            isNavigationBarVisible = false,
            isBackButtonVisible = true,
            isForwardButtonVisible = true,
            supportMultipleWindows = true,

            customSchemePostCommand = customSchemePostCommand,

            position = GetConfigurationPosition(),
            size = GetConfigurationSize(),
            margins = GetConfigurationMargins(),

#if UNITY_IOS
            contentMode = GpmWebViewContentMode.RECOMMENDED,
            isMaskViewVisible = true,
            isAutoRotation = true
#endif
        };
    }

    private GpmWebViewRequest.Position GetConfigurationPosition()
    {
        bool hasValue = false;
        /*if (string.IsNullOrEmpty(popupXInput.text) == false && string.IsNullOrEmpty(popupYInput.text) == false)
        {
            hasValue = true;
        }#1#

        int x = 0;
        //int.TryParse(popupXInput.text, out x);

        int y = 0;
        //int.TryParse(popupYInput.text, out y);

        return new GpmWebViewRequest.Position
        {
            hasValue = hasValue,
            x = x,
            y = y
        };
    }

    private GpmWebViewRequest.Size GetConfigurationSize()
    {
        bool hasValue = false;
        /*if (string.IsNullOrEmpty(popupWidthInput.text) == false && string.IsNullOrEmpty(popupHeightInput.text) == false)
        {
            hasValue = true;
        }#1#

        int width = 0;
        //int.TryParse(popupWidthInput.text, out width);

        int height = 0;
        //int.TryParse(popupHeightInput.text, out height);

        return new GpmWebViewRequest.Size
        {
            hasValue = hasValue,
            width = width,
            height = height
        };
    }

    private GpmWebViewRequest.Margins GetConfigurationMargins()
    {
        bool hasValue = false;
        /*if (string.IsNullOrEmpty(popupMarginsInput.text) == false)
        {
            hasValue = true;
        }#1#

        int margins = 0;
        //int.TryParse(popupMarginsInput.text, out margins);

        return new GpmWebViewRequest.Margins
        {
            hasValue = hasValue,
            left = margins,
            top = margins,
            right = margins,
            bottom = margins
        };
    }
    
    private List<string> GetCustomSchemeList()
    {
        List<string> customSchemeList = null;
        /*if (string.IsNullOrEmpty(customSchemeInput.text) == false)
        {
            string[] schemes = customSchemeInput.text.Split(',');
            customSchemeList = new List<string>(schemes);
        }#1#
        return customSchemeList;
    }

    private void OnWebViewCallback(GpmWebViewCallback.CallbackType callbackType, string data, GpmWebViewError error)
    {
        Debug.Log("OnWebViewCallback: " + callbackType);
        switch (callbackType)
        {
            case GpmWebViewCallback.CallbackType.Open:
                if (error != null)
                {
                    Debug.LogFormat("Fail to open WebView. Error:{0}", error);
                }

                break;
            case GpmWebViewCallback.CallbackType.Close:
                if (error != null)
                {
                    Debug.LogFormat("Fail to close WebView. Error:{0}", error);
                }

                break;
            case GpmWebViewCallback.CallbackType.PageLoad:
                if (string.IsNullOrEmpty(data) == false)
                {
                    Debug.LogFormat("Loaded Page:{0}", data);
                }

                break;
            case GpmWebViewCallback.CallbackType.MultiWindowOpen:
                Debug.Log("MultiWindowOpen");
                break;
            case GpmWebViewCallback.CallbackType.MultiWindowClose:
                Debug.Log("MultiWindowClose");
                break;
            case GpmWebViewCallback.CallbackType.Scheme:
                Debug.LogFormat("Scheme:{0}", data);
                break;
            case GpmWebViewCallback.CallbackType.GoBack:
                Debug.Log("GoBack");
                break;
            case GpmWebViewCallback.CallbackType.GoForward:
                Debug.Log("GoForward");
                break;
            case GpmWebViewCallback.CallbackType.ExecuteJavascript:
                Debug.LogFormat("ExecuteJavascript data : {0}, error : {1}", data, error);
                break;
        }
    }*/
}
