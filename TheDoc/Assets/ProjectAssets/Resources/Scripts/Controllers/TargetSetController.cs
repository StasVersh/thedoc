using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TargetSetController : MonoBehaviour
{
    private void Start()
    {
        GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindWithTag("Player").transform;
        GetComponent<CinemachineVirtualCamera>().LookAt = GameObject.FindWithTag("Player").transform;
    }
}
