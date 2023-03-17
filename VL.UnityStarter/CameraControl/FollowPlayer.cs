using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    // Vector3 offset = new Vector3(0,2.7f,2.2f); //第一人称
    Vector3 offset = new Vector3(0, 5, -7); //第三人称

    // Start is called before the first frame update
    void Start()
    {
        
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
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
    }
}
