using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{

    public float speed = 3.0f;

    public int maxHealth = 5;

    public float timeInvinceble = 2.0f;

    public int health { get { return currentHealth; } }
    int currentHealth;

    Rigidbody2D rb;
    float horizontal;
    float vertical;

    bool isInvinceble;
    float invincebleTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvinceble)
        {
            invincebleTimer -= Time.deltaTime;
            if(invincebleTimer < 0)
            {
                isInvinceble = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rb.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            if (isInvinceble)
                return;

            isInvinceble = true;
            invincebleTimer = timeInvinceble;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
