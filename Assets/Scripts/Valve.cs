using UnityEngine;

public class Valve : MonoBehaviour, IInteractable
{
    public string PromptMessage => "Press E to turn valve";
    private bool isActive = true;

    public event System.Action OnValveCleaned;

    public void Interact()
    {
        if (!isActive) return;
        isActive = false;
        Debug.Log("Valve cleaned!");

        OnValveCleaned?.Invoke();
        AudioManager.Instance.PlaySFX("ValveCleaned");
        gameObject.SetActive(false); // hide or animate
    }
}