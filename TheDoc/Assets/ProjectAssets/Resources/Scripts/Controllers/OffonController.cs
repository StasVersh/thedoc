using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventHandler = ProjectAssets.Resources.Doc.Scripts.Utilitys.EventHandler;

public class OffonController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("On");
        EventHandler.LocationExit.AddListener(() => _animator.Play("Off"));
        EventHandler.ThromsDeth.AddListener(() => _animator.Play("Off"));
        EventHandler.Spawn.AddListener(() => _animator.Play("On"));
    }
}
