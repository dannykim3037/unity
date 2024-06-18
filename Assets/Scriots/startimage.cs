using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class startinages : MonoBehaviour
{
    public Image imageComponent;
    public Sprite[] imageArray;  // �̹��� �迭
    public TextMeshProUGUI textComponent; // TextMeshPro �ؽ�Ʈ ������Ʈ ����
    private int currentIndex = 0;

    void Start()
    {
     
        // �̹��� ������ ����
        StartCoroutine(ChangeImageRoutine());

        // �ؽ�Ʈ �������� ����
        StartCoroutine(BlinkTextRoutine());
    }

    IEnumerator ChangeImageRoutine()
    {
        while (true)
        {
            // �̹��� ������Ʈ�� ��������Ʈ�� ���� �ε����� �̹����� ����
            imageComponent.sprite = imageArray[currentIndex];

            // �ε����� �������� ����, �迭�� ���� �����ϸ� ó������ ���ư�
            currentIndex = (currentIndex + 1) % imageArray.Length;

            // 3�� ���
            yield return new WaitForSeconds(0.9f);
        }
    }

    IEnumerator BlinkTextRoutine()
    {
        while (true)
        {
            // �ؽ�Ʈ�� Ȱ��ȭ ���¸� ���
            textComponent.enabled = !textComponent.enabled;

            // 2�� ���
            yield return new WaitForSeconds(0.4f);
        }
    }
}
