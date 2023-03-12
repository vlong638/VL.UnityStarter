using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//编辑模式生效,可以支持编辑时用脚本控制场景
[ExecuteInEditMode]
public class InitScene : MonoBehaviour
{
    public GameObject cubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Instantiate Start");
        for (int i = 1; i < 10; i++)
        {
            var c = Instantiate(cubePrefab, new Vector3(i, i, i), Quaternion.identity);
            Debug.Log($"Instantiate{i}");
        }
        Debug.Log($"Instantiate End");
    }

    // Update is called once per frame
    void Update()
    {

    }
}