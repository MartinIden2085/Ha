using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    [SerializeField] private List<Transform> _tails;
    [SerializeField] private GameObject _BonePrefab;
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.TryGetComponent(out Eat eat)) ;
        {
            Destroy(Other.gameObject);

            GameObject bone = Instantiate(_BonePrefab);
            _tails.Add(bone.transform);
        }
    }

}
