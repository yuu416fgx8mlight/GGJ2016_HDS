using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public static class UIAction{
    public static void ScaleActionY(CanvasGroup cg, float to, float alpha, float time, float alphatime = -1, LeanTweenType type = LeanTweenType.linear, Action complete = null)
    {
        LTRect cgrect = new LTRect();
        cgrect.alpha = cg.alpha;
        alphatime = (alphatime < 0) ? to : alphatime;
        LeanTween.alpha(cgrect, alpha, time).setEase(type);
        LTDescr d = LeanTween.scaleY(cg.transform.gameObject, to, time).setEase(type);
        d.setOnUpdate((float f) => { UpdateAlpha(cg, cgrect.alpha); });
        if (complete != null)
        {
            d.setOnComplete(complete);
        }
    }
    public static void ScaleActionX(CanvasGroup cg, float to, float alpha, float time, float alphatime = -1, LeanTweenType type = LeanTweenType.linear, Action complete = null)
    {
        LTRect cgrect = new LTRect();
        cgrect.alpha = cg.alpha;
        alphatime = (alphatime < 0) ? to : alphatime;
        LeanTween.alpha(cgrect, alpha, time).setEase(type);
        LTDescr d = LeanTween.scaleX(cg.transform.gameObject, to, time).setEase(type);
        d.setOnUpdate((float f) => { UpdateAlpha(cg, cgrect.alpha); });
        if (complete != null)
        {
            d.setOnComplete(complete);
        }
    }
    public static void MoveActionX(CanvasGroup cg, float to, float alpha, float time, float alphatime = -1, LeanTweenType type = LeanTweenType.linear, Action complete = null)
    {
        LTRect cgrect = new LTRect();
        cgrect.alpha = cg.alpha;
        alphatime = (alphatime < 0) ? to : alphatime;
        LeanTween.alpha(cgrect, alpha, time).setEase(type);
        LTDescr d = LeanTween.moveLocalX(cg.transform.gameObject, to, time).setEase(type);
        d.setOnUpdate((float f) => { UpdateAlpha(cg, cgrect.alpha); });
        if (complete != null)
        {
            d.setOnComplete(complete);
        }
    }
    public static void UpdateAlpha(CanvasGroup cg,float now)
    {
        cg.alpha = now;
    }
    public static void Alpha(CanvasGroup cg,float alpha,float time,LeanTweenType type=LeanTweenType.linear,Action complete = null)
    {
        LTRect cgrect = new LTRect();
        cgrect.alpha = cg.alpha;

        LTDescr d = LeanTween.alpha(cgrect, alpha, time).setEase(type);
        d.setOnUpdate((float f) => { UpdateAlpha(cg, cgrect.alpha); });
        if (complete != null)
        {
            d.setOnComplete(complete);
        }

    }
    public static void MoveActionY(CanvasGroup cg, float to, float alpha, float time, float alphatime = -1, LeanTweenType type = LeanTweenType.linear, Action complete = null)
    {
        LTRect cgrect = new LTRect();
        cgrect.alpha = cg.alpha;
        alphatime = (alphatime < 0) ? to : alphatime;
        LeanTween.alpha(cgrect, alpha, time).setEase(type);
        LTDescr d = LeanTween.moveLocalY(cg.transform.gameObject, to, time).setEase(type);
        d.setOnUpdate((float f) => { UpdateAlpha(cg, cgrect.alpha); });
        if (complete != null)
        {
            d.setOnComplete(complete);
        }
    }
    public static void Fade(RectTransform trs,float alpha,float time,LeanTweenType type=LeanTweenType.linear,Action complete = null)
    {
        LTDescr d = LeanTween.alpha(trs, alpha, time).setEase(type);
        if (complete != null)
        {
            d.setOnComplete(complete);
        }
    }
}
