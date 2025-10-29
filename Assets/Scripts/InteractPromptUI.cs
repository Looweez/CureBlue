using UnityEngine;
using TMPro;

public class InteractPromptUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private PlayerInteract playerInteract;

    private void OnEnable()
    {
        playerInteract.OnShowPrompt += ShowPrompt;
        playerInteract.OnHidePrompt += HidePrompt;
        HidePrompt();
    }

    private void OnDisable()
    {
        playerInteract.OnShowPrompt -= ShowPrompt;
        playerInteract.OnHidePrompt -= HidePrompt;
    }

    private void ShowPrompt(string message)
    {
        Debug.Log("Prompt shown: " + message);
        promptText.text = message;
        promptText.gameObject.SetActive(true);
    }

    private void HidePrompt()
    {
        promptText.gameObject.SetActive(false);
    }
}