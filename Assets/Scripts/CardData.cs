using UnityEngine;

public class CardData : MonoBehaviour
{
    public int Id;
    public int Top;
    public int Bottom;
    public int Right;
    public int Left;
    public int Owner;

    public CardData(int Id, int Top, int Bottom, int Right, int Left, int Owner)
    {
        this.Id = Id;
        this.Top = Top;
        this.Bottom = Bottom;
        this.Right = Right;
        this.Left = Left;
        this.Owner = Owner;
    }

    public void SetCardData(int Id, int Top, int Bottom, int Right, int Left, int Owner)
    {
        this.Id = Id;
        this.Top = Top;
        this.Bottom = Bottom;
        this.Right = Right;
        this.Left = Left;
        this.Owner = Owner;
    }
}
