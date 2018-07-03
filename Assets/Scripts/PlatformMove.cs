using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {

    // 旋轉的最大角度

    public float rotateDegree;

    // 計時變數

    private float changeTimer;

    
    void Start () {

        // 重製計時變數

        changeTimer = 0;
	}
	
	
	void Update () {

        // 此變數每秒+1 作為更換旋轉方向的計時

        changeTimer += Time.deltaTime;

        // 第一次1.5秒就更換方向 之後每三秒執行一次更換旋轉方向

        if (changeTimer >= 1.5f)
        {
            // 旋轉方向轉為另一邊

            rotateDegree *= -1;

            // 重製計時變數 不設為0而為-1.5 是為了讓平台有時間轉到對向 否則他將會回正後又轉向左邊

            changeTimer = -1.5f;
        }


        // 依照rotatedegree旋轉z軸

        this.transform.Rotate(new Vector3(0,0,rotateDegree) * Time.deltaTime);
	}
}
