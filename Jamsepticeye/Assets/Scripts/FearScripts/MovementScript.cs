using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Speed")]
    public float walkSpeed = 5f;
    public float runSpeed = 8f;

    public Animator animator;
    private Rigidbody rb;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        // ��������� ��������
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        moveInput = new Vector3(moveX, 0f, moveZ).normalized;

        // ���������� ��������� � ���������
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        currentSpeed = isRunning ? runSpeed : walkSpeed;

        // ���������� ���������
        float moveMagnitude = moveInput.magnitude;
        bool isMoving = moveMagnitude > 0.1f;

        animator.SetBool("isRunning", isRunning && isMoving);
        animator.SetBool("isWalking", !isRunning && isMoving);
        animator.SetFloat("speed", moveMagnitude); // ����� ������������ ��� ������� ���������

        // ����� �� ���
        if (Input.GetMouseButtonDown(0)) // ������ ������ ����
        {
            animator.SetTrigger("Attack");
        }
    }

    void FixedUpdate()
    {
        Vector3 moveVelocity = moveInput * currentSpeed;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}

// � ��� ���� �������� ������� \ ����� \��� ��� �������� ����������: � ���� 4 ���������: ������ �� �����, ������ ������ ���� - �����, ��� ����� ���� � ������