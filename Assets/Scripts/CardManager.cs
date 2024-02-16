using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject Card;
    public GameManager gameManager;
    public List<Vector3> CardSlotPositions = new List<Vector3>();
    public List<Vector3> Slot_j1 = new List<Vector3>();
    public List<Vector3> Slot_j2 = new List<Vector3>();
    public List<Vector3> OccupiedSlots = new List<Vector3>();
    private Sprite[] CardSprites;

    void Start()
    {
        CardSprites = Resources.LoadAll<Sprite>("Cards");
        CardSlotPositions.Add(new Vector3(0f, 1.8f, 0f));
        CardSlotPositions.Add(new Vector3(1.82f, -0.28f, 0f));
        CardSlotPositions.Add(new Vector3(-1.82f, -0.28f, 0f));
        CardSlotPositions.Add(new Vector3(0f, -0.28f, 0f));
        CardSlotPositions.Add(new Vector3(0f, -2.38f, 0f));
        CardSlotPositions.Add(new Vector3(1.82f, 1.8f, 0f));
        CardSlotPositions.Add(new Vector3(1.82f, -2.38f, 0f));
        CardSlotPositions.Add(new Vector3(-1.82f, 1.8f, 0f));
        CardSlotPositions.Add(new Vector3(-1.82f, -2.38f, 0f));
        CardSlotPositions.Add(new Vector3(7f, 3f, 0f));
        CardSlotPositions.Add(new Vector3(5f, 2f, 0f));
        CardSlotPositions.Add(new Vector3(5f, 0f, 0f));
        CardSlotPositions.Add(new Vector3(5f, -2f, 0f));
        CardSlotPositions.Add(new Vector3(7f, -3f, 0f));
        CardSlotPositions.Add(new Vector3(-7f, 3f, 0f));
        CardSlotPositions.Add(new Vector3(-5f, 2f, 0f));
        CardSlotPositions.Add(new Vector3(-5f, 0f, 0f));
        CardSlotPositions.Add(new Vector3(-5f, -2f, 0f));
        CardSlotPositions.Add(new Vector3(-7f, -3f, 0f));
        DivideCardPositions();
        Init_game(Slot_j1, 1);
        Init_game(Slot_j2, 2);
    }

    void DivideCardPositions()
    {
        Slot_j1.AddRange(CardSlotPositions.GetRange(9, 5));
        Slot_j2.AddRange(CardSlotPositions.GetRange(14, 5));
    }

    void Init_game(List<Vector3> slot, int owner)
    {
        for (int i = 1; i < 6; i++)
        {
            GameObject card = Instantiate(Card, slot[i], Quaternion.identity);
            card.GetComponent<DragDrop>().owner = owner;
            card.name = "Card" + (i);
            OccupiedSlots.Add(slot[i]);
            Card c = card.AddComponent<Card>();
            c.Owner = owner;
            c.sr.sprite = CardSprites[i];
            c.sr.sortingOrder = 5;
            c.IsFixed = false;

            float slotWidth = .35f;
            float slotHeight = .35f;
            card.transform.localScale = new Vector3(slotWidth, slotHeight, 1);
        }
    }

    public Vector3 GetClosestFreeSlot(Vector3 position)
    {
        Vector3 closestSlot = Vector3.zero;
        float closestDistance = float.MaxValue;

        foreach (Vector3 slot in CardSlotPositions)
        {
            if (!OccupiedSlots.Contains(slot) && IsSlotFree(slot))
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
            OccupiedSlots.Add(closestSlot);
            return closestSlot;
        }
        else
        {
            return Vector2.zero;
        }
    }

    private bool IsSlotFree(Vector3 slot)
    {
        GameObject cardAtSlot = GameObject.Find("Card" + slot.ToString());
        if (cardAtSlot != null)
        {
            Card card = cardAtSlot.GetComponent<Card>();
            if (card != null && card.IsFixed)
            {
                return false;
            }
        }
        return true;
    }
}
