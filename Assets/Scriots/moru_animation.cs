using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class moru_animation : MonoBehaviour
{
    public Sprite[] moru_images; // �̹��� �迭
    private int currentindex = 0; // ���� �̹��� �ε���
    private Image imageComponent; // �̹��� ������Ʈ
    private Coroutine animationCoroutine; // �ڷ�ƾ ����

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
            currentindex = (currentindex + 1) % moru_images.Length; // �ε��� ���� �� �迭�� ���̿� ���� ��ȯ
            yield return new WaitForSeconds(0.2f); // 0.1�� ���
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
