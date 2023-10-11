using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text spacebarText;

    private float timer = 3f;
    private int spacebarPresses = 0;

    private void Update()
    {
        // 타이머를 업데이트하고 시간 초과 검사
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Debug.Log("시간 초과! 실패하셨습니다.");
            enabled = false; // 스크립트 비활성화
            return;
        }

        // 스페이스바 입력 검사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacebarPresses++;
            Debug.Log($"스페이스바 누름 ({spacebarPresses}/10)");

            if (spacebarPresses >= 10)
            {
                Debug.Log("성공! 스페이스바를 10번 누르셨습니다.");
                enabled = false; // 스크립트 비활성화
                SceneManager.LoadScene("Start");
            }
        }

        // UI 업데이트
        timerText.text = $"남은 시간: {timer:F2} 초";
        spacebarText.text = $"스페이스바 누른 횟수: {spacebarPresses} / 10";

    }
}
