using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PlantsZombiesAR.UIElements
{
    public class LevelLoseMenu : GameMenuSingleton<LevelLoseMenu>
    {
        [SerializeField] private CanvasGroup _background;

        public override void InitMenu()
        {
            _background.alpha = 0;
            gameObject.SetActive(true);
        }

        public override void MenuEnter()
        {
            StartCoroutine(Fade(true, 1.5f));
        }

        public override void MenuExit()
        {
            StartCoroutine(Fade(false, .5f));
        }

        private IEnumerator Fade(bool fadeIn, float fadeTime)
        {
            float startAlpha = fadeIn ? 0f : 1f;
            float targetAlpha = fadeIn ? 1f : 0f;

            float elapsedTime = 0;
            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.unscaledDeltaTime;
                var alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeTime);
                //float alpha = startAlpha * (elapsedTime / fadeTime);
                ApplyAlpha(alpha);
                yield return null;
            }

            ApplyAlpha(targetAlpha);

            if(!fadeIn){
                gameObject.SetActive(false);
            }
        }

        private void ApplyAlpha(float alpha)
        {
            //var color = _background.color;
            //color.a = alpha;
            _background.alpha = alpha;
        }
    }
}
