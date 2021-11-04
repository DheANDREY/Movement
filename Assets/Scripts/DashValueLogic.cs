using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DashValueLogic : MonoBehaviour
{
    [Header("Dash")]
    [SerializeField] private int _maxDashCount = 2;
    [SerializeField] private float _dashFillTime = 3;
    private int _currentDashCount;
    public int CurrentDashCount
    {
        get => _currentDashCount;

        set
        {
            _currentDashCount = value;

            OnDashCountChanged?.Invoke(CurrentDashCount, _maxDashCount);
        }
    }
    public UnityAction<int, int> OnDashCountChanged;

    private float _dashFillTimer;
    public float DashFillTimer
    {
        get => _dashFillTimer;

        set
        {
            _dashFillTimer = value;

            OnDashFillTimerChanged?.Invoke(_dashFillTimer, _dashFillTime);
        }
    }
    public UnityAction<float, float> OnDashFillTimerChanged;

    // Start is called before the first frame update
    void Start()
    {
        CurrentDashCount = 0;
        DashFillTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FillDash();
    }

    private void FillDash()
    {
        if(CurrentDashCount >= _maxDashCount) { return; }

        DashFillTimer += Time.deltaTime;
        if(DashFillTimer >= _dashFillTime)
        {
            DashFillTimer = 0;
            CurrentDashCount++;
        }
    }
}
