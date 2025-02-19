using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, runningSpeed, rotationSpeed, jumpForce, sphereRadius;//,gravityScale;

    public string groundName;
    private Animator animator;

    private Vector3 movementVector;
    private PlayerManager playerManager;
    private Rigidbody rb;
    private float x, z; //input
    private bool jumpPressed;
    public int doubleJump;
    public Character character;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        PlayerManager[] managers = FindObjectsOfType<PlayerManager>(); 
        foreach(PlayerManager pm in managers)
        {
            if(pm.playerIndex == GetComponent<CharacterReference>().playerIndex)
            {
                this.playerManager = pm;
                break;
            }
        }
        character = playerManager.GetCharacter();
        //character = new ReyBomba(name, 5, 5);

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw(playerManager.playerIndex == 0 ? "Horizontal" : "Horizontal 2");
        z = Input.GetAxisRaw(playerManager.playerIndex == 0 ? "Vertical" : "Vertical 2");

        if (x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            animator.SetBool("IsWalking", true);
        }
        else if (x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            animator.SetBool("IsWalking", true);
        }

        else
        {
            animator.SetBool("IsWalking", false);

        }



        if (Input.GetButtonDown(playerManager.playerIndex == 0 ? "Jump" :"Jump 2"))
        {
            animator.SetBool("IsJumping", true);
            jumpPressed = true;
        }

        //jump

        if (Input.GetButtonDown(playerManager.playerIndex == 0 ? "Fire1" : "Fire1 2"))
        {
            animator.SetBool("IsAttacking", true);
            character.Attack(gameObject);
            Debug.Log("cua");
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }



        if(Input.GetButtonDown(playerManager.playerIndex == 0 ? "Fire2" : "Fire2 2")) 
        {
            animator.SetBool("IsSpecial", true);
            character.SpecialAttack(gameObject);
            Debug.Log("cir");
        }
        else
        {
            animator.SetBool("IsSpecial", false);
        }

        if (Input.GetButtonDown(playerManager.playerIndex == 0 ? "Fire3" : "Fire3 2"))
        {
            character.SuperAttack(gameObject);
            Debug.Log("tri");
        }
        IsGrounded();
    }


    public Vector3 GetMovementVector()
    {
        return movementVector;
    }

    private void FixedUpdate()
    {
        ApplySpeed();
        ApplyJumpSpeed();
        jumpPressed = false;
    }

    void ApplySpeed()
    {
        rb.velocity = (transform.forward * speed * z) + (transform.right * speed * x) +
            new Vector3(0, rb.velocity.y, 0); //Gravedad base de Unity.
        //+ (transform.up * gravityScale); //Gravedad constante no realista
        //rb.AddForce(transform.up * gravityScale);
    }

    void ApplyJumpSpeed()
    {
        if (jumpPressed && (IsGrounded() || doubleJump < 1))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce);
            doubleJump++;
            
        }
    }

    private bool IsGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(transform.position.x,
            transform.position.y - transform.localScale.y / 2, transform.position.z), sphereRadius);

        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer(groundName)) //Recorre cada elemento del array para ver si tocamos suelo
            {
                animator.SetBool("IsJumping", false);
                doubleJump = 0;
                return true;
            }
        }
        animator.SetBool("IsJumping", true);
        return false;
    }

    private void OnDrawGizmos() //Raycast de la esfera.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,
            transform.position.y - transform.localScale.y / 2, transform.position.z), sphereRadius);

        character.DrawGizmos(gameObject);
    }
}