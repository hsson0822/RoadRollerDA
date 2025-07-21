using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.GraphicsBuffer;

public class RoadRoller : MonoBehaviour
{
    public float speed = 30f;
    public float rotationSpeed = 5f;

    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    private Vector3 moveDirection;
    private Vector3 defaultForward;

    private void Start()
    {
        defaultForward = transform.forward;
        speed = 30f;
        rotationSpeed = 5f;
    }

    public void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //Vector3 velocity = Vector3.right * variableJoystick.Horizontal;
        //Vector3 velocity = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        //Vector3 direction = velocity;

        //velocity *= speed;
        //rb.linearVelocity = velocity;

        //transform.rotation = Quaternion.LookRotation(direction * 90f);

        float horizontal = variableJoystick.Horizontal;
        float vertical = variableJoystick.Vertical;

        Vector3 inputDir = new Vector3(horizontal, 0f, vertical).normalized;

        if (inputDir.magnitude > 0.1f)
        {
            // 입력 방향을 회전 제한 범위 내로 조정
            float angle = Vector3.SignedAngle(defaultForward, inputDir, Vector3.up);
            if (angle > 30f) inputDir = Quaternion.AngleAxis(30f, Vector3.up) * defaultForward;
            else if (angle < -30f) inputDir = Quaternion.AngleAxis(-30f, Vector3.up) * defaultForward;

            // 이동
            Vector3 move = inputDir * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);

            // 회전
            Quaternion targetRotation = Quaternion.LookRotation(inputDir, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
        }
        else
        {
            // 조이스틱 입력이 없으면 정지
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            Quaternion targetRotation = Quaternion.LookRotation(defaultForward, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * 0.6f * Time.fixedDeltaTime));
        }

    }
}
