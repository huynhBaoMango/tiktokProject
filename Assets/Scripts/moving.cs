using UnityEngine;

public class moving : MonoBehaviour
{
    public float moveSpeed = 10f; // Tốc độ di chuyển
    public float moveDistanceForward = 137f; // Khoảng cách di chuyển về phía trước
    public float moveDistanceBackward = 165.2f; // Khoảng cách di chuyển về phía sau
    public GameManager manager;
    private Rigidbody rb;

    private Vector3 targetPosition;
    private bool isMovingForward = true;
    private float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Lấy Rigidbody của đối tượng
        MoveForward();
    }

    void MoveForward()
    {
        targetPosition = new Vector3(transform.position.x, transform.position.y, moveDistanceForward);
        startTime = Time.time;
        isMovingForward = true;
    }

    void MoveBack()
    {
        targetPosition = new Vector3(transform.position.x, transform.position.y, moveDistanceBackward);
        startTime = Time.time;
        isMovingForward = false;
    }

    void FixedUpdate()
    {
        // Tính toán khoảng cách di chuyển mỗi frame
        float step = moveSpeed * Time.deltaTime;

        // Di chuyển đối tượng đến mục tiêu một cách mượt mà
        rb.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, step));

        // Kiểm tra nếu đối tượng đã đạt đến mục tiêu
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Đổi hướng di chuyển sau 1.5 giây
            Invoke(isMovingForward ? "MoveBack" : "MoveForward", 1.5f);
        }
    }
}
