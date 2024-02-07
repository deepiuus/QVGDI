using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public bool IsOccupied { get; private set; }

    void Start()
    {
        IsOccupied = false;
    }

    public void OccupySlot()
    {
        IsOccupied = true;
    }

    public void VacateSlot()
    {
        IsOccupied = false;
    }
}
