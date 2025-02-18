using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project.Screpts.Loading
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private TextMeshProUGUI _progressText;
        public async void Start() => await LoadNextScene();

        private async UniTask LoadNextScene()
        {
            var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            var taskLoad = SceneManager.LoadSceneAsync(nextSceneIndex);
            taskLoad.allowSceneActivation = false;
            while (taskLoad.progress < 0.9f)
            {
                int progressPercentage = Mathf.RoundToInt(taskLoad.progress * 100);
                _progressText.text = $"{progressPercentage}%";
                _progressSlider.value = progressPercentage;
                await UniTask.Yield();
            }

            taskLoad.allowSceneActivation = true;
        }
    }
}