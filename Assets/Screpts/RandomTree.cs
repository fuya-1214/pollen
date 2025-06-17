using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class RandomCube : MonoBehaviour
{
    // 生成するプレハブ格納用
    [SerializeField] private GameObject[] Prefab;
    [SerializeField] private float a, b, c;

    // Start is called before the first frame update
    void Awake()
    {
        int tree = 0;

        for (int i = 0; i < 2; i++)
        {
            // プレハブの位置をランダムで設定
            float x = Random.Range(a, b);
            float z = Random.Range(a, c);
            Vector3 pos = new Vector3(x, 100.0001f, z);

            // プレハブを生成
            int number = Random.Range(0, Prefab.Length);
            Instantiate(Prefab[number], pos, Quaternion.identity);

            tree += i;
        }
    }

}