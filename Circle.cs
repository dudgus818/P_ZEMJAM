using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public Transform[] targetPositions; // 일정한 위치들을 담는 배열
    public float rotationSpeed = 2.0f; // 회전 속도
    public float radius = 5.0f; // 반원의 반지름
    public float moveSpeed = 2.0f; // 이동 속도
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform bulletSpawnPoint; // 총알 발사 지점

    private float angle = 0.0f; // 현재 각도
    private Vector3 centerPosition; // 원의 중심 위치
    private int currentTargetIndex = 0; // 현재 목표 위치 인덱스

    private void Start()
    {
        // 초기 중심 위치 설정
        centerPosition = transform.position + new Vector3(0, radius, 0);
    }

    private void Update()
    {
        // 각도 갱신
        angle += rotationSpeed * Time.deltaTime;

        // 현재 각도를 이용하여 위치 계산
        Vector3 newPosition = centerPosition + new Vector3(Mathf.Sin(angle) * radius, -Mathf.Cos(angle) * radius, 0);

        // 이동
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);

        // 목표에 도달하면 다음 목표로 이동
        if (Vector3.Distance(transform.position, targetPositions[currentTargetIndex].position) < 0.01f)
        {
            currentTargetIndex = (currentTargetIndex + 1) % targetPositions.Length;
        }

        // 스페이스바 입력 확인
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 총알 발사
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
