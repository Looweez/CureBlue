using UnityEngine;

public class Cage : MonoBehaviour, IInteractable
{
    public string PromptMessage => "Press E to free the fish";
    private bool isLocked = true;
    public GameObject WinPanel;

    public void Unlock()
    {
        isLocked = false;
        Debug.Log("Cage unlocked!");
        AudioManager.Instance.PlaySFX("CageUnlocked");
        
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.color = Color.yellow;
        
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
        gameObject.SetActive(false);
        
        FindObjectOfType<TimerController>()?.Timer.StopTimer();
        
        Time.timeScale = 0f; 
        if (WinPanel != null)
        {
            WinPanel.SetActive(true);
        }
    }
}