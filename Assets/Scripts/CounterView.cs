using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCount;
    [SerializeField] private Counter _counter;

    private float _startNumberView = 0;

    private void Start()
    {
        _textCount.text = _startNumberView.ToString();
    }

    private void OnEnable()
    {
        _counter.Changed += DisplayView;
    }

    private void OnDisable()
    {
        _counter.Changed -= DisplayView;
    }

    private void DisplayView()
    {
        float number = _counter.CurrentNumber;

        _textCount.text = number.ToString();
    }
}