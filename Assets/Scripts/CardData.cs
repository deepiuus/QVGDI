using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardData : MonoBehaviour
{
    public int cardId;
    public string cardName;
    public int attackTop;
    public int attackBottom;
    public int attackLeft;
    public int attackRight;
    public Texture cardImage;
    public CardSlot CurrentSlot { get; private set; }

    public void SetCardData(int cardId, string cardName, int attackTop, int attackBottom, int attackLeft, int attackRight, string imagePath, CardSlot initialSlot)
    {
        this.cardId = cardId;
        this.cardName = cardName;
        this.attackTop = attackTop;
        this.attackBottom = attackBottom;
        this.attackLeft = attackLeft;
        this.attackRight = attackRight;

        this.cardImage = Resources.Load<Texture>("Cards/" + imagePath);

        RawImage rawImage = gameObject.GetComponentInChildren<RawImage>();
        rawImage.texture = this.cardImage;
    }

    public void AssignSlot(CardSlot slot)
    {
        CurrentSlot = slot;
    }

    void OnMouseDown()
    {
        Debug.Log("La carte " + cardName + " a été cliquée !");
    }
}
