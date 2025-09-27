using System.Collections.Generic;
using UnityEngine;

public class DrunkRandomizer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _drunkies = new List<GameObject>();

    void Start()
    {
        foreach (GameObject drunky in _drunkies)
        {
            Hitable hitable = drunky.GetComponent<Hitable>();
            int randomValue = Random.Range(3, 7);
            hitable.DrunknessAmount = randomValue;
            hitable.DrunknessTargetValue = randomValue;
        }
    }
}
