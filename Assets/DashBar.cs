using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    [SerializeField] private Slider _barPrefab;
    [SerializeField] private Transform _barRoot;
    [SerializeField] private DashValueLogic _dashLogic;

    private List<Slider> _spawnedBars;
    private int _currentDashCount;
    private float _currentDashFillTimer;

    private void Awake()
    {
        _spawnedBars = new List<Slider>();

        _dashLogic.OnDashCountChanged += OnDashCountChanged;
        _dashLogic.OnDashFillTimerChanged += OnDashFillTimerChanged;
    }

    private void OnDashCountChanged(int count, int max)
    {
        if(max > _spawnedBars.Count)
        {
            for(int i = 0; i <= max - _spawnedBars.Count; i++)
            {
                SpawnBar();
            }
        }

        _currentDashCount = count;
        for(int i = 0; i < _spawnedBars.Count; i++)
        {
            _spawnedBars[i].value = i < _currentDashCount ? 1 : 0f;
        }
    }

    private void OnDashFillTimerChanged(float value, float max)
    {
        _spawnedBars[_currentDashCount].value = value / max;
    }

    public void SpawnBar()
    {
        Slider bar = Instantiate(_barPrefab.gameObject, _barRoot).GetComponent<Slider>();
        bar.gameObject.SetActive(true);
        _spawnedBars.Add(bar);
    }
}
