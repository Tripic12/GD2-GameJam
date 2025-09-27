using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    private float _lerpTimer;
    private float _duration = 5;
    private float _timerOD;
    private float _frequencyOD = 0.15f;

    private MeshRenderer _meshRenderer;
    private Color _characterColor;

    private Hitable _hitable;
    //Statuses
    private bool _isSober;
    private bool _isTipsy;
    private bool _isDrunk;
    private bool _isOD;

    //Status materials
    [SerializeField]
    private Color _sober = Color.white;
    [SerializeField]
    private Color _drunk = Color.green;
    [SerializeField]
    private Color _od = Color.red;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _hitable = GetComponent<Hitable>();
        _characterColor = _meshRenderer.material.color;

    }

    // Update is called once per frame
    void Update()
    {

        _lerpTimer = _hitable.DrunknessAmount / _hitable.MaxDrunkness;
        _meshRenderer.material.color = Color.Lerp(_sober, _drunk, _lerpTimer);


        if (_hitable.DrunknessAmount >= 20)
        {
            _isOD = true;
        }
        if (_isOD&&_hitable.DrunknessAmount<=20)
        {
            _isOD=false;
        }
        if (_isOD)
        {
            // OD change flickering
            _timerOD += Time.deltaTime;
            if (Mathf.FloorToInt(_timerOD / _frequencyOD) % 2 == 0)
            {
                _meshRenderer.material.color = _sober;
            }
            else
            {
                _meshRenderer.material.color = _od;
            }
            //Game over if OD is too much
            if (_timerOD >= 10 || _hitable.DrunknessAmount >= 25)
            {
                _meshRenderer.material.color = Color.black;
                _hitable.IsAngry = false;
                Debug.Log("Game Over! someone OD'd on vodka");
            }
        }
    }
}
