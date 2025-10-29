using System.Net.NetworkInformation;
using UnityEngine;

public interface IInteractable 
{
    string PromptMessage { get; }
    void Interact();
}