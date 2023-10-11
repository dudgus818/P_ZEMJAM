using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public Transform[] targetPositions; // ������ ��ġ���� ��� �迭
    public float rotationSpeed = 2.0f; // ȸ�� �ӵ�
    public float radius = 5.0f; // �ݿ��� ������
    public float moveSpeed = 2.0f; // �̵� �ӵ�
    public GameObject bulletPrefab; // �Ѿ� ������
    public Transform bulletSpawnPoint; // �Ѿ� �߻� ����

    private float angle = 0.0f; // ���� ����
    private Vector3 centerPosition; // ���� �߽� ��ġ
    private int currentTargetIndex = 0; // ���� ��ǥ ��ġ �ε���

    private void Start()
    {
        // �ʱ� �߽� ��ġ ����
        centerPosition = transform.position + new Vector3(0, radius, 0);
    }

    private void Update()
    {
        // ���� ����
        angle += rotationSpeed * Time.deltaTime;

        // ���� ������ �̿��Ͽ� ��ġ ���
        Vector3 newPosition = centerPosition + new Vector3(Mathf.Sin(angle) * radius, -Mathf.Cos(angle) * radius, 0);

        // �̵�
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);

        // ��ǥ�� �����ϸ� ���� ��ǥ�� �̵�
        if (Vector3.Distance(transform.position, targetPositions[currentTargetIndex].position) < 0.01f)
        {
            currentTargetIndex = (currentTargetIndex + 1) % targetPositions.Length;
        }

        // �����̽��� �Է� Ȯ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �Ѿ� �߻�
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
