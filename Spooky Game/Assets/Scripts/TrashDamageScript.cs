using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrashDamageScript : MonoBehaviour
{

    bool isGrounded = false;
    public LayerMask groundLayer;
    private SpriteRenderer curSprite;
    public Sprite[] sprites;
    public UnityEvent trashBreakEvent;
    private int count = 1;

    private bool falling = false;

    public void Start()
    {
        curSprite = gameObject.GetComponent<SpriteRenderer>();
    }


    public int health = 4;
    private bool flag = true;

    void Update()
    {
        if(transform.position.y < -10)
        {
            transform.position = new Vector2(transform.position.x, 12);
        }
        if(transform.position.x > 9 || transform.position.x < -9)
        {
            transform.position = new Vector2(5 * transform.position.normalized.x, transform.position.y);
        }

        if(isGrounded)
        {
            Debug.Log("Grounded!");
        }

        if (falling == true && isGrounded && count < 5 && health > 0)
        {
            Debug.Log("-1 HP Current: " + health);
            health--;
            curSprite.sprite = sprites[count];
            falling = false;
            count++;
        }

        isGrounded = Physics2D.OverlapCircle(gameObject.transform.position, .9f, groundLayer);

        if (!isGrounded)
        {
            falling = true;
        }

        if(health == 0 && flag)
        {
            if (gameObject.CompareTag("EvilTrash"))
            {

            }
            gameObject.GetComponent<MouseMoveScript>().move = false;
            Debug.Log("Trash Event...");
            trashBreakEvent.Invoke();
            flag = false;
        }
    }

}
