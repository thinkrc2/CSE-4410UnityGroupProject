using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class OilSlick : MonoBehaviour
{
    // modifier reduces player movement speed to a percentage of the original, trigger booleans are to check which game object is entering the object collider
    private float modifier = 0.3f;
    private bool playerTriggered = false;
    private bool AITriggered = false;
    private bool AggressiveAITriggered = false;


    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement movement = other.GetComponent<PlayerMovement>();
        AI ai = other.GetComponent<AI>();
        AggresiveAI aggressiveAI = other.GetComponent<AggresiveAI>();

        // Section dedicated for the player
        if (movement != null && playerTriggered == false)
        {
            movement.applyOilSlick(modifier);
            playerTriggered = true;
        }

        // Section dedicated for the player
        if (ai != null && AITriggered == false)
        {
            ai.applyOilSlick(modifier);
            AITriggered = true;
        }

        if (aggressiveAI != null && AggressiveAITriggered == false)
        {
            aggressiveAI.applyOilSlick(modifier);
            AggressiveAITriggered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerMovement movement = other.GetComponent<PlayerMovement>();
        AI ai = other.GetComponent<AI>();
        AggresiveAI aggressiveAI = other.GetComponent<AggresiveAI>();

        if (playerTriggered == true)
        {
            movement.removeOilSlick();
            playerTriggered = false;
        }

        if (AITriggered == true)
        {
            ai.removeOilSlick();
            AITriggered = false;
        }

        if (AggressiveAITriggered == true)
        {
            aggressiveAI.applyOilSlick(modifier);
            AggressiveAITriggered = true;
        }
    }
}
