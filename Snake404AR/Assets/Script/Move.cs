using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private List<Transform> _tails;
    [SerializeField] private float _BonesDistance;
    [SerializeField] private GameObject _BonePrefab;
    [Range(0, 5), SerializeField] private float _movespeed;
    [Range(0, 80), SerializeField] private float _rotatespeed;


    private void Update()
    {
        MoveHead(_movespeed);
        MoveTail();
        Rotate(_rotatespeed);
    }

    private void Rotate(float speed)
    {
        float angle = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Rotate(0, angle, 0);
    }

    private void MoveTail()
    {
        float sqrDistance = Mathf.Sqrt(_BonesDistance);
        Vector3 previousPosition = transform.position;

        foreach (var bone in _tails)
        {
            if ((bone.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                Vector3 currentBonePosition = bone.position;
                bone.position = previousPosition;
                previousPosition = currentBonePosition;
            }
            else
            {
                break;
            }
        }
    }

    private void MoveHead(float speed)
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
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

