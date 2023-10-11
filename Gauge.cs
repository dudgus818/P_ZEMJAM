using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gauge : MonoBehaviour
{
    public Transform[] targetPositions; // ������ ��ġ���� ��� �迭
    public Transform FinishPosition;//������ġ
    public float speed = 5.0f; // �̵� �ӵ�

    private bool isMoving = true; // �̵� �� ����
    private int currentTargetIndex = 0; // ���� ��ǥ ��ġ �ε���

    private void Update()
    {
        if (isMoving)
        {
            // ��ǥ ��ġ�� �̵�
            transform.position = Vector3.MoveTowards(transform.position, targetPositions[currentTargetIndex].position, speed * Time.deltaTime);

            // ��ǥ�� �����ϸ� ���� ��ǥ�� �̵�
            if (Vector3.Distance(transform.position, targetPositions[currentTargetIndex].position) < 0.01f)
            {
                currentTargetIndex = (currentTargetIndex + 1) % targetPositions.Length;
            }
        }

        // �����̽��� �Է� Ȯ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Vector3.Distance(transform.position, FinishPosition.position) < 0.2f)
            {
                // ���� ó�� ���� �߰�
                Debug.Log("Success!");

                // ���� ������ �̵�
                SceneManager.LoadScene("Start");
            }
            else
            {
                // ���� ó�� ���� �߰�
                Debug.Log("Fail!");

                // ���� ������ �̵�
                SceneManager.LoadScene("Start");
            }
        }
    }
}
