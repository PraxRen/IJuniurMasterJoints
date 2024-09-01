using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private CatapultSpoon _catapultSpoon;
    [SerializeField] private float _spring;
    [SerializeField] private KeyCode _buttonAttack;
    [SerializeField] private KeyCode _buttonRestart;

    private void Start()
    {
        _catapultSpoon.Restart();
        _catapultSpoon.SetSpring(_spring);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_buttonAttack))
        {
            _catapultSpoon.Attack();
        }

        if (Input.GetKeyDown(_buttonRestart))
        {
            _catapultSpoon.Restart();
        }
    }
}