using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 minPosition; // X와 Y의 최소 좌표 값
    public Vector2 maxPosition; // X와 Y의 최대 좌표 값
    public float moveSpeed = 5.0f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        // 좌표 제한 코드
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);

        transform.position = newPosition;
    }
}
