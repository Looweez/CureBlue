using UnityEngine;

public class Cage : MonoBehaviour, IInteractable
{
    public string PromptMessage => "Press E to free the fish";
    private bool isLocked = true;

    public void Unlock()
    {
        isLocked = false;
        AudioManager.Instance.PlaySFX("CageUnlocked");
    }

    public void Interact()
    {
        if (isLocked)
        {
            Debug.Log("Cage still locked!");
            return;
        }

        Debug.Log("Fish freed!");
        AudioManager.Instance.PlaySFX("FishFreed");
        // trigger animation or win condition
    }
}