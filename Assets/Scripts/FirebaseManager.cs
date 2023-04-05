using System;
using System.Threading.Tasks;
using Firebase.Extensions;
using Firebase.RemoteConfig;
using UnityEngine;

namespace Firebase
{
    public class FirebaseManager : MonoBehaviour
    {
        private FirebaseApp _firebaseApp;
        private FirebaseRemoteConfig _remoteConfig;

        public event Action OnConnectionError;
        private void Awake()
        {
            CreateFireBase();
            ConfirmGooglePlayServices();
            DontDestroyOnLoad(this);
            //await FetchDataAsync();
        }

        private void CreateFireBase()
        {
            _firebaseApp = FirebaseApp.Create();
        }

        private void ConfirmGooglePlayServices()
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                    _firebaseApp = FirebaseApp.DefaultInstance;
                else
                    Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
            });
        }
        
        public Task FetchDataAsync() {
            Debug.Log("Fetching data...");
            Task fetchTask = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
            return fetchTask.ContinueWithOnMainThread(FetchComplete);
        }
        
        private void FetchComplete(Task fetchTask) {
            if (!fetchTask.IsCompleted) {
                Debug.LogError("Retrieval hasn't finished.");
                OnConnectionError?.Invoke();
                return;
            }

            _remoteConfig = FirebaseRemoteConfig.DefaultInstance;
            var info = _remoteConfig.Info;
            if(info.LastFetchStatus != LastFetchStatus.Success) {
                Debug.LogError($"{nameof(FetchComplete)} was unsuccessful\n{nameof(info.LastFetchStatus)}: {info.LastFetchStatus}");
                OnConnectionError?.Invoke();
                return;
            }

            // Fetch successful. Parameter values must be activated to use.
            _remoteConfig.ActivateAsync()
                .ContinueWithOnMainThread(
                    task => {
                        Debug.Log($"Remote data loaded and ready for use. Last fetch time {info.FetchTime}.");
                    });
            Debug.Log(_remoteConfig.AllValues);
        }
        public async Task<ConfigValue> ConnectToFirebaseConfig(string key)
        {
            return  _remoteConfig.GetValue(key);
        }
    }
}

