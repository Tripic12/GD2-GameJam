using UnityEngine;

public class LightMovingScript : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    private float lightTimer;
    private int lightTime=1;
    private float _multiplier=1f;
    [SerializeField] private Vector3 _dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightTimer += Time.deltaTime*_multiplier;
        if(lightTimer > lightTime&&_multiplier==1f)
        {
            _light.transform.position += _dir*2*_multiplier;
            _multiplier = -1f;
        }
        if(lightTimer < 0&&_multiplier==-1f)
        {
            _light.transform.position += _dir*2*_multiplier;
            _multiplier = 1f;
        }
        

      

    }
}
