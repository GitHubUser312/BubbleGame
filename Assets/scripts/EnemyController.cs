using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    enum State
    {
        Frozen,
        Chasing,
    }

    [SerializeField]
    private GameObject popEffect;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed = 4;

    private int health = 100;
    [SerializeField]
    private float freezeTime = 3.0f;
    [SerializeField]
    private float waitTimer = 0.0f;
    [SerializeField]
    private bool isFrozen = false;
    private Rigidbody2D rb;
    State state = State.Chasing;

    // Delta time tracking
    private float localDelta = 0.0f;
    // Can be used to log only once per second
    private bool localDeltaWait = false;
    // local int for delta time tracking
    private int localInt = 0;

    void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ChasePlayer();
        //switch (state)
        //{
        //    case State.Frozen:
        //        Frozen();
        //        break;
        //    case State.Chasing:
        //        ChasePlayer();
        //        break;
        //    default:
        //        Debug.LogError("Unknown state!");
        //        break;
        //}

        localDelta += Time.deltaTime;
        // Updates every second
        if ((int)localDelta > localInt)
        {
            ++localInt;
            localDeltaWait = true;
        }

        Frozen();

        // Must be at the end of this Update
        if (localDeltaWait) { localDeltaWait = false; }
    }
    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
        Instantiate(popEffect, transform.position, Quaternion.identity);
    }

    public void FreezeEnemy()
    {
        isFrozen = true;
    }

    private void Frozen()
    {
        // freeze for some time
        if (isFrozen)
        {
            if (speed != 0) { speed = 0; }
            waitTimer += Time.fixedDeltaTime;
            if (waitTimer > freezeTime)
            {
                isFrozen = false;
                waitTimer = 0.0f;
            }
        }
        else if (waitTimer != 0.0f) { waitTimer = 0.0f; }
        else if (speed == 0) { speed = 4; }

        if (localDeltaWait && isFrozen) { Debug.Log("Enemy isFrozen waitTimer: " + waitTimer); }


    }
    private void ChasePlayer()
    {
        // Checks if the player exists
        if (player)
        {
            // facing the player
            Vector2 direction = (transform.position - player.transform.position).normalized;
            //rb.linearVelocity = -direction * speed; // does the same thing
            rb.MovePosition(rb.position - speed * Time.fixedDeltaTime * direction);
        }
    }

    IEnumerator TakeDamage(int damage, int delay)
    {
        health -= damage;
        yield return new WaitForSeconds(delay);
    }

    void Die()
    {
        Destroy(gameObject);
        Instantiate(popEffect, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 v2;
        v2.y = 10;
        v2.x = 10;

        //Debug.Log("Player OnCollisionEnter2D with " + collision.gameObject.name);
        // bounce away from player
        //rb.linearVelocity = (-rb.linearVelocity * 20) - v2;
    }
}
