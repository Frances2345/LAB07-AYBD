using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public TextMeshProUGUI[] buttonTexts;

    private MyPriorityQueue priorityQueue = new MyPriorityQueue();
    private Entity[] allEntities;

    private bool isSpeedMode = true;

    void Start()
    {
        allEntities = Object.FindObjectsByType<Entity>(FindObjectsSortMode.None);
        OrderBySpeed();
    }

    public void OrderBySpeed()
    {
        isSpeedMode = true;
        RefreshQueue();
    }

    public void SetOrderByID()
    {
        isSpeedMode = false;
        RefreshQueue();

    }

    public void RefreshQueue()
    {
        priorityQueue.Clear();

        foreach (Entity e in allEntities)
        {
            priorityQueue.Insert(e, isSpeedMode);
        }

        string criteryName = "";

        if (isSpeedMode)
        {
            criteryName = "Speed";
        }
        else
        {
            criteryName = "ID";
        }

        UpdateUI(criteryName);
    }

    private void UpdateUI(string critery)
    {
        List<Entity> sortedList = priorityQueue.elements;

        for (int j = 0; j < buttonTexts.Length; j++)
        {
            buttonTexts[j].text = "";
        }

        for (int i = 0; i < buttonTexts.Length; i++)
        {
            if (i < sortedList.Count)
            {
                string entityName = sortedList[i].stats.entityName;
                float value = 0;


                if (isSpeedMode)
                {
                    value = sortedList[i].stats.speed;
                }
                else
                {
                    value = sortedList[i].stats.id;
                }

                buttonTexts[i].text = (i + 1) + ". " + entityName + " (" + critery + ": " + value + ")";
            }
        }
    }

    public void NextTurn()
    {
        Entity currentEntity = priorityQueue.Dequeue();

        if (currentEntity != null)
        {
            Debug.Log("Ataca: " + currentEntity.stats.entityName);

            string criteryName = "";

            if (isSpeedMode)
            {
                criteryName = "Speed";
            }
            else
            {
                criteryName = "ID";
            }

            UpdateUI(criteryName);
        }
        else
        {
            Debug.Log("No hay mas entidades en la cola.");
        }



    }
}
