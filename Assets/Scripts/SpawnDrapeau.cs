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

	void Start()
	{

		_listDrapeaux = GameObject.FindGameObjectsWithTag("Drapeau");
		int index = Random.Range(0, _listDrapeaux.Length);
		_posdrapeaux = _listDrapeaux[index];

		_drapeau = Instantiate(_prefabDrapeau, _posdrapeaux.transform.position, Quaternion.identity, this.transform);

	}





	// Update is called once per frame
	void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
			_listDrapeaux = GameObject.FindGameObjectsWithTag("Drapeau");
			int index = Random.Range(0, _listDrapeaux.Length);
			_posdrapeaux = _listDrapeaux[index];

			_drapeau.transform.SetPositionAndRotation(_posdrapeaux.transform.position, Quaternion.identity);
        }
	}
}