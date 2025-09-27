using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    private float _lerpTimer;
    private float _duration = 5;
    private int _timerOD;

    private MeshRenderer _meshRenderer;
    private Color _characterColor;
    //Statuses
    private bool _isSober;
    private bool _isTipsy;
    private bool _isDrunk;
    private bool _isOD;

    //Status materials
    [SerializeField]
    private Material _sober;
    [SerializeField]
    private Material _drunk;
    [SerializeField]
    private Material _od;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        _characterColor = _meshRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetMouseButton(0))
        {
            _lerpTimer += Time.deltaTime / _duration;
        }
        _characterColor = Color.Lerp(_sober.color, _drunk.color, _lerpTimer);*/

        if ((Input.GetMouseButtonDown(1)))
        {
            _isOD= true;
        }
        if (_isOD)
        {
            _timerOD += 1;
            if(_timerOD % 2 == 0)
            {
                _meshRenderer.material.color = _sober.color;
            } 
            else
            {
                _meshRenderer.material.color = _od.color;
            }
        }
    }
}
