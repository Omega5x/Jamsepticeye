using UnityEngine;

public class EnemiesScript : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;

    // Rigigbody of enemies and player
    private Rigidbody rb;
    private Rigidbody rb_player;

    private Vector3 moveVelocity;

    [Header("Enemy speed")]
    public float speed = 4f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb_player = player.GetComponent<Rigidbody>();
    }
    private void FixedUpdate() 
    {
        if (rb_player != null)
        {
            Vector3 direction = (rb_player.position - rb.position).normalized;
            rb.linearVelocity = direction * speed;
        }
    }
}
