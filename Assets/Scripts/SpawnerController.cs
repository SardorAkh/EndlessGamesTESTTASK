using System;
using UnityEngine;

public class SpawnerController : MonoBehaviour {
	private SpawnerModel _model;
	[SerializeField] private SpawnerView _view;
	[SerializeField] private Spawner spawner;

	[SerializeField] private float initPrefabSpeed;
	[SerializeField] private float initPrefabDistance;
	[SerializeField] private float initIntervalToSpawn;
	private void Start() {
		_model = new();

		_model.UpdateSpeedProperty(initPrefabSpeed);
		_model.UpdateDistanceProperty(initPrefabDistance);
		_model.UpdateIntervalToSpawnProperty(initIntervalToSpawn);
        
		_view.Init(_model);
		spawner.Init(_model);
	}
}
