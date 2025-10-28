using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool hasKey = false;
    
    private Transform mainCamera;

    void Awake()
    {
        mainCamera = Camera.main.transform;
    }
    
    public void HandleInteraction(InteractionHandler interactionObject)
    {
        // key interaction
        if (interactionObject.isKeyTangle)
        {
            if (!hasKey)
            {
                hasKey = true;
                
                Destroy(interactionObject.gameObject);
                
                Debug.Log("Got key");
            }
        }
        
        // cage interaction
        else if (interactionObject.isLockedHatch)
        {
            if (hasKey)
            {
                //use key
                hasKey = false; 
                
                Destroy(interactionObject.gameObject); 
                
                Debug.Log("opened cage");
            }
            else
            {
                Debug.Log("you need a key");
            }
        }
    }
}
