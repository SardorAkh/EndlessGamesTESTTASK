using DG.Tweening;
using UnityEngine;
public class Mover : MonoBehaviour {

	public void Init(float speed, float distance) {
		transform.DOLocalMove(transform.position + transform.forward * distance, speed)
			.SetEase(Ease.Linear)
			.OnComplete(() => Destroy(gameObject));
	}

}
