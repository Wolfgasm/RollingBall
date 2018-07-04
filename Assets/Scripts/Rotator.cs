using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	void Update ()
    {
        // 旋轉函式 *Time.delta是為了不被幀率影響 代表一秒會轉15,30,45度
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
