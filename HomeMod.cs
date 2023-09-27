using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HomeMod : MonoBehaviour
{
    public static Vector3 HomePosition { get; set; }

    private void Start()
    {
        // Register the /sethome and /home commands
        GameManager.Instance.ChatCommands.Add("sethome", SetHomeCommand);
        GameManager.Instance.ChatCommands.Add("home", HomeCommand);
    }

    private void SetHomeCommand(string[] args)
    {
        // Get the player's current position
        Vector3 position = GameManager.Instance.Player.transform.position;

        // Set the home position
        HomePosition = position;

        // Send a message to the player
        GameManager.Instance.ChatMessage("Home position set!");
    }

    private void HomeCommand(string[] args)
    {
        // Check if the home position has been set
        if (HomePosition == Vector3.zero)
        {
            GameManager.Instance.ChatMessage("You have not set a home position yet!");
            return;
        }

        // Teleport the player to the home position
        GameManager.Instance.Player.transform.position = HomePosition;

        // Send a message to the player
        GameManager.Instance.ChatMessage("Teleported to home position!");
    }
}
