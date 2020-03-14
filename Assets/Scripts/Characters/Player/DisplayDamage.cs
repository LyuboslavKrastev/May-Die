using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] private Canvas _damageRecievedCanvas;
    [SerializeField] private float _imactTime = 0.5f;
    void Start()
    {
        _damageRecievedCanvas.enabled = false;
    }

    public void ShowDamageCanvas()
    {
        StartCoroutine(ShowSplatter());
    }

    private IEnumerator ShowSplatter()
    {
        _damageRecievedCanvas.enabled = true;
        yield return new WaitForSeconds(_imactTime);
        _damageRecievedCanvas.enabled = false;
    }
}
