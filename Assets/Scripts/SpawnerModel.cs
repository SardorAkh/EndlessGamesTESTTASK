using UniRx;
using UnityEngine;
public class SpawnerModel {
	private ReactiveProperty<float> _prefabSpeed = new ReactiveProperty<float>();
	private ReactiveProperty<float> _prefabMoveDistance = new ReactiveProperty<float>();
	private ReactiveProperty<float> _intervalToSpawn = new ReactiveProperty<float>();


	public IReadOnlyReactiveProperty<float> PrefabSpeed => _prefabSpeed;
	public IReadOnlyReactiveProperty<float> PrefabMoveDistance => _prefabMoveDistance;
	public IReadOnlyReactiveProperty<float> IntervalToSpawn => _intervalToSpawn;

	public void UpdateSpeedProperty(float newVal) { _prefabSpeed.Value = newVal; }
	public void UpdateDistanceProperty(float newVal) { _prefabMoveDistance.Value = newVal; }
	public void UpdateIntervalToSpawnProperty(float newVal) { _intervalToSpawn.Value = newVal; }
}
