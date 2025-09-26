using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool IsWater = false;
    [SerializeField] private float _bullletSpeed = 20f;
    [SerializeField] private Material _bulletMaterial;
    

    void Start()
    {
        
    }
    void Update()
    {
        //move the bullet straight
        transform.position += transform.up.normalized*_bullletSpeed * Time.deltaTime;
        if (IsWater)
        {
            _bulletMaterial.color = Color.blue;
        }
        if(!IsWater)
        {
            _bulletMaterial.color = Color.white;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject hitTarget = other.gameObject;
        Hitable hitScriptTarget=hitTarget.GetComponent<Hitable>();
        if( hitScriptTarget == null)
        {
            Destroy(this.gameObject);
        }

    }
}
