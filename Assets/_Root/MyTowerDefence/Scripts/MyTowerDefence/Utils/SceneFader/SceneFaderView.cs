using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tools
{
    public class SceneFaderView : MonoBehaviour
    {
        [SerializeField] private Image sceneFaderImage;
        [SerializeField] private AnimationCurve _animationCurve;

        IEnumerator FadeIn()
        {
            float fadeTime = 1f;

            while (fadeTime > 0f)
            {
                fadeTime -= Time.deltaTime;
                float alphaColor = _animationCurve.Evaluate(fadeTime);
                sceneFaderImage.color = new Color(0f, 0f, 0f, alphaColor);
                yield return 0;
            }
        }

        public void FadeInScene()
        {
            StartCoroutine(FadeIn());
        }


    }
}
