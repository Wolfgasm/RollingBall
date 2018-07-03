using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // 要存放玩家物件的變數 記得寫完要去Inspector拉入玩家物件

    public GameObject player;

    // 存放玩家跟攝影機的初始距離

    private Vector3 offset;




	// Use this for initialization

	void Start () {

        // 在一開始取得攝影機與玩家物體的距離

        offset = transform.position - player.transform.position;


	}
	
	// 使用LateUpdate是為了確保攝影機在玩家移動的那一幀跟著移動 不然如果跟其他運算一起使用update 可能造成玩家移動比攝影機更新還要慢一點點 變成下一幀才會偵測到玩家的移動

	void LateUpdate () {

        // 每一幀將攝影機的位置移動到玩家物體的位置

        transform.position = player.transform.position + offset; // offset變數在這裡很重要 如果不加上他 攝影機會黏在玩家上
    }
}
