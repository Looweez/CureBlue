using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public bool isKeyTangle = false;
    public bool isLockedHatch = false;

    // Use a Collider 2D set to Is Trigger to detect the player entering the interaction zone
    private void OnTriggerStay2D(Collider2D other)
    {
      
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Get the player's inventory component
                PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
                
                
                if (playerInventory != null)
                {
                    playerInventory.HandleInteraction(this);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }
}
