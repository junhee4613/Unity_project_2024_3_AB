using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Achievement
{
    public string name;
    public string description;
    public bool isUnlocked;
    public int currentProgress;         //진행 상태
    public int goal;                    //횟수
    public Achievement(string name, string description, int goal)
    {
        this.name = name;
        this.description = description;
        this.currentProgress = 0;
        this.goal = goal;
    }
    public void AddProgress(int amount)
    {
        if (!isUnlocked)
        {
            currentProgress += amount;
            if(currentProgress >= goal) 
            {
                isUnlocked = true;
                OnAchievementUnlocked();
            }
        }
    }
    protected virtual void OnAchievementUnlocked()
    {
        Debug.Log($"업적 달성 : {name}");
    }
}
