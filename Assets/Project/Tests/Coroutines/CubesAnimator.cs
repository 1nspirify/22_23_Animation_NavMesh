using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesAnimator : MonoBehaviour
{
    [SerializeField] private List<Transform> _cubes = new();

    private void Awake()
    {
        StartCoroutine(AnimateCubes());
    }

    private IEnumerator AnimateCubes()
    {
        int startCubesCount = _cubes.Count;
        List<YieldInstruction> cubesAnimations = new List<YieldInstruction>();

        for (int i = 0; i < startCubesCount; i++)
        {
            Transform cube = _cubes[Random.Range(0, _cubes.Count)];
            _cubes.Remove(cube);

            Coroutine animation = StartCoroutine(AnimateScaleFor(cube));
            cubesAnimations.Add(animation);

            yield return new WaitForSeconds(Random.Range(0, 0.75f));
        }

        foreach (YieldInstruction cubesAnimation in cubesAnimations)
            yield return cubesAnimation;

        Debug.Log("CubesHaveBeenDisappeared");
    }

    private IEnumerator AnimateScaleFor(Transform cube)
    {
        float progress = 0;
        float animationTime = 1.2f;

        Vector3 startScale = cube.localScale;

        while (progress < animationTime)
        {
            progress += Time.deltaTime;
            cube.localScale = Vector3.Lerp(startScale, Vector3.zero, progress / animationTime);
            yield return null;
        }
    }
}