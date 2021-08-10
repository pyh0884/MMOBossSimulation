using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillManager : MonoBehaviour, IDropHandler
{
    public static SkillManager instance;
    //时间轴相关参数
    private Slider slider;
    public List<SkillIcon> skillIcons;
    public List<SkillInfo> SkillInfos;
    public float rectWidth;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        rectWidth = slider.GetComponent<RectTransform>().rect.width;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<SkillIcon>())
        {
            skillIcons.Add(eventData.pointerDrag.GetComponent<SkillIcon>());
            skillIcons[skillIcons.Count - 1].inSkillManager = true;
            skillIcons[skillIcons.Count - 1].TempInitialRectTrans =
                new Vector2(skillIcons[skillIcons.Count - 1].rectTrans.anchoredPosition.x
                , slider.GetComponent<RectTransform>().anchoredPosition.y);
            skillIcons[skillIcons.Count - 1].TempInitialRectTrans.x = Mathf.Clamp(skillIcons[skillIcons.Count - 1].TempInitialRectTrans.x, -rectWidth / 2.0f, rectWidth / 2.0f);
            skillIcons[skillIcons.Count - 1].skillMoment = (skillIcons[skillIcons.Count - 1].TempInitialRectTrans.x + rectWidth / 2.0f) / rectWidth;
        }
    }

    static int SortByMoment(SkillInfo info1, SkillInfo info2)
    {
        return info1.SkillMoment.CompareTo(info2.SkillMoment);
    }

    public void SaveData() 
    {
        SkillInfos.Clear();
        foreach (SkillIcon icon in skillIcons)
        {
            foreach (SkillInfo temp in SkillInfos)
            {
                if (temp.SkillID == icon.skillID)
                {
                    SkillInfos.Remove(temp);
                    break;
                }
            }
            SkillInfo info = new SkillInfo();
            info.SkillID = icon.skillID;
            info.SkillPrefab = icon.skillPrefab;
            info.SkillMoment = icon.skillMoment;
            info.SkillName = icon.skillName;
            SkillInfos.Add(info);
        }
        SkillInfos.Sort(SortByMoment);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
