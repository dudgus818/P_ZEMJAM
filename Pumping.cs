using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumping : MonoBehaviour
{
    private Transform uiRectTransform;
    private bool isScaling = false;

    public float scaleSpeed = 50f;
    public float minScale = 0.7f;
    public float maxScale = 1.5f;

    private void Start()
    {
        uiRectTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isScaling)
        {
            StartCoroutine(ScaleUI());
        }
    }

    private IEnumerator ScaleUI()
    {
        isScaling = true;

        // 줄어들기
        Vector3 targetScale = new Vector3(1f, minScale, 1f);
        Vector3 initialScale = uiRectTransform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < 1f / scaleSpeed)
        {
            uiRectTransform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime * scaleSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        uiRectTransform.localScale = targetScale;

        // 잠시 대기
        yield return new WaitForSeconds(0.1f);

        // 늘어나기
        targetScale = new Vector3(1f, maxScale, 1f);
        elapsedTime = 0f;
        initialScale = uiRectTransform.localScale;

        while (elapsedTime < 1f / scaleSpeed)
        {
            uiRectTransform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime * scaleSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        uiRectTransform.localScale = targetScale;

        isScaling = false;
    }
}
