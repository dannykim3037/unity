using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class moru_animation : MonoBehaviour
{
    public Sprite[] moru_images; // 이미지 배열
    private int currentindex = 0; // 현재 이미지 인덱스
    private Image imageComponent; // 이미지 컴포넌트
    private Coroutine animationCoroutine; // 코루틴 저장

    void Start()
    {
        imageComponent = GetComponent<Image>();
      
    }
    private void Update()
    {
        StartAnimation();
    }

    public void StartAnimation()
    {
        if (moru_images.Length > 0 && imageComponent != null)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }
            animationCoroutine = StartCoroutine(SwitchImage());
        }
        else
        {
            Debug.LogError("Cannot start animation: moru_images array is empty or imageComponent is null!");
        }
    }

    private IEnumerator SwitchImage()
    {
        while (true)
        {
            imageComponent.sprite = moru_images[currentindex];
            Debug.Log($"Switched to image at index {currentindex}");
            currentindex = (currentindex + 1) % moru_images.Length; // 인덱스 증가 및 배열의 길이에 따라 순환
            yield return new WaitForSeconds(0.2f); // 0.1초 대기
        }
    }

    public void StopAnimation()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
            animationCoroutine = null;
        }
    }
}
