using UnityEngine;

namespace FHFramework
{
    public static class RectTransformExtensions
    {
        public static void SetStretchMode(this RectTransform rectTransform)
        {
            // 设置为Stretch模式
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.localPosition = Vector3.zero;
            rectTransform.localScale = Vector3.one;
        }
    }
}