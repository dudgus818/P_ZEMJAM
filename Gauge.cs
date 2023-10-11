using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gauge : MonoBehaviour
{
    public Transform[] targetPositions; // 일정한 위치들을 담는 배열
    public Transform FinishPosition;//성공위치
    public float speed = 5.0f; // 이동 속도

    private bool isMoving = true; // 이동 중 여부
    private int currentTargetIndex = 0; // 현재 목표 위치 인덱스

    private void Update()
    {
        if (isMoving)
        {
            // 목표 위치로 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPositions[currentTargetIndex].position, speed * Time.deltaTime);

            // 목표에 도달하면 다음 목표로 이동
            if (Vector3.Distance(transform.position, targetPositions[currentTargetIndex].position) < 0.01f)
            {
                currentTargetIndex = (currentTargetIndex + 1) % targetPositions.Length;
            }
        }

        // 스페이스바 입력 확인
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Vector3.Distance(transform.position, FinishPosition.position) < 0.2f)
            {
                // 성공 처리 로직 추가
                Debug.Log("Success!");

                // 다음 씬으로 이동
                SceneManager.LoadScene("Start");
            }
            else
            {
                // 실패 처리 로직 추가
                Debug.Log("Fail!");

                // 다음 씬으로 이동
                SceneManager.LoadScene("Start");
            }
        }
    }
}
