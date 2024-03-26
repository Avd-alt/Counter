using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _startNumber = 0;
    private bool _isCounting = false;
    private Coroutine _coroutineCounter;

    public event Action Changed;

    public float CurrentNumber { get; private set; }

    private void Start()
    {
        CurrentNumber = _startNumber;

        if(_coroutineCounter != null)
        {
            StopCoroutine(_coroutineCounter);
        }

        _coroutineCounter = StartCoroutine(IncreaseNumber());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCounting = !_isCounting;
        }
    }

    private IEnumerator IncreaseNumber()
    {
        var delay = new WaitForSeconds(0.5f);

        while (true)
        {
            if (_isCounting)
            {
                CurrentNumber++;
                Changed?.Invoke();
            }

            yield return delay;
        }
    }
}