using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject Card;
    public GameObject CardSlotPrefab;
    public List<Vector3> CardSlotPositions = new List<Vector3>();

    public List<Vector3> Player1CardPositions = new List<Vector3>();
    public List<Vector3> Player2CardPositions = new List<Vector3>();

    void Start()
    {
        CardSlotPositions.Add(new Vector3(13, 1, -19));
        CardSlotPositions.Add(new Vector3(13, 1, 0));
        CardSlotPositions.Add(new Vector3(13, 1, 19));
        CardSlotPositions.Add(new Vector3(0, 1, -19));
        CardSlotPositions.Add(new Vector3(0, 1, 0));
        CardSlotPositions.Add(new Vector3(0, 1, 19));
        CardSlotPositions.Add(new Vector3(-13, 1, -19));
        CardSlotPositions.Add(new Vector3(-13, 1, 0));
        CardSlotPositions.Add(new Vector3(-13, 1, 19));
        CardSlotPositions.Add(new Vector3(35, 1, 19));
        CardSlotPositions.Add(new Vector3(35, 1, 9));
        CardSlotPositions.Add(new Vector3(35, 1, 0));
        CardSlotPositions.Add(new Vector3(35, 1, -9));
        CardSlotPositions.Add(new Vector3(35, 1, -19));
        CardSlotPositions.Add(new Vector3(-35, 1, 19));
        CardSlotPositions.Add(new Vector3(-35, 1, 9));
        CardSlotPositions.Add(new Vector3(-35, 1, 0));
        CardSlotPositions.Add(new Vector3(-35, 1, -9));
        CardSlotPositions.Add(new Vector3(-35, 1, -19));

        DivideCardPositions();

        foreach (Vector3 position in CardSlotPositions)
        {
            CreateCardSlot(position);
        }

        InstantiatePlayerCards(Player1CardPositions, "Joueur1");
        InstantiatePlayerCards(Player2CardPositions, "Joueur2");
    }

    void DivideCardPositions()
    {
        // Divisez les positions pour chaque joueur (à ajuster selon votre besoin).
        Player1CardPositions.AddRange(CardSlotPositions.GetRange(9, 5));
        Player2CardPositions.AddRange(CardSlotPositions.GetRange(14, 5));
    }

    void CreateCardSlot(Vector3 position)
    {
        // Crée un nouvel emplacement de carte à la position spécifiée.
        Instantiate(CardSlotPrefab, position, Quaternion.identity);
    }

    void InstantiatePlayerCards(List<Vector3> playerCardPositions, string playerName)
    {
        foreach (Vector3 position in playerCardPositions)
        {
            InstantiateCard(position, null);
        }
    }

    void InstantiateCard(Vector3 position, CardSlot initialSlot)
    {
        // Instancie une nouvelle carte à la position spécifiée.
        GameObject newCard = Instantiate(Card, position, Quaternion.identity);

        // Ajoute le script de la carte (assure-toi que le script est attaché au prefab).
        CardData card = newCard.GetComponent<CardData>();

        // Configure des propriétés spécifiques de la carte si nécessaire.
        card.SetCardData(1, "1-The_Magician", 2, 3, 4, 5, "1-The_Magician", initialSlot);
        card.AssignSlot(initialSlot);
    }
}
