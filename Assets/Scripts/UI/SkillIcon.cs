using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillIcon : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //private bool isDraggging;
    [HideInInspector] public RectTransform rectTrans;
    private Vector2 InitialRectTrans;
    [HideInInspector] public Vector2 TempInitialRectTrans;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    public bool inSkillManager = false;
    public int skillID = 000;
    public string skillName = "Name";
    public GameObject skillPrefab;
    [Range(0.0f,1.0f)]
    public float skillMoment = 0.0f;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        InitialRectTrans = rectTrans.anchoredPosition;
        TempInitialRectTrans = InitialRectTrans;
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        TempInitialRectTrans = rectTrans.anchoredPosition;
        canvasGroup.alpha = 0.8f;
        canvasGroup.blocksRaycasts = false;
        if (inSkillManager)
        {
            FindObjectOfType<SkillManager>().skillIcons.Remove(this);
        }
        inSkillManager = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition = inSkillManager ? TempInitialRectTrans : InitialRectTrans;
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
