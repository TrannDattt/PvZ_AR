using PlantsZombiesAR.Gameplays;
using PlantsZombiesAR.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlantsZombiesAR.UIElements
{
    public class ProgressSlider : Singleton<ProgressSlider>
    {
        [SerializeField] private Slider _progressBar;

        public void InitSlider() 
        {
            gameObject.SetActive(true);
            _progressBar.value = 0;
            ZombieSpawner.Instance.OnZombieSpawned += UpdateSlider;
        }

        private void UpdateSlider()
        {
            var curVal = _progressBar.value;
            var newVal = (float)ZombieSpawner.Instance.ZombieSpawned / ZombieSpawner.Instance.ZombieToSpawn;

            StartCoroutine(Lerp(1));

            IEnumerator Lerp(float lerpTime)
            {
                float elapsedTime = 0;
                while (elapsedTime < lerpTime)
                {
                    elapsedTime += Time.deltaTime;
                    _progressBar.value = Mathf.Lerp(curVal, newVal, elapsedTime / lerpTime);
                    yield return null;
                }

                elapsedTime = lerpTime;
                _progressBar.value = Mathf.Lerp(curVal, newVal, elapsedTime / lerpTime);
            }
        }

        public void DeactivateSlider()
        {
            gameObject.SetActive(false);
            ZombieSpawner.Instance.OnZombieSpawned -= UpdateSlider;
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}
