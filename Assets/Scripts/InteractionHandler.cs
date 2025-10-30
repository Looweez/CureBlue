using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public bool isKeyTangle = false;
    public bool isLockedHatch = false;
    private void OnTriggerStay2D(Collider2D other)
    {
      
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
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
