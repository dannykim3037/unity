using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class minigame : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI scoretext_fail;
    public TextMeshProUGUI timetext;
    public TextMeshProUGUI game_money_txt;
    

    public static int score;
    public float time = 100.00f;

    public Image displayImage; // �̹����� ǥ���� UI Image ������Ʈ
    public Sprite[] imageArray; // 40���� �̹����� ������ �迭
    private int currentImageIndex;

    public GameObject Homebtn;
    public GameObject mini_game_page;
    public GameObject upgrade_button;
    public GameObject sell_button;
    public GameObject gameover;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
   

    public int heartcnt;
    public  static int game_moeny;
    bool game_running;

    // Start is called before the first frame update
   
    
    public void Minigame_start_()
    {
        GameStart();
    }
    public void GameStart()
    {
        game_moeny = 0;
        heartcnt = 3;
        gameover.SetActive(false);
        mini_game_page.SetActive(true);
        game_running = true;
        score = 0;
        time = 100.0f;
        // ������Ʈ �Ҵ�
        //scoretext = GameObject.Find("score").GetComponent<TextMeshProUGUI>();
        //scoretext_fail = GameObject.Find("gmae_over_page_score").GetComponent<TextMeshProUGUI>();
        //timetext = GameObject.Find("time").GetComponent<TextMeshProUGUI>();
        //displayImage = GameObject.Find("minigame_random").GetComponent<Image>(); // DisplayImage �̸��� �°� ����
       // game_money_txt = GameObject.Find("game_over_page_money").GetComponent<TextMeshProUGUI>();
        Debug.Log(heartcnt);
        // �ʱ� ������ �ð� ����
        scoretext.text = " Score: " + score;
        timetext.text = " Time: " + time.ToString("N2");

        

        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        // �ʱ� �̹��� ����
        SetRandomImage();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �ð��� �帣�� �ϱ�
        time -= Time.deltaTime; // �ð��� ���ҽ�Ŵ
        timetext.text = " Time: " + time.ToString("N2") + "��";

        if (game_running == true)
        {
            // �ð��� 0 ���Ϸ� �������� ���� ���� ó��
            if (time <= 0)
            {
                game_running = false;
                time = 0; // �ð��� ������ ���� �ʵ��� ����
                GameOver();
            }
        }
    }
   

    private void SetRandomImage()
    {
        currentImageIndex = Random.Range(0, imageArray.Length);
        displayImage.sprite = imageArray[currentImageIndex];
        Debug.Log("Current Image Index: " + currentImageIndex); // ���� �̹����� �ε����� �α׷� ���
    }

    public void Upgrade()
    {
        if (currentImageIndex >= 0 && currentImageIndex <= 23)
        {
            score += 1;
            scoretext.text = " Score: " + score;
        }
        else if (currentImageIndex >= 24 && currentImageIndex <= 40)
        {
            Minheart();
        }

        SetRandomImage(); // ���ο� ���� �̹��� ����
    }

    public void Sell()
    {
        if (currentImageIndex >= 24 && currentImageIndex <= 40)
        {
            score += 1;
            scoretext.text = " Score: " + score;
        }
        else if (currentImageIndex >= 0 && currentImageIndex <= 23)
        {
            Minheart();
        }

        SetRandomImage(); // ���ο� ���� �̹��� ����
    }

    void Minheart()
    {
        if (heartcnt == 3)
        {
            heart3.SetActive(false);
            heartcnt--;
        }
        else if (heartcnt == 2)
        {
            heart2.SetActive(false);
            heartcnt--;
        }
        else if (heartcnt == 1)
        {
            heart1.SetActive(false);
            GameOver();
        }
        else
        {
            return;
        }
    }
    void GameOver()
    {
        game_moeny = score * 2000;
        gameover.SetActive(true);
        mini_game_page.SetActive(false);
        scoretext_fail.text = " Score : " + score;
        game_money_txt.text = " Money : " + game_moeny;
    }
    
}
