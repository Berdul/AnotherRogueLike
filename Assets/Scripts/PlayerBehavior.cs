using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBehavior : MonoBehaviour
{
    public float dashSpeed;
    public float dashDuration;
    public float baseMoveSpeed = 10;

    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private bool dashing = false;

    private GunBehavior gunBehavior;
    private Animator animator;

    public PlayerActionInputs playerControls;
    private InputAction move;
    private InputAction fire;
    private InputAction dashInput;

    void Awake() {
        playerControls = new PlayerActionInputs();
    }

    void OnEnable() {
        gunBehavior = gameObject.transform.Find("Gun").GetComponent<GunBehavior>();
        animator = gameObject.GetComponent<Animator>();

        InitInputActions();
    }

    void OnDisable() {
        move.Disable();
        fire.Disable();
        dashInput.Disable();
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = baseMoveSpeed;
    }

    void Update()
    {
        if (!dashing) {
            moveDir = move.ReadValue<Vector2>();
        }  
    }

    void FixedUpdate() {
        rb.velocity = moveDir * moveSpeed;
        animator.SetFloat("speed", moveDir.magnitude);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("PLAYER OnCollisionEnter");
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("PLAYER OnTriggerEnter2D");
    }

    IEnumerator dashCoroutine(float dashSpeed, float dashDuration) {
        dashing = true;
        moveSpeed = dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        moveSpeed = baseMoveSpeed;
        dashing = false;
    }

    void Dash(InputAction.CallbackContext context) {
        StartCoroutine(dashCoroutine(dashSpeed, dashDuration));
    }

    void Fire(InputAction.CallbackContext context) {
        //gunBehavior.Fire();
    }

    void InitInputActions() {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

        dashInput = playerControls.Player.Dash;
        dashInput.Enable();
        dashInput.performed += Dash;
    }
}
