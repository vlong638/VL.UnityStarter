using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�༭ģʽ��Ч,����֧�ֱ༭ʱ�ýű����Ƴ���
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