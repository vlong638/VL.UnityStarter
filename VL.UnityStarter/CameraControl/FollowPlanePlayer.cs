using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3 offset; 
    Vector3 startForward;

    // Start is called before the first frame update
    void Start()
    {
        startForward = player.transform.forward;//初始方向
        offset =new Vector3(0, 15, -50);//第三人称
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        //旋转跟随相机(斜时会偏移)
        // 使用FromToRotation进行变换
        var rotation = Quaternion.FromToRotation(startForward, player.transform.forward).normalized;
        var transformedOffset = rotation * offset;
        transform.position = player.transform.position + transformedOffset;
        transform.rotation = player.transform.rotation;

    }
}
