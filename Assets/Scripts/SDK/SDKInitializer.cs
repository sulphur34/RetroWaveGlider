using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SDK
{
    public sealed class SDKInitializer : MonoBehaviour
    {
        public object ScenesNames { get; private set; }

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = false;
        }

        private IEnumerator Start()
        {
            yield return YandexGamesSdk.Initialize(OnInitialized);
        }

        private void OnInitialized()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}