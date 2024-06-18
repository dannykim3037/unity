using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class image : MonoBehaviour
{
    // 돈 함수
    public int[] UpgradeGold; // 업그레이드 비용 
    public int[] Sell; // 판매 비용
    public TextMeshProUGUI UpgradeGoldText;
    public TextMeshProUGUI SellText;
    public TextMeshProUGUI Upgradeanimtext;
    

    // 게임 이미지 
    public TextMeshProUGUI nameText; // 이름을 표시할 TextMeshProUGUI
    public TextMeshProUGUI percentageText; // 백분율을 표시할 TextMeshProUGUI
    public Sprite[] images; // 장갑 이미지 배열
    public GameObject images_;
    public string[] names; // 장갑 이름 배열
    public string[] percentages; // 확률 배열 

    public GameObject imgName;
    public GameObject per;
    public GameObject failpage;
    public GameObject dogam;
    public GameObject dogam_buttom;
    public GameObject dogam_page1;
    public GameObject dogam_page2;
    public GameObject dogam_page3;
    public GameObject dogam__page1_right_arrow;
    public GameObject dogam_page1_left_arrow;
    public GameObject dogam__page2_right_arrow;
    public GameObject dogam_page2_left_arrow;
    public GameObject dogam__page3_right_arrow;
    public GameObject dogam_page3_left_arrow;
    public GameObject start_page;
    public GameObject maincanvas;
    public GameObject start_page_canvas;
    private int currentIndex = 0; // 현재 이미지의 인덱스 위치
    private Image imageComponent;
    public GameObject go;
    public GameObject moru;
    public GameObject upgrade_button;
    public GameObject sell_button;
 
    //public GameObject sub_canvas;
    
   
    public Sprite[] moru_images; // 이미지 배열
    private int currentMoruIndex = 0; // 현재 moru 이미지 인덱스
    private Image moruImageComponent; // moru의 이미지 컴포넌트
    private Coroutine animationCoroutine; // 코루틴 저장

    private Coroutine upgradeAnimationCoroutine;

    void Start()
    {
        imageComponent = GetComponent<Image>(); // 현재 게임 오브젝트의 Image 컴포넌트를 가져옴
        moruImageComponent = moru.GetComponent<Image>(); // moru 게임 오브젝트의 Image 컴포넌트를 가져옴
        UpdateImageAndText(); // 첫 번째 이미지와 텍스트로 설정
        maincanvas.SetActive(false);
        go.SetActive(false);
        failpage.SetActive(false);
        dogam.SetActive(false);
        start_page.SetActive(true);
        start_page_canvas.SetActive(true);
       
    }
   
   
    public void StartAnimation()
    {
        Debug.Log("StartAnimation called");
        Debug.Log($"moru_images length: {moru_images.Length}");
        Debug.Log($"moruImageComponent is null: {moruImageComponent == null}");

        if (moru_images.Length > 0 && moruImageComponent != null)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }
            moru.SetActive(true); // moru 오브젝트 활성화
            animationCoroutine = StartCoroutine(SwitchImage());
            StartCoroutine(DeactivateMoruAfterDelay(2f)); // 2초 후에 moru 오브젝트 비활성화
        }
        else
        {
            Debug.LogError("Cannot start animation: moru_images array is empty or moruImageComponent is null!");
        }
    }

    private IEnumerator SwitchImage()
    {
        while (true)
        {
            moruImageComponent.sprite = moru_images[currentMoruIndex];
            Debug.Log($"Switched to image at index {currentMoruIndex}");
            currentMoruIndex = (currentMoruIndex + 1) % moru_images.Length; // 인덱스 증가 및 배열의 길이에 따라 순환
            yield return new WaitForSeconds(0.1f); // 0.1초 대기
        }
    }

    private IEnumerator DeactivateMoruAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        moru.SetActive(false); // moru 오브젝트 비활성화
        StopAnimation(); // 애니메이션 코루틴 중지
    }

    public void StopAnimation()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
            animationCoroutine = null;
        }
    }
    //-------------
    public void Minigame()
    {
        maincanvas.SetActive(false);
    }
    public void End_minigame()
    {
        maincanvas.SetActive(true);
    }
    public void Start_page()
    {
        start_page.SetActive(false);
        start_page_canvas.SetActive(false);
        maincanvas.SetActive(true);
    }

    public void Dogam_page1_right_arrow()
    {
        dogam_page1.SetActive(false);
        dogam_page2.SetActive(true);
    }
    public void Dogam_page1_left_arrow()
    {
        dogam_page1.SetActive(false);
        dogam_page3.SetActive(true);
    }
    public void Dogam_page2_right_arrow()
    {
        dogam_page2.SetActive(false);
        dogam_page3.SetActive(true);
    }
    public void Dogam_page2_left_arrow()
    {
        dogam_page2.SetActive(false);
        dogam_page1.SetActive(true);
    }
    public void Dogam_page3_left_arrow()
    {
        dogam_page3.SetActive(false);
        dogam_page2.SetActive(true);
    }
    public void Dogam_page3_right_arrow()
    {
        dogam_page3.SetActive(false);
        dogam_page1.SetActive(true);
    }

    public void Dogam_home()
    {
        //sub_canvas.SetActive(false);
        dogam.SetActive(false);
        maincanvas.SetActive(true);
    }
    public void FailPageRegame()
    {
       // sub_canvas.SetActive(false);
        failpage.SetActive(false);
        maincanvas.SetActive(true);
    }
    public void Dogam_button()
    {
        maincanvas.SetActive(false);
        dogam_page1.SetActive(true);
        dogam_page2.SetActive(false);
        dogam_page3.SetActive(false);
        dogam.SetActive(true);
        failpage.SetActive(false);
        //sub_canvas.SetActive(true);
    }

    // 이미지, 이름, 백분율을 변경하는 메소드
    public void ChangeToNextImage()
    {
        if (upgradeAnimationCoroutine != null)
        {
            StopCoroutine(upgradeAnimationCoroutine);
        }
        upgradeAnimationCoroutine = StartCoroutine(ChangeToNextImageWithDelay());
    }
    public void Upgradebtn_Onclick()
    {
        ChangeToNextImage();
        StartAnimation();
      
    }
    private IEnumerator ChangeToNextImageWithDelay()
    {
        // 게임 오브젝트를 활성화
        go.SetActive(true);
        upgrade_button.SetActive(false);
        sell_button.SetActive(false);

        imageComponent.color = Color.clear;
        imgName.SetActive(false);
        per.SetActive(false);

        // 업그레이드 애니메이션 시작
        Coroutine upgradeAnim = StartCoroutine(UpgradeAnimation());

        // 2초 딜레이 추가
        yield return new WaitForSeconds(2f);

        // 업그레이드 애니메이션 종료
        StopCoroutine(upgradeAnim);
        
        
        Upgradeanimtext.text = "";

        imageComponent.color = Color.white;
        upgrade_button.SetActive(true);
        sell_button.SetActive(true);
        imgName.SetActive(true);
        per.SetActive(true);

        // 게임 오브젝트를 비활성화
        go.SetActive(false);

        if (TryEnhanceSuccess()) // 강화 시도가 성공했을 경우
        {
            // 현재 인덱스에 해당하는 업그레이드 비용 가져오기
            int upgradeCost = UpgradeGold[currentIndex];

            // GameManager의 인스턴스를 사용하여 돈 차감 시도
            bool isDeducted = GameManager.instance.DeductGold(upgradeCost);

            if (isDeducted) // 돈 차감에 성공했다면
            {
                // 다음 인덱스로 이동
                currentIndex = (currentIndex + 1) % images.Length;
                Debug.Log("강화 성공 및 금액 차감");
            }
            else // 돈이 부족하다면
            {
                Debug.Log("돈이 부족합니다.");
                // 추가적인 처리를 할 수 있습니다. 예를 들어, 사용자에게 돈이 부족하다는 메시지를 보여줄 수 있습니다.
            }
        }
        else
        {
            maincanvas.SetActive(false);
            //sub_canvas.SetActive(true);
            failpage.SetActive(true);
            dogam.SetActive(false);
            // 강화 실패

            currentIndex = 0; // 실패하면 처음으로 돌아감
            Debug.Log("강화 실패");
        }
        UpdateImageAndText(); // 이미지와 텍스트 업데이트
    }

    private IEnumerator UpgradeAnimation()
    {
        int dotCount = 0;
        while (true)
        {
            Upgradeanimtext.text = "강화중" + new string('.', dotCount);
            dotCount = (dotCount + 1) % 4; // 0, 1, 2, 3 반복 (4번째는 다시 0)
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void ChangeToNextImageSell()
    {
        if (Trysell()) // 판매 시도 했을 경우
        {
            // 현재 인덱스에 해당하는 판매 비용 가져오기
            int sellCost = Sell[currentIndex];

            // GameManager의 인스턴스를 사용하여 판매 시도
            bool isSold = GameManager.instance.AddGold(sellCost); // 예를 들어, GameManager에 판매로 인한 골드 추가를 처리하는 메소드를 호출합니다.

            if (isSold) // 판매에 성공했다면
            {
                currentIndex = 0; // 현재 인덱스를 초기화
                Debug.Log("판매 성공 및 금액 추가");
            }
            else // 판매에 실패했다면
            {
                Debug.Log("판매 실패");
                // 추가적인 처리를 할 수 있습니다. 예를 들어, 판매 실패에 대한 메시지를 보여줄 수 있습니다.
            }
            UpdateImageAndText(); // 이미지와 텍스트 업데이트
        }
    }

    private bool Trysell()
    {
        // 판매에 대한 추가적인 처리를 할 수 있습니다.
        return true; // 예시로 항상 판매 성공으로 가정하고 true를 반환합니다.
    }

    // 강화 성공 여부를 결정하는 메소드
    private bool TryEnhanceSuccess()
    {
        // percentages 배열
        string percentageString = percentages[currentIndex].Replace("강화확률 :", "").Replace("%", "").Trim();

        int successChance;
        bool parseResult = int.TryParse(percentageString, out successChance);
        if (!parseResult)
        {
            Debug.LogError($"'percentages' 배열의 형식이 잘못되었습니다: {percentages[currentIndex]}");
            return false;
        }

        // 성공 확률 랜덤 수
        int randomChance = Random.Range(0, 101);
        // 무작위 수를 통한 성공 확률 로그
        Debug.Log($"무작위 수 : {randomChance}, 필요한 성공 확률: {successChance}");

        return randomChance <= successChance;
    }

    private void UpdateImageAndText()
    {
        if (images.Length > 0 && currentIndex < images.Length)
        {
            SellText.text = " 판매비용 : " + Sell[currentIndex];
            UpgradeGoldText.text = " 강화비용 : " + UpgradeGold[currentIndex];
            imageComponent.sprite = images[currentIndex]; // 이미지 변경
            nameText.text = names[currentIndex]; // 이름 변경
            percentageText.text = percentages[currentIndex]; // 백분율 변경
            Debug.Log($"현재 이미지: {images[currentIndex].name}, 이름: {names[currentIndex]}, 확률: {percentages[currentIndex]}");
        } 
    }
}
