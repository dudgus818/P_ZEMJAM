using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class objectScale : MonoBehaviour
{
    private Transform objectTransform;
    private bool isScaling = false;
    private int spacebarCount = 0;

    public float scaleSpeed = 3f;
    public int maxScaleCount = 10;

    private void Start()
    {
        objectTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isScaling && spacebarCount < maxScaleCount)
        {
            StartCoroutine(ScaleObject());
        }
    }

    private IEnumerator ScaleObject()
    {
        isScaling = true;
        spacebarCount++;

        float targetYScale = objectTransform.localScale.y + 0.1f;
        float elapsedTime = 0f;

        while (elapsedTime < 1f / scaleSpeed)
        {
            float newYScale = Mathf.Lerp(objectTransform.localScale.y, targetYScale, elapsedTime * scaleSpeed);
            Vector3 newScale = new Vector3(objectTransform.localScale.x, newYScale, objectTransform.localScale.z);
            objectTransform.localScale = newScale;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectTransform.localScale = new Vector3(objectTransform.localScale.x, targetYScale, objectTransform.localScale.z);

        isScaling = false;

        if (spacebarCount >= maxScaleCount && targetYScale >= 1.0f)
        {
            SceneManager.LoadScene("Start"); 
        }
    }
}
