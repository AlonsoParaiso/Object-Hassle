using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    public float speed, runningSpeed, rotationSpeed, jumpForce, sphereRadius;//,gravityScale;

    public string groundName;
    private Animator animator;
    private float currentTimeAtt;
    private float currentTimeSpAtt;
    private float currentTimeSuAtt;

    private Vector2 movementVector;
    private PlayerManager playerManager;
    private Rigidbody rb;
    private PlayerInput playerInput;

    private bool jumpPressed, nospeed;
    public int doubleJump;
    public Character character;

    public AudioClip audioAttack, audioSpecial, audioJump, audioUlt, audioWalk;

    public int minDeviceID = int.MaxValue;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        PlayerManager[] managers = FindObjectsOfType<PlayerManager>(); 
        foreach(PlayerManager pm in managers)
        {
            if(pm.playerIndex == GetComponent<CharacterReference>().playerIndex)
            {
                this.playerManager = pm;
                break;
            }
        }

        foreach(Gamepad gp in Gamepad.all)
        {
            if(minDeviceID > gp.deviceId)
            {
                minDeviceID = gp.deviceId;
            }
        }
        character = playerManager.GetCharacter();

    }

    // Update is called once per frame
    void Update()
    {
        currentTimeAtt = Time.deltaTime;
        currentTimeSpAtt = Time.deltaTime;
        currentTimeSuAtt = Time.deltaTime;
       // bool isMyController = false;
        //if (playerInput.actions["Move"].activeControl != null)
        //    isMyController = playerInput.actions["Move"].activeControl.device.deviceId - minDeviceID == playerManager.playerIndex;//playerInput.actions["Move"].GetBindingIndexForControl(playerInput.actions["Move"].controls[(int)playerManager.playerIndex]) == playerManager.playerIndex;
        animator.SetBool("IsWalking", false);
        //if (!isMyController)
        //{
        //    animator.SetBool("IsWalking", false);
        //    return;
        //}
        movementVector = playerInput.actions["Move"].ReadValue<Vector2>();


        if (movementVector.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            animator.SetBool("IsWalking", true);
            AudioManager.instance.PlayAudio(audioWalk, "Walk", false, 0.1f);
        }
        else if (movementVector.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            animator.SetBool("IsWalking", true);
            AudioManager.instance.PlayAudio(audioWalk, "Walk", false, 0.1f);
        }
        //if (Input.GetButtonDown(playerManager.playerIndex == 0 ? "Jump" :"Jump 2"))
        //{
        //    animator.SetBool("IsJumping", true);
              //AudioManager.instance.PlayAudio(audioJump, "Jump", false, 0.8f);
        //    jumpPressed = true;
        //}
        //jump
        //if (Input.GetButtonDown(playerManager.playerIndex == 0 ? "Fire1" : "Fire1 2"))
        //{
        //    animator.SetBool("IsAttacking", true);
        //    character.Attack(gameObject);
        //    AudioManager.instance.PlayAudio(audioAttack, "Attack", false, 1f);
        //    Debug.Log("cua");
        //}
        //else
        //{
        //    animator.SetBool("IsAttacking", false);
        //}
        //attack
        //if(Input.GetButtonDown(playerManager.playerIndex == 0 ? "Fire2" : "Fire2 2")) 
        //{
        //    animator.SetBool("IsSpecial", true);
        //    character.SpecialAttack(gameObject);
        //    AudioManager.instance.PlayAudio(audioSpecial, "Special", false, 0.8f);
        //    Debug.Log("cir");
        //}
        //else
        //{
        //    animator.SetBool("IsSpecial", false);
        //}
        //SpecialAttack
        //if (Input.GetButtonDown(playerManager.playerIndex == 0 ? "Fire3" : "Fire3 2"))
        //{
        //    character.SuperAttack(gameObject);
        //    AudioManager.instance.PlayAudio(audioUlt, "Ulti", false, 1f);
        //    Debug.Log("tri");
        //}
        //super
        //IsGrounded();
    }

    public void JumpInput(InputAction.CallbackContext callbackContext)
    {

        // Gamepad.all[(int)playerManager.playerIndex].buttonSouth.IsPressed()
        //print("Player: " +( callbackContext.control.device.deviceId - minDeviceID));
        //print("sos: " + playerInput.devices[0].deviceId);
        print("sios" + playerManager.playerIndex);
       // bool isMyController = callbackContext.control.device.deviceId - minDeviceID == playerManager.playerIndex;//true;//playerInput.playerIndex == callbackContext.control.device.name; //callbackContext.action.GetBindingIndexForControl(callbackContext.control) == playerManager.playerIndex;
        if (callbackContext.performed)
        {
            animator.SetBool("IsJumping", true);
            AudioManager.instance.PlayAudio(audioJump, "Jump", false, 0.8f);
            jumpPressed = true;
        }
    }

    public void AttackInput(InputAction.CallbackContext callbackContext)
    {
        bool isMyController = callbackContext.action.GetBindingIndexForControl(callbackContext.control) == playerManager.playerIndex;
        if (callbackContext.performed && isMyController)
        {
            animator.SetBool("IsSpecial", true);
            character.SpecialAttack(gameObject);
            AudioManager.instance.PlayAudio(audioSpecial, "Special", false, 0.8f);
            Debug.Log("cir");
        }
        else
        {
            animator.SetBool("IsSpecial", false);
        }
    }

    public void SpAttackInput(InputAction.CallbackContext callbackContext)
    {
        bool isMyController = callbackContext.action.GetBindingIndexForControl(callbackContext.control) == playerManager.playerIndex;
        if (callbackContext.performed && isMyController)
        {
            animator.SetBool("IsAttacking", true);
            character.Attack(gameObject);
            AudioManager.instance.PlayAudio(audioAttack, "Attack", false, 1f);
            Debug.Log("cua");
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
    public void SuperAttack(InputAction.CallbackContext callbackContext)
    {
        bool isMyController = callbackContext.action.GetBindingIndexForControl(callbackContext.control) == playerManager.playerIndex;
        if (callbackContext.performed && isMyController)
        {
            character.SuperAttack(gameObject);
            AudioManager.instance.PlayAudio(audioUlt, "Ulti", false, 1f);
            Debug.Log("tri");
        }
        else
        {
            
        }

    }

    public Vector3 GetMovementVector()
    {
        return movementVector;
    }

    private void FixedUpdate()
    {
        if (!nospeed) 
        ApplySpeed();
        IsGrounded();
        ApplyJumpSpeed();
        jumpPressed = false;
    }

    void ApplySpeed()
    {
        //rb.velocity = (transform.forward * speed * z) + (transform.right * speed * x) +
        //    new Vector3(0, rb.velocity.y, 0); //Gravedad base de Unity.
        //+ (transform.up * gravityScale); //Gravedad constante no realista
        //rb.AddForce(transform.up * gravityScale);
        rb.AddForce(new Vector3(movementVector.x, 0, 0) * speed);
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

    IEnumerator kk()
    {
        nospeed=true;
        yield return new WaitForSeconds(1);
        nospeed = false;
    }

    public void kk1()
    {
        StartCoroutine(kk());
    }
}