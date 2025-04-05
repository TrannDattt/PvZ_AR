using PlantsZombiesAR.Helpers;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace PlantsZombiesAR.UIElements
{
    public class TimeCounter : Singleton<TimeCounter>
    {
        [SerializeField] private TextMeshProUGUI _time;

        private int _countTime;

        public UnityEvent OnFinishedCountdown;

        public void InitTimer(int startTime)
        {
            _countTime = startTime;
            UpdateText(_countTime);
        }

        public void StartTimer()
        {
            StartCoroutine(CountDown());

            IEnumerator CountDown()
            {
                float elapsedTime = 0;
                while (elapsedTime < _countTime)
                {
                    elapsedTime += Time.deltaTime;
                    UpdateText(_countTime - (int)elapsedTime);
                    yield return null;
                }
                elapsedTime = _countTime;
                UpdateText(_countTime - (int)elapsedTime);

                yield return new WaitForSeconds(1);
                OnFinishedCountdown?.Invoke();
            }
        }

        private void UpdateText(int timeLeft)
        {
            _time.text = timeLeft > 0 ? timeLeft.ToString() : "PLANT!";
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}
