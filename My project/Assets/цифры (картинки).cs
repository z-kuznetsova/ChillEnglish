using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class צטפנû : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public RectTransform rectTransform;
	public Canvas canvas;
	public CanvasGroup canvasGroup;
	//public RectTransform squareRectTransform;

	public void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvas = GetComponentInParent<Canvas>();
		canvasGroup = GetComponent<CanvasGroup>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = true;

		Rect objRect = new Rect(rectTransform.position, rectTransform.rect.size);
	}
}