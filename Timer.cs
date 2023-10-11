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
        // Ÿ�̸Ӹ� ������Ʈ�ϰ� �ð� �ʰ� �˻�
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Debug.Log("�ð� �ʰ�! �����ϼ̽��ϴ�.");
            enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
            return;
        }

        // �����̽��� �Է� �˻�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacebarPresses++;
            Debug.Log($"�����̽��� ���� ({spacebarPresses}/10)");

            if (spacebarPresses >= 10)
            {
                Debug.Log("����! �����̽��ٸ� 10�� �����̽��ϴ�.");
                enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
                SceneManager.LoadScene("Start");
            }
        }

        // UI ������Ʈ
        timerText.text = $"���� �ð�: {timer:F2} ��";
        spacebarText.text = $"�����̽��� ���� Ƚ��: {spacebarPresses} / 10";

    }
}
