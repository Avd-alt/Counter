using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;

    private float _startCount = 0;
    private float _currentCount;
    private bool counting = false;

    private void Start()
    {
        _countText.text = _startCount.ToString();
        _currentCount = _startCount;
        StartCoroutine(CountRoutine());
    }

    public void ToggleCounting()
    {
        counting = !counting;
    }

    private IEnumerator CountRoutine()
    {
        while (true)
        {
            if (counting)
            {
                _currentCount += 0.5f;
                _countText.text = _currentCount.ToString();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}