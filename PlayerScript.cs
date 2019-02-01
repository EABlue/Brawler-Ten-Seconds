using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
   

    [Header("Movement")]
    public bool touching;
    public float MovementSpeed;
    float gravity;
    public float gravityMultiplier;
    public float JumpMultiplier;
    private bool direction = true; //true if right, false if left

    [Space(10)]

    [Header("Attack 1")]
    public bool atk1HoldDown;
    public bool atk1isMelee;
    public float atk1Range;
    public float atk1hitForce;
    public float atk1Damage;
    public float atk1Cool;
    [Space(10)]
    [Header("Sprites")]
    private SpriteRenderer mR;
    public Sprite idle;
    public Sprite jumping;

    // Start is called before the first frame update
    void Start()
    {
        mR = GetComponent<SpriteRenderer>();
        touching = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool oldDirection = direction;

        print(touching);

        //Attack 1
        atk1Cool += Time.deltaTime;
        if ((atk1Cool >= 1) &&Input.GetKey(KeyCode.C))
        {
            Attack1();
        }


        //Gravity and Movement
        Vector2 MovementVector = new Vector2(0, 0);

        if (!(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                direction = false;
                MovementVector.x = -1 * MovementSpeed;

            }
            if (Input.GetKey(KeyCode.D))
            {
                direction = true;
                MovementVector.x = MovementSpeed;
            }
        }

        if (touching)
        {
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpMultiplier));
            }
        }

        transform.Translate(MovementVector);

        //Sprite Changing
        if (touching)
        {
            mR.sprite = idle;
        }
        else
        {
            mR.sprite = jumping;
        }

        if (oldDirection != direction)
        {
            if (mR.flipX)
            {
                mR.flipX = false;
            }
            else
            {
                mR.flipX = true;
            }

        }
    }



    void Attack1()
    {
        Vector2 d;
        if (direction)
        {
            d = Vector2.right;
        }
        else
        {
            d = Vector2.left;
        }
        if (atk1isMelee)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, d, atk1Range);
            Health hp = hit.collider.gameObject.GetComponent<Health>();
            if (hp != null)
            {
                hp.TakeDamage(atk1Damage);
                int directionValue = 0;
                if (direction) {
                    directionValue = 1;
                } else {
                    directionValue = -1;
                }
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (directionValue, 0), ForceMode2D.Impulse);
            }
        }
        else
        {
            Debug.LogError("I haven't programmed that path yet, damage type not melee");
        }

    }

    void AttackGiacmo()
    {
        Vector2 d;
        if (direction)
        {
            d = Vector2.right;
        }
        else
        {
            d = Vector2.left;
        }
            RaycastHit2D hit = Physics2D.Raycast(transform.position, d, atk1Range * 2);
            Health hp = hit.collider.gameObject.GetComponent<Health>();
        if (hp != null)
        {
            hp.TakeDamage(13);
            int directionValue = 0;
            if (direction)
            {
                directionValue = 1;
            }
            else
            {
                directionValue = -1;
            }
            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(directionValue, 0), ForceMode2D.Impulse);
        }
    }

    void AttackRobot () {
        foreach (Collider2D c in Physics2D.OverlapBoxAll(transform.position, new Vector2 (atk1Range * 1.5f, 16), 0)) {
            if (c.gameObject.tag == "Player")
            {
                Health hp = c.gameObject.GetComponent<Health>();
                hp.TakeDamage(8);
            }
        }
    }

    public void Knockback (float x, float y, float power) {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(x * power, y * power));
    }

    public void ChangeCharacter()
    {

    }
}