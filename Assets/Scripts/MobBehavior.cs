using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBehavior : MonoBehaviour
{
    private enum State {
        Idle,
        Chase,
        GoHome
    }

    public bool activeAI = false;

    public float moveSpeed;
    public float IDLE_AND_GO_HOME_DURATION;
    public float MIN_DISTANCE_TO_CHASE;

    [SerializeField] private State state;
    private Vector2 initailPosition;
    private GameObject player;
    private Vector2 playerPosition;
    private Rigidbody2D rb;
    private bool chaseInterupted = false;

    void Awake() {
        SetState(State.Idle);
        initailPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (activeAI) {
            playerPosition = player.transform.position;

            if (Vector2.Distance(playerPosition, transform.position) < MIN_DISTANCE_TO_CHASE && !chaseInterupted) {
                SetState(State.Chase);
            }

            if (IsStateEqual(State.Chase)) {
                Chase();
            } else if (IsStateEqual(State.GoHome)) {
                GoHome();
            } else if (IsStateEqual(State.Idle)) {
                rb.velocity = Vector2.zero;
            }
        } 
    }

    private void Chase() {
        if (Vector2.Distance(initailPosition, playerPosition) > 0) {
            var dir = (player.transform.position - gameObject.transform.position).normalized;
            rb.velocity = dir * moveSpeed;
        }
    }

    private void GoHome() {
        if (Vector2.Distance(initailPosition, transform.position) < 0.01f) {
            var dir = (initailPosition - (Vector2)transform.position).normalized;
            rb.velocity = dir * moveSpeed;
        } else {
            Debug.Log("Reset");
            rb.velocity = Vector2.zero;
            SetState(State.Idle);
            chaseInterupted = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Mob collid with " + collider.transform.name + ". Is Bullet ? " + collider.gameObject.CompareTag("Bullet"));
        if (collider.gameObject.CompareTag("Bullet")) {
            StartCoroutine(IdleAndGoHome(IDLE_AND_GO_HOME_DURATION));
        }
    }

    IEnumerator IdleAndGoHome(float duration) {
        chaseInterupted = true;
        SetState(State.Idle);

        yield return new WaitForSeconds(duration);

        SetState(State.GoHome);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player")) {
            Destroy(gameObject);
        } else if (collision.transform.CompareTag("Bullet")) {
            StartCoroutine(IdleAndGoHome(IDLE_AND_GO_HOME_DURATION));
            Debug.Log("Mob got hit, going Home");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw gun center to mouse pos line
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, MIN_DISTANCE_TO_CHASE);
    }
    
    State GetState() {
        return state;
    }

    void SetState(State state) {
        Debug.Log("State change: " + this.state.ToString() + " -> " + state.ToString());
        this.state = state;
    }

    bool IsStateEqual(State state) {
        return this.state == state;
    }
}
