//using UnityEngine;
//using Unity.Jobs;
//using Unity.Collections;
//using Unity.Burst;
//using Unity.Mathematics;
//using System;

//namespace VL.Gaming.Unity.Gaming.Samples
//{
//    public class JobSystemExample : MonoBehaviour
//    {
//        [BurstCompile]
//        struct SquareJob : IJobParallelFor
//        {
//            public NativeArray<float> data;

//            public void Execute(int index)
//            {
//                data[index] = Math.Pow(data[index], 2);
//            }
//        }

//        void Start()
//        {
//            int arraySize = 1000000;
//            NativeArray<float> dataArray = new NativeArray<float>(arraySize, Allocator.TempJob);

//            // 初始化数组数据
//            for (int i = 0; i < arraySize; i++)
//            {
//                dataArray[i] = i;
//            }

//            // 创建 Job
//            SquareJob job = new SquareJob
//            {
//                data = dataArray
//            };

//            // Schedule the Job
//            JobHandle jobHandle = job.Schedule(arraySize, 64); // 64是分组大小，可以根据实际情况调整

//            // 等待 Job 完成
//            jobHandle.Complete();

//            // 释放 NativeArray
//            dataArray.Dispose();

//            Debug.Log("Job completed.");
//        }
//    }
//}
//
//使用介绍
//https://docs.unity3d.com/Packages/com.unity.burst@0.2/manual/index.html#cnet-language-support