using UnityEngine;
using UnityEngine.UI;
public class DemoStartButton : MonoBehaviour
{
    [SerializeField]private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(GameManager.Instance.StartGame);
    }
}
