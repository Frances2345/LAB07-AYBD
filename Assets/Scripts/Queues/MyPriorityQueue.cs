using System.Collections.Generic;

public class MyPriorityQueue
{
    public List<Entity> elements = new List<Entity>();

    public void Insert(Entity newEntity)
    {
        if (elements.Count == 0)
        {
            elements.Add(newEntity);
            return;
        }

        bool inserted = false;

        for (int i = 0; i < elements.Count; i++)
        {
            if (newEntity.stats.speed > elements[i].stats.speed)
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
