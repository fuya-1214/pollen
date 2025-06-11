using Unity.Burst;
using UnityEditor.Callbacks;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float moveSpeed;
    [SerializeField] private float sprintSpeed, WalkSpeed;
    [SerializeField] private float groundDrag;
    [SerializeField] private float playerheight;
    [SerializeField] private LayerMask Ground;
    bool grounded;

    [SerializeField] private Transform orientation;

    private float HorizontalInput;
    private float VerticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private Animator anim;

    public MovementState state;

    public enum MovementState
    {
        walking, // 歩いている状態
        spriting, // 走っている状態
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        GameObject child = transform.Find("HumanM_Dummy_Red - Dual Wield").gameObject;
        anim = child.GetComponent<Animator>();
    }

    // Update is called once per frame
        void Update()
    {
        //地面と接しているかを判断
        grounded = Physics.Raycast(transform.position, Vector3.down, playerheight * 0.5f * 0.2f, Ground);

        //接している場合は、設定した減速値を代入しプレイヤーを滑りにくくする
        if (grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }

        StateHandler();
        ProcessInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void ProcessInput()
    {
        // 入力を取得
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }

    private void movePlayer()
    {
        // 向いている方向に進む
        moveDirection = orientation.forward * VerticalInput + orientation.right * HorizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        anim.SetFloat("ForwardSpeed", Input.GetAxis("Vertical"));
        anim.SetFloat("LateralSpeed", Input.GetAxis("Horizontal"));
    }

    private void SpeedControl()
    {
        // プレイヤーのスピードの制限
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void StateHandler()
    {
        //左シフトを押しているかつ地面と接している場合は、ステートをsprintingにして走る
        if (Input.GetKey(KeyCode.LeftShift))
        {
            state = MovementState.spriting;
            moveSpeed = sprintSpeed;
        }

        // ただ移動ボタンを押している場合は、ステートをwalkingにして歩く
        else
        {
            state = MovementState.walking;
            moveSpeed = WalkSpeed;
        }
    }
}
