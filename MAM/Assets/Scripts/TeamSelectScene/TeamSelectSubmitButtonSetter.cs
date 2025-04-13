using UnityEngine;

public class TeamSelectSubmitButtonSetter : MonoBehaviour
{
    [SerializeField] TeamSelectSubmitButtonUpdater _updater;
    
    public void Initialize()
    {
        _updater.SetInteractible(false);
        _updater.AddOnClickEventListener(() => {
            Debug.Log("팀 빌딩 완료!");
        });
    }
}
