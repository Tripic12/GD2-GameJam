using UnityEngine;

public class Hitable : MonoBehaviour
{
    public float DrunknessAmount = 0f;
    [SerializeField] public float DrunknessTargetValue = 0f;
    [SerializeField] public float MaxDrunkness = 20f;
    [SerializeField] private float _getDrunkSpeed = 0.01f;

    [SerializeField] private float _waterFilledness = 0f;
    [SerializeField] private float _maxwaterFilledness = 20f;

    [SerializeField] public float AngerTime = 0f;
    
    public bool IsAngry;

    [SerializeField] private GameObject _puke;
    [SerializeField] private int _pukeDistance;

    [SerializeField] private GameManager _gameManagerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gameManager= GameObject.Find("GameManager");
        _gameManagerScript=gameManager.GetComponent<GameManager>();
        _gameManagerScript.Enemies.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        //DrunkLogic
        if (DrunknessAmount<DrunknessTargetValue)
        {
            DrunknessAmount += _getDrunkSpeed;
        }
        if (DrunknessAmount > DrunknessTargetValue)
        {
            DrunknessAmount -= _getDrunkSpeed;
        }
        if (DrunknessAmount > MaxDrunkness)
        {
            //Gameover
            Debug.Log("Gameover: someone OD'd on vodka");
        }
        if (DrunknessTargetValue < 0f)
        {
            DrunknessTargetValue = 0f;
        }


        //waterLogic
        _waterFilledness -= Time.deltaTime / 10f;

        if ((_waterFilledness > _maxwaterFilledness)&&(DrunknessAmount>0f))
        {
            //customer will puke
            Instantiate(_puke, transform.position +transform.forward* _pukeDistance, Quaternion.identity);
            _waterFilledness = 0;
        }
        if (_waterFilledness <= 0f)
        {
            _waterFilledness = 0f;
        }


        //AngerLogic
        if (AngerTime <= 0f)
        {
            AngerTime = 0f;
        }
        if (IsAngry)
        {
            AngerTime -= Time.deltaTime;
            if (AngerTime <= 0f)
            {
                AngerTime = 0f;
                IsAngry = false;
            }
        }
    }
    public void GotHit(bool isWater,float bulletDamage)
    {
        if (isWater)
        {
            DrunknessTargetValue -= bulletDamage/2.5f;
            AngerTime +=bulletDamage;
            IsAngry = true;
            _waterFilledness += bulletDamage;
        }
        if (!isWater)
        {
            DrunknessTargetValue+= bulletDamage;
            
            AngerTime-=bulletDamage/2f;
        }
    }
    public void HitByPuke()
    {
        IsAngry = true;
    }
}
