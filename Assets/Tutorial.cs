using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

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
        var task = StartTutorial();
    }

    static async UniTask Fade(CanvasGroup cg, float targetAlpha = 1)
    {
        float start = Time.time;
        float startAlpha = cg.alpha;

        for (; ; )
        {
            float now = Time.time;

            cg.alpha = Mathf.Lerp(startAlpha, targetAlpha, Mathf.Clamp01(now - start));

            await UniTask.Yield(PlayerLoopTiming.Update);

            if (now - start >= 1) return;
        }
    }

    async UniTaskVoid StartTutorial()
    {
        await UniTask.Delay(1000);
        await Fade(title);

        for (; ; )
        {
            await UniTask.Delay(1000);
            await UniTask.WhenAll(
                Fade(hold, 1),
                Fade(aim, 0),
                Fade(launch, 0)
                );

            for (; !bouncer.IsGrabbing();)
            {
                await UniTask.Yield(PlayerLoopTiming.Update);
            }

            await UniTask.WhenAll(Fade(hold, .5f), Fade(aim));

            {
                Vector3 last = Input.mousePosition;
                float distance = 0;

                for (; distance < Screen.width * .4f && bouncer.IsGrabbing();)
                {
                    await UniTask.Yield(PlayerLoopTiming.Update);
                    distance += Vector3.Distance(last, Input.mousePosition);
                    last = Input.mousePosition;
                }
            }

            if (!bouncer.IsGrabbing())
                continue; // restart tutorial

            await UniTask.WhenAll(Fade(aim, .5f), Fade(launch));

            for (; bouncer.IsGrabbing();)
            {
                await UniTask.Yield(PlayerLoopTiming.Update);
            }

            await UniTask.WhenAll(
                Fade(hold, 0),
                Fade(aim, 0),
                Fade(launch, 0)
                );
        }
    }
}
