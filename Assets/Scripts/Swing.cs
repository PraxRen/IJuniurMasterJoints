using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _force;
    [SerializeField] private KeyCode _buttonPush;

    private void Update()
    {
        if (Input.GetKeyDown(_buttonPush) == false)
            return;

        _rigidbody.AddForce(_rigidbody.transform.forward * _force, ForceMode.Impulse);
    }
}