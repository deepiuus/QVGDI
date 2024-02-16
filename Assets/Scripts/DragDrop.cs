using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    private Vector2 offset;
    private Vector2 initialPosition;
    private CardManager cardManager;
    private GameManager gameManager;
    public int owner;

    void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnMouseDown()
    {
        if (gameManager.IsPlayerTurn(owner) && !this.GetComponent<Card>().IsFixed)
        {
            initialPosition = transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = (Vector2)transform.position - mousePosition;
        }
    }

    void OnMouseDrag()
    {
        if (gameManager.IsPlayerTurn(owner) && !this.GetComponent<Card>().IsFixed)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }

    void OnMouseUp()
    {
        if (gameManager.IsPlayerTurn(owner) && !this.GetComponent<Card>().IsFixed)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 closestPosition = cardManager.GetClosestFreeSlot(mousePosition);

            if (closestPosition != Vector2.zero)
            {
                transform.position = closestPosition;
                gameManager.EndTurn();
                this.GetComponent<Card>().IsFixed = true;
            }
            else
            {
                transform.position = initialPosition;
            }
        }
    }
}
