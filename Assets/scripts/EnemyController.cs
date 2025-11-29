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
    float freezeTime = 3.0f;
    float waitTimer = 0.0f;
    private Rigidbody2D rb;
    State state = State.Chasing;
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
    }
    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
        Instantiate(popEffect, transform.position, Quaternion.identity);
    }

    private void Frozen()
    {
        // freeze for some time


        //waitTimer -= Time.fixedDeltaTime; //?Time.deltaTime;
        //if (waitTimer > Time.deltaTime + freezeTime)
        //{
        //    state = State.Chasing;
        //}




    }
    private void ChasePlayer()
    {
        // facing the player
        Vector2 direction = (transform.position - player.transform.position).normalized;
        //rigid.linearVelocity = -direction * speed; // does the same thing
        rb.MovePosition(rb.position - speed * Time.fixedDeltaTime * direction);
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

        Debug.Log("Player OnCollisionEnter2D with " + collision.gameObject.name);
        // bounce away from player
        rb.linearVelocity = (-rb.linearVelocity * 20) - v2;
    }
}
