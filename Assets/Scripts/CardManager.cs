using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject Card;
    public string CardFolder = "Assets/Resources/Cards";
    public List<Vector2> CardSlotPositions = new List<Vector2>();
    public List<Vector2> Slot_j1 = new List<Vector2>();
    public List<Vector2> Slot_j2 = new List<Vector2>();

    void Start()
    {
        CardSlotPositions.Add(new Vector2(0, 0));
        CardSlotPositions.Add(new Vector2(2, 0));
        CardSlotPositions.Add(new Vector2(-2, 0));
        CardSlotPositions.Add(new Vector2(0, 2));
        CardSlotPositions.Add(new Vector2(0, -2));
        CardSlotPositions.Add(new Vector2(2, 2));
        CardSlotPositions.Add(new Vector2(2, -2));
        CardSlotPositions.Add(new Vector2(-2, 2));
        CardSlotPositions.Add(new Vector2(-2, -2));
        CardSlotPositions.Add(new Vector2(7, 3));
        CardSlotPositions.Add(new Vector2(5, 2));
        CardSlotPositions.Add(new Vector2(5, 0));
        CardSlotPositions.Add(new Vector2(5, -2));
        CardSlotPositions.Add(new Vector2(7, -3));
        CardSlotPositions.Add(new Vector2(-7, 3));
        CardSlotPositions.Add(new Vector2(-5, 2));
        CardSlotPositions.Add(new Vector2(-5, 0));
        CardSlotPositions.Add(new Vector2(-5, -2));
        CardSlotPositions.Add(new Vector2(-7, -3));
        DivideCardPositions();

        Init_game(Slot_j1);
        Init_game(Slot_j2);
    }

    void DivideCardPositions()
    {
        Slot_j1.AddRange(CardSlotPositions.GetRange(9, 5));
        Slot_j2.AddRange(CardSlotPositions.GetRange(14, 5));
    }

    void Init_game(List<Vector2> slot)
    {
        for (int i = 1; i < 6; i++)
        {
            GameObject card = Instantiate(Card, slot[i], Quaternion.identity);
            card.name = "Card" + i;
        }
    }

    public Vector2 GetClosestFreeSlot(Vector2 position)
    {
        Vector2 closestSlot = Vector2.zero;
        float closestDistance = float.MaxValue;

        foreach (Vector2 slot in CardSlotPositions)
        {
            if (!Slot_j1.Contains(slot) && !Slot_j2.Contains(slot))
            {
                float distance = Vector2.Distance(position, slot);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestSlot = slot;
                }
            }
        }

        if (closestDistance < 1.0f)
        {
            return closestSlot;
        }
        else
        {
            return Vector2.zero;
        }
    }
}
