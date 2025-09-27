using UnityEngine;

public class Puke : MonoBehaviour
{
    [SerializeField] private float _pukeLife = 20f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_pukeLife<=0f) Destroy(gameObject);
    }
    public void GetCleaned(float bulletDamage)
    {
        _pukeLife-=bulletDamage;
    }
    private void OnTriggerStay(Collider other)
    {
        GameObject hitTarget = other.gameObject;
        if (hitTarget.tag == "Drunky")
        {
            Hitable hitScriptTarget = hitTarget.GetComponent<Hitable>();
            hitScriptTarget.HitByPuke();
        }

    }
}
