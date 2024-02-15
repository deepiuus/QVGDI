using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardDatabase : MonoBehaviour
{
    public List<CardData> Cards = new List<CardData>();

    public CardDatabase()
    {
        Cards = new List<CardData>
        {
            new CardData(0, 1, 2, 3, 4, 0),
            new CardData(1, 2, 3, 4, 5, 0),
            new CardData(2, 3, 4, 5, 6, 0),
            new CardData(3, 4, 5, 6, 7, 0),
            new CardData(4, 5, 6, 7, 8, 0),
            new CardData(5, 6, 7, 8, 9, 0),
            new CardData(6, 7, 8, 9, 10, 0),
            new CardData(7, 8, 9, 10, 11, 0),
            new CardData(8, 9, 10, 11, 12, 0),
            new CardData(9, 10, 11, 12, 13, 0),
            new CardData(10, 11, 12, 13, 14, 0),
            new CardData(11, 12, 13, 14, 15, 0),
            new CardData(12, 13, 14, 15, 16, 0),
            new CardData(13, 14, 15, 16, 17, 0),
            new CardData(14, 15, 16, 17, 18, 0),
            new CardData(15, 16, 17, 18, 19, 0),
            new CardData(16, 17, 18, 19, 20, 0),
            new CardData(17, 18, 19, 20, 21, 0),
            new CardData(18, 19, 20, 21, 22, 0),
            new CardData(19, 20, 21, 22, 23, 0),
            new CardData(20, 21, 22, 23, 24, 0),
            new CardData(21, 22, 23, 24, 25, 0),
            new CardData(22, 23, 24, 25, 26, 0),
            new CardData(23, 24, 25, 26, 27, 0),
            new CardData(24, 25, 26, 27, 28, 0),
            new CardData(25, 26, 27, 28, 29, 0),
            new CardData(26, 27, 28, 29, 30, 0),
            new CardData(27, 28, 29, 30, 31, 0),
            new CardData(28, 29, 30, 31, 32, 0),
            new CardData(29, 30, 31, 32, 33, 0),
            new CardData(30, 31, 32, 33, 34, 0),
            new CardData(31, 32, 33, 34, 35, 0),
            new CardData(32, 33, 34, 35, 36, 0),
            new CardData(33, 34, 35, 36, 37, 0),
            new CardData(34, 35, 36, 37, 38, 0),
            new CardData(35, 36, 37, 38, 39, 0),
            new CardData(36, 37, 38, 39, 40, 0),
            new CardData(37, 38, 39, 40, 41, 0),
            new CardData(38, 39, 40, 41, 42, 0),
            new CardData(39, 40, 41, 42, 43, 0),
            new CardData(40, 41, 42, 43, 44, 0),
            new CardData(41, 42, 43, 44, 45, 0),
            new CardData(42, 43, 44, 45, 46, 0),
            new CardData(43, 44, 45, 46, 47, 0),
        };
    }

    public CardData GetCard(int id)
    {
        return Cards.FirstOrDefault(card => card.Id == id);
    }
}
