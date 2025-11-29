using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject popEffect;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed = 4;

    private int health = 100;
    private Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    
    }

    private void FixedUpdate()
    {
        // facing the player
        Vector2 direction = (transform.position - player.transform.position).normalized;
        //rigid.linearVelocity = -direction * speed;
        rigid.MovePosition(rigid.position - direction * speed * Time.fixedDeltaTime);
    }
    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit!");
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
}
