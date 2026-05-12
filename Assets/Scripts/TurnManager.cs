using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public TextMeshProUGUI[] buttonTexts;

    private MyPriorityQueue priorityQueue = new MyPriorityQueue();
    private Entity[] allEntities;


    void Start()
    {
        allEntities = Object.FindObjectsByType<Entity>(FindObjectsSortMode.None);
        OrderBySpeed();
    }

    public void OrderBySpeed()
    {
        priorityQueue.Clear();

        foreach (Entity e in allEntities)
        {
            priorityQueue.Insert(e);
        }

        UpdateUI("Speed");
    }

    private void UpdateUI(string critery)
    {
        List<Entity> sortedList = priorityQueue.elements;

        for (int i = 0; i < buttonTexts.Length; i++)
        {
            if (i < sortedList.Count)
            {
                string entityName = sortedList[i].stats.entityName;
                float value = sortedList[i].stats.speed;

                buttonTexts[i].text = entityName + " (" + critery + ": " + value + ")";
            }
        }
    }
}
