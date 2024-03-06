using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagneticFunction : MonoBehaviour
{
    
    Rigidbody2D rb;

    [SerializeField] float magStrengthVert = 1f;
    [SerializeField] float magStrengthHoriz = 5f;
    [SerializeField] float castDistance = 5f;

    bool isGrounded = false;
    bool isRepel = false;
    bool isHitUp = false;
    bool isHitDown = false;
    bool isHitRight = false;
    bool isHitLeft = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MagnetUp(); 
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            MagnetDown(); 
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MagnetRight(); 
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MagnetLeft(); 
        }
    }

    void MagnetUp()
    {
        int magneticLayerMask = LayerMask.GetMask("Magnetic");

        RaycastHit2D raycastHit = Physics2D.Raycast (transform.position, Vector2.up, castDistance, magneticLayerMask);

        Rigidbody2D hitRb = raycastHit.rigidbody.GetComponent<Rigidbody2D>();

        if (raycastHit.collider != null)
        {
            isHitUp = true;
        }
        else
        {
            isHitUp = false;
        }

        if(isHitUp == true)
        {
            if (isGrounded == false)
            {
                if(isRepel == false)
                {
                    rb.AddForce(Vector2.up * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    rb.AddForce(Vector2.up * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
            else
            {
                if(isRepel == false)
                {
                    hitRb.AddForce(Vector2.down * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    hitRb.AddForce(Vector2.down * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
        }
    }

    void MagnetDown()
    {
        int magneticLayerMask = LayerMask.GetMask("Magnetic");

        RaycastHit2D raycastHit = Physics2D.Raycast (transform.position, Vector2.down, castDistance, magneticLayerMask);

        Rigidbody2D hitRb = raycastHit.rigidbody.GetComponent<Rigidbody2D>();

        if (raycastHit.collider != null)
        {
            isHitDown = true;
        }
        else
        {
            isHitDown = false;
        }

        if(isHitDown == true)
        {
            if (isGrounded == false)
            {
                if(isRepel == false)
                {
                    rb.AddForce(Vector2.down * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    rb.AddForce(Vector2.down * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
            else
            {
                if(isRepel == false)
                {
                    hitRb.AddForce(Vector2.up * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    hitRb.AddForce(Vector2.up * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
        }
    }

    void MagnetRight()
    {
        int magneticLayerMask = LayerMask.GetMask("Magnetic");

        RaycastHit2D raycastHit = Physics2D.Raycast (transform.position, Vector2.right, castDistance, magneticLayerMask);

        Rigidbody2D hitRb = raycastHit.rigidbody.GetComponent<Rigidbody2D>();

        if (raycastHit.collider != null)
        {
            isHitRight = true;
        }
        else
        {
            isHitRight = false;
        }

        if(isHitRight == true)
        {
            if (isGrounded == false)
            {
                if(isRepel == false)
                {
                    rb.AddForce(Vector2.right * magStrengthHoriz, ForceMode2D.Force);
                }
                else
                {
                    rb.AddForce(Vector2.right * magStrengthHoriz * -1f, ForceMode2D.Force);
                }
            }
            else
            {
                if(isRepel == false)
                {
                    hitRb.AddForce(Vector2.left * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    hitRb.AddForce(Vector2.left * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
        }
    }

    void MagnetLeft()
    {
        int magneticLayerMask = LayerMask.GetMask("Magnetic");

        RaycastHit2D raycastHit = Physics2D.Raycast (transform.position, Vector2.left, castDistance, magneticLayerMask);

        Rigidbody2D hitRb = raycastHit.rigidbody.GetComponent<Rigidbody2D>();

        if (raycastHit.collider != null)
        {
            isHitLeft = true;
        }
        else
        {
            isHitLeft = false;
        }

        if(isHitLeft == true)
        {
            if (isGrounded == false)
            {
                if(isRepel == false)
                {
                    rb.AddForce(Vector2.left * magStrengthHoriz, ForceMode2D.Force);
                }
                else
                {
                    rb.AddForce(Vector2.left * magStrengthHoriz * -1f, ForceMode2D.Force);
                }
            }
            else
            {
                if(isRepel == false)
                {
                    hitRb.AddForce(Vector2.right * magStrengthVert, ForceMode2D.Force);
                }
                else
                {
                    hitRb.AddForce(Vector2.right * magStrengthVert * -1f, ForceMode2D.Force);
                }
            }
        }
    }

    void OnToggleRepel()
    {
        ToggleRepel();
    }

    private void ToggleRepel()
    {
        if(isRepel == false)
        {
            isRepel = true;
        }
        else
        {
            isRepel = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        List<GameObject> currentCollisions = new List<GameObject>();
        currentCollisions.Add(collision.gameObject);
        Debug.Log(currentCollisions);
        isGrounded = false;
        for (int i = 0; i < collision.contactCount; i++)
        {
            if (Vector2.Angle(collision.GetContact(i).normal, Vector2.up) < 45f)
            {
                Debug.Log(Vector2.Angle(collision.GetContact(i).normal, Vector2.up));
                isGrounded = true;
                return;
            }
        }
    }
}


//issues:
//player still able to run around while the magnet is in place