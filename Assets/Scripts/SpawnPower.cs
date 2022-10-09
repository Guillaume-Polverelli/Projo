using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPower : MonoBehaviour
{
    public GameObject[] powers;
    public GameObject[] _listpospowers;
    public GameObject _pospower;
    public GameObject power;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartPowers());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PowerAppears()
    {
        _listpospowers = GameObject.FindGameObjectsWithTag("Power");
        int index = Random.Range(0, _listpospowers.Length);
        _pospower = _listpospowers[index];

        int index2 = Random.Range(0, powers.Length);
        power = powers[index2];

        power = Instantiate(power, _pospower.transform.position, Quaternion.identity, this.transform);
        yield return new WaitForSeconds(15);
        if (power)
        {
            Destroy(power);
        }
        
        StartCoroutine(PowerAppears());

    }

    private IEnumerator StartPowers()
    {
        yield return new WaitForSeconds(20);
        StartCoroutine(PowerAppears());
    }
}
