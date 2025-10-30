using UnityEngine;

public class SeaweedObstacle : MonoBehaviour
{
    [SerializeField] private float slowMultiplier = 0.2f;
    [SerializeField] private float slowDuration = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.ApplySpeedModifier(slowMultiplier, slowDuration);
            AudioManager.Instance.PlaySFX("SeaweedTangle");
        }
    }
}