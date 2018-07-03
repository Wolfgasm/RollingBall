using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {

    // 旋轉的最大角度
    public float rotateDegree;
    // 計時變數 
    private float changeTimer;

    // Use this for initialization
    void Start () {
        changeTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        // 此變數每秒+1
        changeTimer += Time.deltaTime;

        // 每六秒執行一次這裡
        if (changeTimer >= 1.5f)
        {
            rotateDegree *= -1;
            // 不設為0而為-3 是位了讓平台有時間轉到對向
            changeTimer = -1.5f;
        }


        // 依照rotatedegree旋轉z軸
        this.transform.Rotate(new Vector3(0,0,rotateDegree) * Time.deltaTime);
	}
}
