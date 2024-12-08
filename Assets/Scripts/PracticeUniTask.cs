using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using PrimeTween;

public class PracticeUniTask : MonoBehaviour
{
    public GameObject target;
    public Transform targetTransform;
    private Sequence sequence;
    private Tween tween;

    [Button]
    private void DelayShow()
    {
        // target.SetActive(false);
        // await UniTask.WaitForSeconds(5f, cancellationToken: this.GetCancellationTokenOnDestroy());
        // target.SetActive(true);
        // Debug.LogError("show text");
        Show().Forget();
    }

    [Button]
    private void JumpAnim()
    {
        if (!sequence.isAlive) {
            const float jumpDuration = 0.3f;
            sequence = Tween.Scale(targetTransform, new Vector3(1.1f, 0.8f, 1.1f), 0.15f, Ease.OutQuad, 2, CycleMode.Yoyo)
                .Chain(Tween.LocalPositionY(targetTransform, 100, jumpDuration))
                .Chain(Tween.LocalEulerAngles(targetTransform, Vector3.zero, new Vector3(0, 360), 1.5f, Ease.InOutBack))
                .Chain(Tween.LocalPositionY(targetTransform, 0, jumpDuration));
        }
    }

    [Button]
    private void SqueezeAnim()
    {
        if (!tween.isAlive)
        {
            tween = Tween.Scale(targetTransform, new Vector3(1.15f, 0.8f, 1.15f), 0.2f, Ease.OutSine, 2,
                CycleMode.Yoyo);
        }
    }

    private void Start()
    {
        // DelayShow();
        Show().Forget();
    }

    private async UniTaskVoid Show()
    {
        await UniTask.WaitForSeconds(3f, cancellationToken: this.GetCancellationTokenOnDestroy());
        Debug.LogError("delay unitask ");
    }
}