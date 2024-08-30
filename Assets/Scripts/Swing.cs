using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _force;
    [SerializeField] private KeyCode _button;

    private void Update()
    {
        if (Input.GetKeyDown(_button) == false)
            return;

        _rigidbody.AddForce(_rigidbody.transform.forward * _force, ForceMode.Impulse);
    }
}