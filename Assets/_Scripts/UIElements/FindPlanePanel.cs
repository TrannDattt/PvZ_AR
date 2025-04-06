using PlantsZombiesAR.GameManager;
using PlantsZombiesAR.Helpers;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace PlantsZombiesAR.UIElements
{
    public class FindPlanePanel : Singleton<FindPlanePanel>
    {
        [SerializeField] private TextMeshProUGUI _content;

        public UnityEvent OnPlaneFound;

        public void StartFindPlane()
        {
            _content.text = "Looking for available plane...";
        }

        public void FinishFindPlane()
        {
            _content.text = "Plane found!";
            StartCoroutine(FoundPlane());

            IEnumerator FoundPlane()
            {
                yield return new WaitForSeconds(1);
                OnPlaneFound?.Invoke();
            }
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}
