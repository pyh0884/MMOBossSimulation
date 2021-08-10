using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillRotation : MonoBehaviour
{
    private GameObject player;
    private SkillManager skillManager;
    private Slider slider;
    public float duration;
    public Image[] skillIcons;
    public List<GameObject> skills;
    public List<float> skillMoments;
    private bool[] skillTriggers = new bool[6];
    private float rectWidth;

    void Start()
    {
        skills.Clear();
        skillMoments.Clear();
        skillManager = FindObjectOfType<SkillManager>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
        slider = GetComponent<Slider>();
        rectWidth = GetComponent<RectTransform>().rect.width;
        foreach (SkillInfo info in skillManager.SkillInfos)
        {
            var skill = Instantiate(info.SkillPrefab, player.transform);
            skills.Add(skill.gameObject);
            skillMoments.Add(info.SkillMoment);
        }
        for (int index = 0; index < skills.Count; ++index)
        {
            skillIcons[index].GetComponent<RectTransform>().anchoredPosition = new Vector3(rectWidth * skillMoments[index] - rectWidth / 2.0f, skillIcons[index].GetComponent<RectTransform>().anchoredPosition.y, 0);
            skillIcons[index].gameObject.SetActive(true);
            skillIcons[index].GetComponentInChildren<Text>().text = skillManager.SkillInfos[index].SkillName;
        }
    }

    void Update()
    {
        slider.value += Time.deltaTime / duration;
        if (slider.value >= 1.0f)
        {
            slider.value = 0.0f;
            skillTriggers[0] = false;
            skillTriggers[1] = false;
            skillTriggers[2] = false;
            skillTriggers[3] = false;
            skillTriggers[4] = false;
            skillTriggers[5] = false;
        }
        for (int index = 0; index < skills.Count; ++index)
        {
            if (skillMoments[index] < slider.value && !skillTriggers[index])
            {
                skillTriggers[index] = true;
                skills[index].SetActive(true);
            }
        }
    }
}
