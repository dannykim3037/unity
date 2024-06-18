using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class startinages : MonoBehaviour
{
    public Image imageComponent;
    public Sprite[] imageArray;  // 이미지 배열
    public TextMeshProUGUI textComponent; // TextMeshPro 텍스트 컴포넌트 참조
    private int currentIndex = 0;

    void Start()
    {
     
        // 이미지 변경을 시작
        StartCoroutine(ChangeImageRoutine());

        // 텍스트 깜빡임을 시작
        StartCoroutine(BlinkTextRoutine());
    }

    IEnumerator ChangeImageRoutine()
    {
        while (true)
        {
            // 이미지 컴포넌트의 스프라이트를 현재 인덱스의 이미지로 변경
            imageComponent.sprite = imageArray[currentIndex];

            // 인덱스를 다음으로 증가, 배열의 끝에 도달하면 처음으로 돌아감
            currentIndex = (currentIndex + 1) % imageArray.Length;

            // 3초 대기
            yield return new WaitForSeconds(0.9f);
        }
    }

    IEnumerator BlinkTextRoutine()
    {
        while (true)
        {
            // 텍스트의 활성화 상태를 토글
            textComponent.enabled = !textComponent.enabled;

            // 2초 대기
            yield return new WaitForSeconds(0.4f);
        }
    }
}
