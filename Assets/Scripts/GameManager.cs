using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider _funOMeter;
    [SerializeField] private float _maxFun;
    [SerializeField] private float _currentFun;
    [SerializeField] private float _previousFun;
    public List<Hitable> Enemies = new List<Hitable>();

    [SerializeField] private float _income;
    [SerializeField] private float _dummyIncomeValue;

    [SerializeField] private Text _multiplierUI;
    [SerializeField] private Text _incomeUI;
    [SerializeField] private int _incomeTime=5;
    [SerializeField] private float _incomeTimer=0f;
    private float _multiplier=2f;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Hitable enemy in Enemies)
        {
            _maxFun += enemy.MaxDrunkness;
        }
        foreach (Hitable enemy in Enemies)
        {
            _currentFun += enemy.DrunknessAmount;
            
        }
        _funOMeter.maxValue = _maxFun;
        _income = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _previousFun = _currentFun;
        
        foreach (Hitable enemy in Enemies)
        {
            _currentFun += enemy.DrunknessAmount;
        }
        _funOMeter.minValue = 0f;
        if (_previousFun != _currentFun)
        {
            //if (_currentFun > (_maxFun * 0.7))
            //{
            //    _income += _dummyIncomeValue;

            //    //activate ui element  x2
            //    _multiplierUI.enabled = true;
            //}
            
            _funOMeter.value = _currentFun;
            _dummyIncomeValue = _currentFun;
        }
        if (_dummyIncomeValue > (_maxFun * 0.7))
        {
            //activate ui element  x2
            _multiplier = 2f;
            _multiplierUI.enabled = true;
        }
        if (_dummyIncomeValue < (_maxFun * 0.7))
        {
            _multiplier = 1f;
            _multiplierUI.enabled = false;
        }
        _currentFun = 0;

        _incomeTimer += Time.deltaTime;
        if (_incomeTimer > _incomeTime)
        {
            _income += _dummyIncomeValue*_multiplier;
            _incomeTimer = 0f;
        }
        
        _incomeUI.text=_income.ToString();
    }
}
