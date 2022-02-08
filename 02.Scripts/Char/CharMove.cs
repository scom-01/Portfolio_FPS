using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    float h;
    float v;
    float x;
    float Speed;

    public float Gravity = 20.0f;
    public float WalkSpeed = 6.0f;
    public float Jumpforce = 8.0f;
    public float MaxSpeed = 5.0f;
    //public bool isGround = true;

    public CharState CurState;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 External_Direction = Vector3.zero;
    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        Gravity = 20.0f;
        QualitySettings.vSyncCount = 0;
        moveDirection = Vector3.zero;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //IsGround();
        //TryJump();
        Rotate();
        Move();
        //Debug.Log(moveDirection.y);
    }

    //void TryJump()
    //{
    //    if (Input.GetKey(KeyCode.Space) && isGround)
    //    {
    //        Jump();
    //    }
    //}

    //void Jump()
    //{
    //    //rigid.velocity = transform.up * Jumpforce;
    //    moveDirection.y = Jumpforce;
    //}

    void Move()
    {
        h = 0;
        v = 0;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = WalkSpeed / 2;
        }
        else
        {
            Speed = WalkSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            v += GlobalValue.deltaTime * 50f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            v -= GlobalValue.deltaTime * 50f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            h += GlobalValue.deltaTime * 50f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            h -= GlobalValue.deltaTime * 50f;
        }

        if (cc.isGrounded)
        {
            moveDirection = new Vector3(h, 0, v).normalized;
            //moveDirection.x = h;
            //moveDirection.z = v;
            moveDirection *= Speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = Jumpforce;
            }
        }
        else
        {
            float tempY = moveDirection.y;
            moveDirection = new Vector3(h, 0, v).normalized;
            moveDirection *= Speed;
            moveDirection.y = tempY;
        }

        External_Vec_Cal();
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection.y -= Gravity * GlobalValue.deltaTime;
        cc.Move(moveDirection * GlobalValue.deltaTime + External_Direction*GlobalValue.deltaTime);
        //External_Direction = Vector3.zero;
    }

    //private void IsGround()
    //{
    //    if (Physics.Raycast(transform.position, Vector3.down, cc.bounds.extents.y + 0.1f)|| //중점
    //        Physics.Raycast(transform.position + transform.forward* cc.bounds.extents.x, Vector3.down, cc.bounds.extents.y + 0.1f)||
    //        Physics.Raycast(transform.position - transform.forward * cc.bounds.extents.x, Vector3.down, cc.bounds.extents.y + 0.1f)||
    //        Physics.Raycast(transform.position + transform.right * cc.bounds.extents.x, Vector3.down, cc.bounds.extents.y + 0.1f)||
    //        Physics.Raycast(transform.position - transform.right * cc.bounds.extents.x, Vector3.down, cc.bounds.extents.y + 0.1f))
    //    {
    //        isGround = true;
    //    }
    //    else
    //    {
    //        isGround = false;
    //    }
    //    //isGround = Physics.Raycast(transform.position, Vector3.down, capsulColl.bounds.extents.y + 0.1f);
    //}

    void External_Vec_Cal()
    {
        if (External_Direction.x > 0)
        {
            External_Direction.x -= GlobalValue.deltaTime;
            if (External_Direction.x <= 0)
                External_Direction.x = 0;
        }
        else if (External_Direction.x < 0)
        {
            External_Direction.x += GlobalValue.deltaTime;
            if (External_Direction.x >= 0)
                External_Direction.x = 0;
        }
        
        
        if (External_Direction.y >= 0)
        {
            External_Direction.y -= Gravity * GlobalValue.deltaTime;
            if (External_Direction.y <= 0)
                External_Direction.y = 0;
        }
        else if (External_Direction.y < 0)
        {
            External_Direction.y += GlobalValue.deltaTime;
            if (External_Direction.y <= 0)
                External_Direction.y = 0;
        }

        if (External_Direction.z >= 0)
        {
            External_Direction.z -= GlobalValue.deltaTime;
            if (External_Direction.z <= 0)
                External_Direction.z = 0;
        }
        else if (External_Direction.z < 0)
        {
            External_Direction.z += GlobalValue.deltaTime;
            if (External_Direction.z <= 0)
                External_Direction.z = 0;
        }

        External_Direction = transform.TransformDirection(External_Direction);
    }

    void Rotate()
    {
        x += Input.GetAxis("Mouse X") * GlobalValue.MouseXSpeed;
        this.transform.localRotation = Quaternion.Euler(0, x, 0);
    }

    void HangOnRope()
    {
        if (CurState == CharState.hang)
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Rope")
        {
            if (Input.GetKeyDown(KeyCode.F)) //줄에 닿았을 때 F를 누른다면
            {
                CurState = CharState.hang;
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "JumpPad")
        {
            External_Direction.y = 30;
        }
    }
}
