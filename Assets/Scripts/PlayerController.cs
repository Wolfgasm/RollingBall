using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 記得要引用UI的參考

public class PlayerController : MonoBehaviour {

    // 宣告一個沒有存東西的Rigidbody變數

    private Rigidbody playerRigidbody;

    // 移動速度

    public float moveSpeed;

    // 存放分數

    private int collectCount;

    // 存放經過時間

    private float finishTime;

    // 設定要贏要吃到多少個物件

    public int winCondition;

    // 宣告一個記分板UI 注意他不是string而是UI 所以在取得他的文字時要+.text 然後一樣要去inspector拉入UI元件

    public Text scoreText;

    // 宣告一個"你贏了"的UI

    public Text winText;

    // 宣告計時器UI

    public Text timerText;

    // 宣告遊戲是否結束的布林

    private bool endGame;

    // 宣告存放爆炸擊退方向的vector3變數

    public Vector3 blowDir = new Vector3();


    void Start()
    {

        // 取得此物件的Rigidbody元件

        playerRigidbody = GetComponent<Rigidbody>();

        // 初始化分數

        collectCount = 0;

        // 初始化勝利訊息顯示

        winText.enabled = false;

        // 初始化UI文字

        SetCountText();

        // 初始化計時器及計時器UI的文字

        finishTime = 0;
        timerText.text = "";

        // 初始化遊戲破關狀態 剛開始應該為false
        endGame = false;
    }


    void Update()
    {
        // 如果還未破關 持續計時

        if(endGame == false) finishTime += Time.deltaTime;
        
        // 顯示目前秒數

        timerText.text = finishTime.ToString("000.00");
    }
    

    void FixedUpdate()
    {
        // GetAxis函數會依照設定的輸入按鍵回傳-1 0 1
        // 設定在 Edit > project setting > Input 裡

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // 將上面兩個變數指定到一個vector3變數

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Addforce會依照vetor3對指定物體的rigidbody施加力量 

        playerRigidbody.AddForce(movement * moveSpeed);



    }

    // ---跟物件碰撞

    void OnTriggerEnter(Collider other)
    {
        // 跟加分物件碰撞

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            collectCount += 1;

            // 更新記分板UI文字

            SetCountText();
        }

        // 跟爆炸物件碰撞

        if (other.CompareTag("Bomb"))
        {
            // 計算玩家與爆炸物的向量位置 做為被擊退方向 

            blowDir = this.transform.position - other.transform.position;
           
            
            // 利用addforce做擊退

            playerRigidbody.AddForce(blowDir * 1500);
            playerRigidbody.AddForce(new Vector3(0,800,0));

            // 關閉碰到的炸彈避免二次碰撞
            other.gameObject.SetActive(false);
        }
    }


    // 更新記分板的自訂方法

    void SetCountText()
    {
        // 顯示分數

        scoreText.text = "Score:" + collectCount.ToString();

        // 如果收集夠多的方塊 遊戲結束

        if (collectCount >= winCondition)
        {
            // 顯示勝利訊息

            winText.text = "You Win!" + "\n" + "所花時間:" + finishTime.ToString("000.00") + "秒"; 
            winText.enabled = true;

            // 遊戲結束

            endGame = true;
        }
    }
}
