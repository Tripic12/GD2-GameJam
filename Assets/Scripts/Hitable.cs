using UnityEngine;

public class Hitable : MonoBehaviour
{
    public float DrunknessAmount = 0f;
    [SerializeField] private float _drunknessTargetValue = 0f;
    [SerializeField] private float _maxDrunkness = 20f;
    [SerializeField] private float _getDrunkSpeed = 0.01f;

    [SerializeField] private float _waterFilledness = 0f;
    [SerializeField] private float _maxwaterFilledness = 20f;

    [SerializeField] private float _angerAmountAndTime = 0f;
    

    public bool IsAngry;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DrunknessAmount<_drunknessTargetValue)
        {
            DrunknessAmount += _getDrunkSpeed;
        }
        if (DrunknessAmount > _drunknessTargetValue)
        {
            DrunknessAmount -= _getDrunkSpeed;
        }


        if (IsAngry)
        {
            if (_angerAmountAndTime <= 0f)
            {
                _angerAmountAndTime = 0f;
                IsAngry = false;
            }
        }
    }
    public void GotHit(bool isWater,float bulletDamage)
    {
        if (isWater)
        {
            _drunknessTargetValue -= bulletDamage;
            _angerAmountAndTime +=bulletDamage;
            IsAngry = true;
            _waterFilledness += bulletDamage;
        }
        if (!isWater)
        {
            _drunknessTargetValue+= bulletDamage;
            
            _angerAmountAndTime-=bulletDamage/2f;
        }
    }
}
