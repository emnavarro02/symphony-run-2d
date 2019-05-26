using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{

    [SerializeField]
    private float damage = 1f;

    [SerializeField]
    private float life = 50f;
    // Start is called before the first frame update
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform bat;

    private float distanceLimit = 10.0f;

    private float maxDistanceFromStart = 50f;

    private int startingPosition = 20;

    private Rigidbody2D myRigidbody2D;

    void Start()
    {
        
    }

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(bat.position, player.position) < distanceLimit)
        {
            //light.enabled = true;
            Debug.Log("proximooooooooooooooo");
            //myRigidbody2D.velocity = new Vector2(10f, myRigidbody2D.velocity.y);
            transform.position = new Vector2(transform.position.x + (-2f * Time.deltaTime),
     transform.position.y);

        }
        else
        {
            //light.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
