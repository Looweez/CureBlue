using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float interactRange = 1.5f;
    [SerializeField] private LayerMask interactLayer;

    private IInteractable currentInteractable;

    public event System.Action<string> OnShowPrompt;
    public event System.Action OnHidePrompt;

    void Update()
    {
        DetectInteractable();
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }

    private void DetectInteractable()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRange, interactLayer);
        if (hit)
        {
            IInteractable interactable = hit.GetComponent<IInteractable>();
            if (interactable != null)
            {
                currentInteractable = interactable;
                OnShowPrompt?.Invoke(interactable.PromptMessage);
                return;
            }
        }

        currentInteractable = null;
        OnHidePrompt?.Invoke();
    }
}