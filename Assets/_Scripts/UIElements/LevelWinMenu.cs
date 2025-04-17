using System;
using System.Collections;
using UnityEngine;

namespace PlantsZombiesAR.UIElements
{
    public class LevelWinMenu : GameMenuSingleton<LevelWinMenu>
    {
        [SerializeField] private CanvasGroup _background;

        public override void InitMenu()
        {
            _background.alpha = 0;
            gameObject.SetActive(false);
        }

        public override void MenuEnter()
        {
            gameObject.SetActive(true);
            StartCoroutine(Fade(true, 1.5f));
        }

        public override void MenuExit()
        {
            gameObject.SetActive(false);
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
                ApplyAlpha(alpha);
                yield return null;
            }

            ApplyAlpha(targetAlpha);
        }

        private void ApplyAlpha(float alpha)
        {
            //var color = _background.color;
            //color.a = alpha;
            _background.alpha = alpha;
        }
    }
}
