using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    private Rigidbody2D rb;
    float groundedMass = 2;
    float airMass = 1;

    bool jump = false;
    bool crouch = false;

    float speedMultiplier = 1f;

    [Header("Mass Settings")]
    private float originalGroundedMass;
    private float originalAirMass;
    private Coroutine massResetCoroutine;

    [Header("Mass Transition Settings")]
    [SerializeField] private float massResetDelay = 0.3f; // Delay before mass resets on landing
    private Coroutine delayedMassResetCoroutine;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        // Initialize original mass values
        originalGroundedMass = groundedMass;
        originalAirMass = airMass;
        rb = GetComponent<Rigidbody2D>();
        // No longer subscribing to SpeedItem events!
    }

    public void ActivateMassEffect(float multiplier, float duration)
    {
        if (audioManager != null)
            audioManager.PlaySFX(audioManager.boost);

        if (massResetCoroutine != null)
        {
            StopCoroutine(massResetCoroutine);
        }

        // Apply mass reduction to both states
        groundedMass = originalGroundedMass * multiplier;
        airMass = originalAirMass * multiplier;

        // Immediately update current mass
        rb.mass = animator.GetBool("IsJumping") ? airMass : groundedMass;

        massResetCoroutine = StartCoroutine(ResetMassAfterDelay(duration));
    }

    private IEnumerator ResetMassAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Restore original masses
        groundedMass = originalGroundedMass;
        airMass = originalAirMass;

        // Update current mass based on state
        rb.mass = animator.GetBool("IsJumping") ? airMass : groundedMass;
    }

    // Make this public so SpeedItem can call it
    public void StartSpeedBoost(float multiplier)
    {
        if (audioManager != null)
            audioManager.PlaySFX(audioManager.boost);

        StartCoroutine(SpeedBoostCoroutine(multiplier));
    }

    private IEnumerator SpeedBoostCoroutine(float multiplier)
    {
        speedMultiplier = multiplier;
        yield return new WaitForSeconds(10f);
        speedMultiplier = 1f;
    }

    void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * speedMultiplier;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    public void OnLanding()
    {
        Debug.Log("Landed");
        animator.SetBool("IsJumping", false);

        // Cancel any previous delayed mass reset
        if (delayedMassResetCoroutine != null)
        {
            StopCoroutine(delayedMassResetCoroutine);
        }

        // Start delayed mass reset
        delayedMassResetCoroutine = StartCoroutine(DelayedMassReset());
    }

    private IEnumerator DelayedMassReset()
    {
        yield return new WaitForSeconds(massResetDelay);
        rb.mass = groundedMass;
        // Only apply if still grounded
    }

    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void Update()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("in air");
            jump = true;

            // Cancel any pending delayed mass reset
            if (delayedMassResetCoroutine != null)
            {
                StopCoroutine(delayedMassResetCoroutine);
                delayedMassResetCoroutine = null;
            }

            rb.mass = airMass;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
}

