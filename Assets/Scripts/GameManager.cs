using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider _funOMeter;
    [SerializeField] private Image _funOMeterColor;
    [SerializeField] private float _maxFun;
    [SerializeField] private float _currentFun;
    [SerializeField] private float _previousFun;
    public List<Hitable> Enemies = new List<Hitable>();

    [SerializeField] private float _income;
    [SerializeField] private float _dummyIncomeValue;

    [SerializeField] private Text _multiplierUI;
    [SerializeField] private Text _incomeUI;
    [SerializeField] private Text _incomeChangeUI;

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
        _multiplierUI.enabled = false;
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
            
            _funOMeter.value = _currentFun;
            _dummyIncomeValue = _currentFun;
        }
        
        if (_dummyIncomeValue > (_maxFun * 0.7))
        {
            //activate ui element  x2
            _multiplier = 2f;
            _multiplierUI.enabled = true;
            _funOMeterColor.color = Color.yellow;
        }
        if (_dummyIncomeValue < (_maxFun * 0.7)&&_dummyIncomeValue>(_maxFun*0.2))
        {
            _multiplier = 1f;
            _multiplierUI.enabled = false;
            _funOMeterColor.color = Color.green;
        }
        _currentFun = 0;

        _incomeTimer += Time.deltaTime;

        if (_dummyIncomeValue < (_maxFun * 0.2))
        {
            _multiplier = -1;
            _funOMeterColor.color = Color.red;
        }
        if (_incomeTimer > _incomeTime)
        {
            _income += _dummyIncomeValue*_multiplier;
            _incomeTimer = 0f;
            if (_multiplier == -1)
            {
                _incomeUI.text = "$ " + ((int)_income).ToString();
                _incomeChangeUI.text =  ((int)(_dummyIncomeValue * _multiplier)).ToString();
            }
            if (_multiplier == 1)
            {
                _incomeUI.text = "$ " + ((int)_income).ToString();
                _incomeChangeUI.text = "+" + ((int)(_dummyIncomeValue * _multiplier)).ToString();
            }

        }
        
        
    }
}
