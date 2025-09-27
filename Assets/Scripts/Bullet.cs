using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool IsWater = false;
    [SerializeField] private float _bullletSpeed = 20f;
    [SerializeField] private Renderer _bulletRenderer;
    [SerializeField] private float _bulletDamageAmount = 5f;

    void Start()
    {
        _bulletRenderer = gameObject.GetComponent<Renderer>();
    }
    void Update()
    {
        //move the bullet straight
        transform.position += transform.up.normalized*_bullletSpeed * Time.deltaTime;
        if (IsWater)
        {
            _bulletRenderer.material.color = Color.blue;
        }
        if(!IsWater)
        {
            _bulletRenderer.material.color = Color.white;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject hitTarget = other.gameObject;
        
        
        if (hitTarget.tag == "Drunky")
        {
            Hitable hitScriptTarget = hitTarget.GetComponent<Hitable>();
            hitScriptTarget.GotHit(IsWater, _bulletDamageAmount);
            Destroy(this.gameObject);
        }
        

        if (hitTarget.tag=="Puke"&&IsWater) 
        {
            hitTarget.GetComponent<Puke>().GetCleaned(_bulletDamageAmount);
            Destroy(gameObject);
        }
        
        if( hitTarget.tag=="Untagged")
        {
            Destroy(this.gameObject,0.1f);
        }

    }
}
