using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Gold;
    public GameObject txt;
    public static GameManager instance;
    public GameObject maincanvas;
    public GameObject minigame_start_page;
    public GameObject minigame_end_page;
    public GameObject main_canvas;
    public int currentGold = 1000000; // 초기 자금 1백만원
    public float time = 0f;
    

    private void Start()
    {
        minigame_start_page.SetActive(false);
        minigame_end_page.SetActive(false);

    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateGoldUI();
    }

    // 자금 차감 메소드
    public bool DeductGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            UpdateGoldUI(); // UI 업데이트
            return true; // 성공적으로 차감
        }
        else
        {
            return false; // 자금이 부족함
        }
    }

    // 판매 메소드
    public bool AddGold(int sellcost)
    {
        currentGold += sellcost;
        UpdateGoldUI();
        return true;
    }

    // Gold Text UI 업데이트 메소드
    public void UpdateGoldUI()
    {
        Gold.text = " Gold : " + currentGold;
    }
    public void Minigame_start_page()
    {
        maincanvas.SetActive(false);
        minigame_start_page.SetActive(true);
       

    }
    public void Minigame_start()
    {
        minigame_start_page.SetActive(false);
    }
    private void Update()
    {
        time += Time.deltaTime;
    }

    public void minigame_home_btn()
    {
        minigame_end_page.SetActive(false);
        currentGold += minigame.game_moeny;
        maincanvas.SetActive(true);
        UpdateGoldUI();
    }
}
