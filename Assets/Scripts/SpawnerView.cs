using System;
using TMPro;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;

public class SpawnerView : MonoBehaviour {
	private SpawnerModel _model;

	[SerializeField] private TMP_InputField prefabSpeedInput;
	[SerializeField] private TMP_InputField prefabDistanceInput;
	[SerializeField] private TMP_InputField intervalToSpawnInput;

	public void Init(SpawnerModel model) {
		_model = model;

		prefabSpeedInput.onValueChanged
			.AsObservable()
			.Subscribe(newValue => {
					if (float.TryParse(newValue, out float result)) { _model.UpdateSpeedProperty(result); }
				}
			)
			.AddTo(this);

		prefabDistanceInput.onValueChanged
			.AsObservable()
			.Subscribe(newValue => {
					if (float.TryParse(newValue, out float result)) {
						_model.UpdateDistanceProperty(result);
					}
				}
			)
			.AddTo(this);

		intervalToSpawnInput.onValueChanged
			.AsObservable()
			.Subscribe(newValue => {
					if (float.TryParse(newValue, out float result)) {
						_model.UpdateIntervalToSpawnProperty(result);
					}
				}
			)
			.AddTo(this);

		_model.PrefabSpeed.Subscribe(value => prefabSpeedInput.text = value.ToString()).AddTo(this);
		_model.PrefabMoveDistance.Subscribe(value => prefabDistanceInput.text = value.ToString()).AddTo(this);
		_model.IntervalToSpawn.Subscribe(value => intervalToSpawnInput.text = value.ToString()).AddTo(this);
	}
}
