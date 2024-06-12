using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    public GameObject ahievementPanel;
    public GameObject achievementItemPrefabs;
    public Transform contect;

    List<GameObject> achievementItems = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        UpdateAchievementUI();
    }
    public void UpdateAchievementUI()
    {
        foreach (var achievement in AchievementManager.instance.achievements)
        {
            GameObject item = Instantiate(achievementItemPrefabs, contect);
            Text[] texts = item.GetComponentsInChildren<Text>();
            texts[0].text = achievement.name;
            texts[1].text = achievement.description;
            texts[2].text = $"{achievement.currentProgress}/{achievement.goal}";
            texts[3].text = achievement.isUnlocked ? "含失" : "耕含失";
            achievementItems.Add(item);
        }
    }
    
}
