using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovementPun : MonoBehaviourPunCallbacks
{
    public GameObject BasicoVFX, UltiVFX;

    public float speed, runningSpeed, rotationSpeed, jumpForce, sphereRadius;//,gravityScale;
    public string groundName;
    public int life = 3;
    private Animator _animator;
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

    public AudioClip audioAttack, audioSpecial, audioJump, audioUlt1, audioUlt2;

    public int minDeviceID = int.MaxValue;

    //public Material material;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //material = GetComponent<Material>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        
        
        _animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        PlayerManager[] managers = FindObjectsOfType<PlayerManager>();
        foreach (PlayerManager pm in managers)
        {
            if (pm.playerIndex == GetComponent<CharacterReference>().playerIndex)
            {
                this.playerManager = pm;
                break;
            }
        }
        print(character);

        if (GetComponent<CharacterReference>().playerIndex == 1)
        {
            Color32 color = skinnedMeshRenderer.material.color = new Color(0.3f, 1f, 1f, 1f);
            //skinnedMeshRenderer.material.color = Color.blue;
            
            //skinnedMeshRenderer.material.color.a = 1f;
            //material.color = Color.blue;
        }
        else
        {
            Color32 color = skinnedMeshRenderer.material.color = new Color(1f, 0.6f, 0.6f, 0.5f);
            //skinnedMeshRenderer.material.color = Color.red;
        }
        foreach (Gamepad gp in Gamepad.all)
        {
            if (minDeviceID > gp.deviceId)
            {
                minDeviceID = gp.deviceId;
            }
        }
        character = playerManager.GetCharacter();

    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
        {
            return;
        }

        currentTimeSpAtt += Time.deltaTime;
        currentTimeSuAtt += Time.deltaTime;
        // bool isMyController = false;
        //if (playerInput.actions["Move"].activeControl != null)
        //    isMyController = playerInput.actions["Move"].activeControl.device.deviceId - minDeviceID == playerManager.playerIndex;//playerInput.actions["Move"].GetBindingIndexForControl(playerInput.actions["Move"].controls[(int)playerManager.playerIndex]) == playerManager.playerIndex;
        _animator.SetBool("IsWalking", false);
        //if (!isMyController)
        //{
        //    _animator.SetBool("IsWalking", false);
        //    return;
        //}
        movementVector = playerInput.actions["Move"].ReadValue<Vector2>();


        if (movementVector.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            _animator.SetBool("IsWalking", true);
        }
        else if (movementVector.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            _animator.SetBool("IsWalking", true);
        }
        //if (Input.GetButtonDown(playerManager.playerIndex == 0 ? "Jump" :"Jump 2"))
        //{
        //    _animator.SetBool("IsJumping", true);
        //AudioManager.instance.PlayAudio(audioJump, "Jump", false, 0.8f);
        //    jumpPressed = true;
        //}
        //jump
        //if (Input.GetButtonDown(playerManager.playerIndex == 0 ? "Fire1" : "Fire1 2"))
        //{
        //    _animator.SetBool("IsAttacking", true);
        //    character.Attack(gameObject);
        //    AudioManager.instance.PlayAudio(audioAttack, "Attack", false, 1f);
        //    Debug.Log("cua");
        //}
        //else
        //{
        //    _animator.SetBool("IsAttacking", false);
        //}
        //attack
        //if(Input.GetButtonDown(playerManager.playerIndex == 0 ? "Fire2" : "Fire2 2")) 
        //{
        //    _animator.SetBool("IsSpecial", true);
        //    character.SpecialAttack(gameObject);
        //    AudioManager.instance.PlayAudio(audioSpecial, "Special", false, 0.8f);
        //    Debug.Log("cir");
        //}
        //else
        //{
        //    _animator.SetBool("IsSpecial", false);
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
        //print("sios" + playerManager.playerIndex);
        // bool isMyController = callbackContext.control.device.deviceId - minDeviceID == playerManager.playerIndex;//true;//playerInput.playerIndex == callbackContext.control.device.name; //callbackContext.action.GetBindingIndexForControl(callbackContext.control) == playerManager.playerIndex;
        if (callbackContext.performed)
        {
            print(this);
            GetComponentInChildren<Animator>().SetBool("IsJumping", true);
            AudioManager.instance.PlayAudio(audioJump, "Jump", false, 0.8f);
            jumpPressed = true;
        }
    }

    public void SpAttackInput(InputAction.CallbackContext callbackContext)
    {
        //bool isMyController = callbackContext.action.GetBindingIndexForControl(callbackContext.control) == playerManager.playerIndex;
        if (callbackContext.performed && currentTimeSpAtt >= 1.5f)
        {
            _animator.SetBool("IsSpecial", true);
            character.SpecialAttack(gameObject);
            AudioManager.instance.PlayAudio(audioSpecial, "Special", false, 0.8f);
            Debug.Log("cir");
            currentTimeSpAtt = 0f;
        }
        else
        {
            _animator.SetBool("IsSpecial", false);
        }
    }

    public void AttackInput(InputAction.CallbackContext callbackContext)
    {
        //bool isMyController = callbackContext.action.GetBindingIndexForControl(callbackContext.control) == playerManager.playerIndex;
        if (callbackContext.performed)
        {
            _animator.SetBool("IsAttacking", true);
            character.Attack(gameObject);
            AudioManager.instance.PlayAudio(audioAttack, "Attack", false, 1f);
            Debug.Log("cua");
            
            StartCoroutine(BasicVFX());
        }
        else
        {
            
            _animator.SetBool("IsAttacking", false);
        }
    }

    public void AttackUpInput(InputAction.CallbackContext callbackContext) 
    {
        if (callbackContext.performed)
        {
            _animator.SetBool("IsAttackingUp", true);
            character.UpAttack(gameObject);

            Debug.Log("ua");
        }
        else 
        { 
            _animator.SetBool("IsAttakingUp", false);
        }
    }
    
    public void AttackDownInput(InputAction.CallbackContext callbackContext) 
    {
        if (callbackContext.performed)
        {
            _animator.SetBool("IsAttackingDown", true);
            character.DownAttack(gameObject);

            Debug.Log("bye");
        }
        else 
        { 
            _animator.SetBool("IsAttakingDown", false);
        }
    }
    public void SuperAttack(InputAction.CallbackContext callbackContext)
    {
        //bool isMyController = callbackContext.action.GetBindingIndexForControl(callbackContext.control) == playerManager.playerIndex;
        if (callbackContext.performed && currentTimeSuAtt>=10)
        {
            _animator.SetBool("IsUlting", true);
            character.SuperAttack(gameObject);
            AudioManager.instance.PlayAudio(audioUlt1, "Ulti1", false, 1f);
            AudioManager.instance.PlayAudio(audioUlt2, "Ulti2", false, 1f);
            Debug.Log("tri");
            currentTimeSuAtt = 0;

            StartCoroutine(SuperVFX());
        }
        else
        {
            _animator.SetBool("IsUlting", false);
        }

    }
    public IEnumerator BasicVFX()
    {
        BasicoVFX.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        BasicoVFX.SetActive(false);
    }
    public IEnumerator SuperVFX()
    {
        UltiVFX.SetActive(true);
        yield return new WaitForSeconds(2);
        UltiVFX.SetActive(false);
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
        Death();
        jumpPressed = false;
    }

    void ApplySpeed()
    {
        //rb.velocity = (transform.forward * speed * z) + (transform.right * speed * x) +
        //    new Vector3(0, rb.velocity.y, 0); //Gravedad base de Unity.
        //+ (transform.up * gravityScale); //Gravedad constante no realista
        //rb.AddForce(transform.up * gravityScale);
        rb.AddForce(new Vector3(movementVector.x * 1.2f, 0, 0) * speed);
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
                _animator.SetBool("IsJumping", false);
                doubleJump = 0;
                return true;
            }
        }
        _animator.SetBool("IsJumping", true);
        return false;
    }
    private void Death()
    {
        if (life == 0)
        {
            GameManager.instance.LoadScene("Menu");
        }
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
        nospeed = true;
        yield return new WaitForSeconds(1);
        nospeed = false;
    }

    public void kk1()
    {
        StartCoroutine(kk());
    }
}