using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Valve[] valves;
    [SerializeField] private Cage cage;

    private int cleanedValves = 0;

    private void Start()
    {
        foreach (var valve in valves)
        {
            valve.OnValveCleaned += HandleValveCleaned;
            Debug.Log("Subscribed to valve: " + valve.name);
        }
    }

    private void HandleValveCleaned()
    {
        cleanedValves++;
        Debug.Log($"Valve cleaned! Total: {cleanedValves}/{valves.Length}");
        if (cleanedValves >= valves.Length)
        {
            Debug.Log("All valves cleaned!");
            cage.Unlock();
        }
    }
    public void LoseLevel()
    {
        Debug.Log("Player lost! Restarting level...");
        // Handle game-over logic here (UI, reload scene, etc.)
    }
}