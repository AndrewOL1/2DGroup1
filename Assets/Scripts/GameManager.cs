using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Image blackBackground;
    Color background;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }
    public void Start()
    {
        StartCoroutine(IFadeIn(2));
    }
    public void FadeIn(float t)
    {
        StartCoroutine(IFadeIn(t));
    }
    public void FadeOut(float t)
    {
        StartCoroutine(IFadeOut(t));
    }
    private IEnumerator IFadeIn(float t)
    {
        float alpha = blackBackground.color.a;
        Color fadeColor = blackBackground.color;
        while (alpha > 0)
        {
            yield return new WaitForSeconds(0.01f);
            alpha -= 1/(t*60);
            fadeColor.a = alpha;
            blackBackground.color = fadeColor;
        }
    }
    private IEnumerator IFadeOut(float t)
    {
      float alpha = blackBackground.color.a;
        Color fadeColor = blackBackground.color;
        while (alpha < 1)
        {
            yield return new WaitForSeconds(0.01f);
            alpha += 1 / (t * 60);
            fadeColor.a = alpha;
            blackBackground.color = fadeColor;
        }
    }
}
