using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentPlayer = 0;
    public int NumberOfPlayers = 2;
    public Text PlayerTurnText;

    void Start()
    {
        NextPlayer();
    }
    // Call this method to change the current player to the next one
    public void NextPlayer()
    {
        currentPlayer = currentPlayer % NumberOfPlayers + 1;
        PlayerTurnText.text = "Player " + currentPlayer + " turn";
    }

    // Call this method to check if it's the turn of a specific player
    public bool IsPlayerTurn(int player)
    {
        return currentPlayer == player;
    }

    public void EndTurn()
    {
        currentPlayer = 3 - currentPlayer;
    }
}
