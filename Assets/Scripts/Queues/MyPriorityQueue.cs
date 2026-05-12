using System.Collections.Generic;

public class MyPriorityQueue
{
    public List<Entity> elements = new List<Entity>();

    public void Insert(Entity newEntity, bool sortBySpeed)
    {
        if (elements.Count == 0)
        {
            elements.Add(newEntity);
            return;
        }

        bool inserted = false;

        for (int i = 0; i < elements.Count; i++)
        {
            bool hasPriority = false;
            if (sortBySpeed)
            {
                hasPriority = newEntity.stats.speed > elements[i].stats.speed;
            }
            else 
            {
                hasPriority = newEntity.stats.id < elements[i].stats.id;
            }

            if (hasPriority)
            {
                elements.Insert(i, newEntity);
                inserted = true;
                break;
            }
        }


        if (!inserted)
        {
            elements.Add(newEntity);
        }
    }

    public Entity Dequeue()
    {
        if (elements.Count > 0)
        {
            Entity first = elements[0];
            elements.RemoveAt(0);
            return first;
        }
        return null;
    }

    public void Clear()
    {
        elements.Clear();
    }

}
