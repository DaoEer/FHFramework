using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[AddComponentMenu("UI/FHScrollRect")]
public class FHScrollRect : ScrollRect
{
    public int visibleCount = 6;
    private Vector2 _itemSize;
    private float _itemHeight;
    [Range(0f, 1f)]
    private float _threshold;

    private Vector2 _lastContentPosition;
    
    protected override void Start()
    {
        base.Start();
        // 初始化元素高度和阈值
        _lastContentPosition = content.anchoredPosition;
        _itemHeight = content.GetChild(0).GetComponent<RectTransform>().rect.height;
        _threshold = _itemHeight / 2;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        SnapToClosest();
    }

    private void SnapToClosest()
    {
        Vector2 moveDelta = content.anchoredPosition - _lastContentPosition;
        int xMoveCount = Mathf.RoundToInt(moveDelta.x / _itemSize.x);
        int yMoveCount = Mathf.RoundToInt(moveDelta.y / _itemSize.y);
        
        // 获取当前内容的位置（向上滑动为负）
        float contentPosY = content.anchoredPosition.y;

        // 计算当前可视区域的第一个和第六个元素的索引
        int startIndex = Mathf.FloorToInt(contentPosY / _itemHeight);
        int endIndex = startIndex + visibleCount;

        // 获取第六个元素的显示情况
        float sixthItemTopEdge = (endIndex + 1) * _itemHeight;
        float visibleTopEdge = contentPosY + visibleCount * _itemHeight;

        // 判断第六个元素是否显示一半
        if (visibleTopEdge - sixthItemTopEdge > _threshold)
        {
            // 滑动到第2-6个元素位置
            SnapToPosition(startIndex + 1);
        }
        else
        {
            // 回弹到第1-5个元素位置
            SnapToPosition(startIndex);
        }
    }

    private void SnapToPosition(int index)
    {
        // 自动滑动内容面板位置，确保显示第index开始的visibleItems个元素
        float targetY = index * _itemHeight;
        content.anchoredPosition = new Vector2(content.anchoredPosition.x, targetY);
    }
}
