using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInputHandler))]
public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 5f;

    private Rigidbody2D rb;
    private PlayerInputHandler input;
    private float currentSpeed;
    private bool isSpeedModified = false;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //rb.linearVelocity = input.MovementInput * baseSpeed;
        Vector2 movement = input.MovementInput * baseSpeed;
        rb.linearVelocity = movement;
        
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    
    public void ApplySpeedModifier(float multiplier, float duration)
    {
        StartCoroutine(SpeedModifierCoroutine(multiplier, duration));
    }
    
    private IEnumerator SpeedModifierCoroutine(float multiplier, float duration)
    {
        isSpeedModified = true;
        currentSpeed = baseSpeed * multiplier;

        // Optional: visual feedback (e.g., dim the sprite)
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null) sr.color = new Color(0.6f, 0.8f, 0.6f, 1f);

        yield return new WaitForSeconds(duration);

        currentSpeed = baseSpeed;
        isSpeedModified = false;

        if (sr != null) sr.color = Color.white;
    }
}

