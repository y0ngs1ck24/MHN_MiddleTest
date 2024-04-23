using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera Camera;
    public float rotationAngle = 90f;
    public float moveSpeed = 5.0f;
    

    public float positionIncrement = 90f;
    public float rotationIncrement = 90f;

    private Rigidbody rb;
    private int oKeyPressCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 플레이어가 움직이는 방향 벡터 계산
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (moveDirection != Vector3.zero)
        {
            // 플레이어의 회전을 조절하여 앞면이 향하도록 함
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            rb.MoveRotation(newRotation);
        }

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.O))
        {
            LeftRotateCamera(rotationAngle);

        }
        // P 키가 눌리면 오른쪽으로 회전
        else if (Input.GetKeyDown(KeyCode.P))
        {
            RightRotateCamera(-rotationAngle);
        }
    }

    void LeftRotateCamera(float angle)
    {
        oKeyPressCount++;

        Vector3 currentPosition = Camera.transform.position;
        Vector3 currentRotation = Camera.transform.eulerAngles;

        if (oKeyPressCount == 1)
        {
            currentPosition.z += rotationAngle;
            currentRotation.y += rotationIncrement;
        }
        else if(oKeyPressCount == 2)
        {
            currentPosition.x += rotationAngle;
            currentRotation.y += rotationIncrement;
        }
        else if (oKeyPressCount == 3)
        {
            currentPosition.z -= rotationAngle;
            currentRotation.y += 90f;
        }
        else if (oKeyPressCount == 4)
        {
            currentPosition.x -= rotationAngle;
            currentRotation.y += rotationIncrement;
            oKeyPressCount = 0;
        }
        Camera.transform.position = currentPosition;
        Camera.transform.eulerAngles = currentRotation;
    }
    void RightRotateCamera(float angle)
    {
        oKeyPressCount++;

        Vector3 currentPosition = Camera.transform.position;
        Vector3 currentRotation = Camera.transform.eulerAngles;

        if (oKeyPressCount == 1)
        {
            currentPosition.z -= rotationAngle;
            currentRotation.y -= rotationIncrement;
        }
        else if (oKeyPressCount == 2)
        {
            currentPosition.x -= rotationAngle;
            currentRotation.y -= rotationIncrement;
        }
        else if (oKeyPressCount == 3)
        {
            currentPosition.z += rotationAngle;
            currentRotation.y -= 90f;
        }
        else if (oKeyPressCount == 4)
        {
            currentPosition.x += rotationAngle;
            currentRotation.y -= rotationIncrement;
            oKeyPressCount = 0;
        }
        Camera.transform.position = currentPosition;
        Camera.transform.eulerAngles = currentRotation;
    }

}
