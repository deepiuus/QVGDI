using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int CurrentPlayer = 1;
    public CardData[,] Board = new CardData[3, 3];

    public void PlaceCard(CardData card, int x, int y)
    {
        Board[x, y] = card; // Place the card on the board
        card.Owner = CurrentPlayer; // Set the owner of the card
        CheckCapture(card, x, y); // Check for captures after placing the card
        CurrentPlayer = 3 - CurrentPlayer; // Switch to the other player
    }

    public void CheckCapture(CardData card, int x, int y)
    {
        // Check the card above
        if (y < 2 && Board[x, y + 1]?.Owner != card.Owner && card.Top > Board[x, y + 1].Bottom)
        {
            Board[x, y + 1].Owner = card.Owner;
        }
        // Check the card below
        if (y > 0 && Board[x, y - 1]?.Owner != card.Owner && card.Bottom > Board[x, y - 1].Top)
        {
            Board[x, y - 1].Owner = card.Owner;
        }
        // Check the card to the right
        if (x < 2 && Board[x + 1, y]?.Owner != card.Owner && card.Right > Board[x + 1, y].Left)
        {
            Board[x + 1, y].Owner = card.Owner;
        }
        // Check the card to the left
        if (x > 0 && Board[x - 1, y]?.Owner != card.Owner && card.Left > Board[x - 1, y].Right)
        {
            Board[x - 1, y].Owner = card.Owner;
        }
    }
}
