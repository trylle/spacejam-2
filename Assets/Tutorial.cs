using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Threading;

public class Tutorial : MonoBehaviour
{
    public CanvasGroup title;
    public CanvasGroup hold;
    public CanvasGroup aim;
    public CanvasGroup launch;
    public Bouncer bouncer;

    // Start is called before the first frame update
    void Start()
    {
        var task = StartTutorial(this.GetCancellationTokenOnDestroy());
    }

    static async UniTask Fade(CanvasGroup cg, float targetAlpha = 1, CancellationToken cancellationToken = default)
    {
        float start = Time.time;
        float startAlpha = cg.alpha;

        for (; ; )
        {
            float now = Time.time;

            cg.alpha = Mathf.Lerp(startAlpha, targetAlpha, Mathf.Clamp01(now - start));

            await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);

            if (now - start >= 1) return;
        }
    }

    async UniTaskVoid StartTutorial(CancellationToken cancellationToken)
    {
        await UniTask.Delay(1000, false, PlayerLoopTiming.Update, cancellationToken);
        await Fade(title, 1, cancellationToken);

        for (; ; )
        {
            await UniTask.Delay(1000, false, PlayerLoopTiming.Update, cancellationToken);
            await UniTask.WhenAll(
                Fade(hold, 1, cancellationToken),
                Fade(aim, 0, cancellationToken),
                Fade(launch, 0, cancellationToken)
                );

            for (; !bouncer.IsGrabbing();)
            {
                await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
            }

            await UniTask.WhenAll(Fade(hold, .5f, cancellationToken), Fade(aim, 1, cancellationToken));

            {
                Vector3 last = Input.mousePosition;
                float distance = 0;

                for (; distance < Screen.width * .4f && bouncer.IsGrabbing();)
                {
                    await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
                    distance += Vector3.Distance(last, Input.mousePosition);
                    last = Input.mousePosition;
                }
            }

            if (!bouncer.IsGrabbing())
                continue; // restart tutorial

            await UniTask.WhenAll(Fade(aim, .5f, cancellationToken), Fade(launch, 1, cancellationToken));

            for (; bouncer.IsGrabbing();)
            {
                await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
            }

            await UniTask.WhenAll(
                Fade(hold, 0, cancellationToken),
                Fade(aim, 0, cancellationToken),
                Fade(launch, 0, cancellationToken)
                );
        }
    }
}
