using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
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
        if(atk1HoldDown && Input.GetKey(KeyCode.Q))
        {
            Attack1();
        } else if (!atk1HoldDown && Input.GetKeyDown(KeyCode.Q))
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
                gravity = -1;
                MovementVector.y = gravity * JumpMultiplier;
            }
            else
            {
                MovementVector.y = 0;
            }
        }
        else
        {
            if (!(gravity >= 1))
            {
                gravity += Time.deltaTime;
            }
            MovementVector.y = gravity * gravityMultiplier;
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
            if(mR.flipX)
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
        if(direction)
        {
            d = Vector2.right;
        } else
        {
            d = Vector2.left;
        }
        if(atk1isMelee)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, d, atk1Range);
            Health hp = hit.collider.gameObject.GetComponent<Health>();
            if (hp != null) {
                hp.TakeDamage(atk1Damage);
            }
        } else
        {
            Debug.LogError("I haven't programmed that path yet, damage type not melee");
        }
        
    }

    public void ChangeCharacter()
    {

    }
}
