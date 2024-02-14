using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    private Vector2 offset;
    private Vector2 initialPosition;
    private CardManager cardManager;

    void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
    }

    void OnMouseDown()
    {
        initialPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = (Vector2)transform.position - mousePosition;
    }

    void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition + offset;
    }

    void OnMouseUp()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 closestPosition = cardManager.GetClosestFreeSlot(mousePosition);

        if (closestPosition != Vector2.zero)
        {
            transform.position = closestPosition;
        }
        else
        {
            transform.position = initialPosition;
        }
    }
}
