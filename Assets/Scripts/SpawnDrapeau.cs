using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnDrapeau : MonoBehaviour
{
	public GameObject _prefabDrapeau;
	private int _sizemap = 10;
	public GameObject[] _listDrapeaux;
	public GameObject _posdrapeaux;
	public GameObject _drapeau;

	void Awake()
	{
		StartCoroutine(FirstSpawnDrapeau());
		
	}


	private IEnumerator FirstSpawnDrapeau()
    {
		yield return new WaitForSeconds(15);
		_listDrapeaux = GameObject.FindGameObjectsWithTag("Drapeau");
		int index = Random.Range(0, _listDrapeaux.Length);
		_posdrapeaux = _listDrapeaux[index];

		_drapeau = Instantiate(_prefabDrapeau, _posdrapeaux.transform.position, Quaternion.identity, this.transform);
		StartCoroutine(DelayDrapeau());
		

	}

	private IEnumerator DelayDrapeau()
    {
		
		yield return new WaitForSeconds(5);
		Destroy(_drapeau);
		_listDrapeaux = GameObject.FindGameObjectsWithTag("Drapeau");
		int index = Random.Range(0, _listDrapeaux.Length);
		_posdrapeaux = _listDrapeaux[index];

		_drapeau = Instantiate(_prefabDrapeau, _posdrapeaux.transform.position, Quaternion.identity, this.transform);
		StartCoroutine(DelayDrapeau());

	}


	// Update is called once per frame
	void Update()
    {

        
	}
}
