using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillRotation : MonoBehaviour
{
    private GameObject player;
    private Slider slider;
    public float duration;
    public Image[] skillIcons;
    public GameObject[] skills;
    public float[] skillMoments;
    private bool[] skillTriggers = new bool[3];
    private float rectWidth;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        slider = GetComponent<Slider>();
        rectWidth = GetComponent<RectTransform>().rect.width;
        skillIcons[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(rectWidth * skillMoments[0] - rectWidth / 2.0f, skillIcons[0].GetComponent<RectTransform>().anchoredPosition.y, 0);
        skillIcons[1].GetComponent<RectTransform>().anchoredPosition = new Vector3(rectWidth * skillMoments[1] - rectWidth / 2.0f, skillIcons[1].GetComponent<RectTransform>().anchoredPosition.y, 0);
        skillIcons[2].GetComponent<RectTransform>().anchoredPosition = new Vector3(rectWidth * skillMoments[2] - rectWidth / 2.0f, skillIcons[2].GetComponent<RectTransform>().anchoredPosition.y, 0);
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
        }
        for (int index = 0; index < skills.Length; ++index)
        {
            if (skillMoments[index] < slider.value && !skillTriggers[index])
            {
                skillTriggers[index] = true;
                skills[index].SetActive(true);
            }
        }
    }
}
