using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UniRx;

public class Spawner : MonoBehaviour {
	[SerializeField] private Mover spawnPrefab;
	[SerializeField] private Transform spawnPoint;

	private float _prefabSpeed;
	private float _prefabMoveDistance;
	private float _intervalToSpawn;

	private SpawnerModel _model;
	public void Init(SpawnerModel model) {
		_model = model;

		_model.PrefabSpeed.Subscribe(newValue => _prefabSpeed = newValue).AddTo(this);
		_model.PrefabMoveDistance.Subscribe(newValue => _prefabMoveDistance = newValue).AddTo(this);
		_model.IntervalToSpawn.Subscribe(OnIntervalChanged).AddTo(this);
	}
	private void OnIntervalChanged(float newValue) {
		StopCoroutine(nameof(SpawnCoroutine));

		_intervalToSpawn = newValue;

		StartCoroutine(nameof(SpawnCoroutine));
	}
	private void OnEnable() {
		StartCoroutine(nameof(SpawnCoroutine));
	}
	private void OnDisable() {
		StopCoroutine(nameof(SpawnCoroutine));
	}

	IEnumerator SpawnCoroutine() {
		while (true) {
			Spawn();
			yield return new WaitForSeconds(_intervalToSpawn);
		}
	}

	private void Spawn() {
		var mover = Instantiate(spawnPrefab, spawnPoint.position, Quaternion.identity);
		mover.Init(_prefabSpeed, _prefabMoveDistance);
	}

}
