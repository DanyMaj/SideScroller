using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMovement_01: MonoBehaviour
{
    public Rigidbody2D rb; //Ne pas oublier d'activer la gravity scale du rigidbody et d'ajouter un collider
    public float speed;
    public float jumpforce;
    public Animator anime;
    public LayerMask mask; //Quels layer seront affecté par le raycast attention a ne pas ajouter le layer de votre perso sinon le raycast va trouver le perso avant de trouver le sol
    public SpriteRenderer sr;

    void Update()
    {
        var hDirection = 0f;
        var vDirection = 0f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckGround())
            {
                vDirection += jumpforce;
            }

            if (CheckRightWall())
            {
                vDirection += jumpforce;
            }

            if (CheckLeftWall())
            {
                vDirection += jumpforce;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            hDirection += -1;
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            hDirection += 1;
            sr.flipX = true;
        }

        rb.linearVelocity = new Vector2(hDirection * speed, rb.linearVelocityY + vDirection); //On set up la velocité horizontal 
        
        if (rb.linearVelocity.y > 0)
        {
            anime.SetBool("jump", true);
        }
        else if (rb.linearVelocity.y < 0)
        {
            anime.SetBool("jump", false);
        }
        if (hDirection != 0)
        {
            anime.SetBool("walk", true);
        }
        else
        {
            anime.SetBool("walk", false);
        }
    }

    public bool CheckGround()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.6f, mask);
        if (rayCastHit)
        {
            return true;
        }
        return false;
        
    }

    public bool CheckRightWall()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(1, 0), 0.6f, mask);
        if (rayCastHit)
        {
            return true;
        }
        return false;
     }

    public bool CheckLeftWall()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 0.6f, mask);
        if (rayCastHit)
        {
            return true;
        }
        return false;
    }
    //localSclale
}