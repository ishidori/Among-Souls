using UnityEngine;
using UnityEngine.EventSystems;


public class JumpButtonControl : MonoBehaviour , IPointerDownHandler
{
   [SerializeField] private PlayerJumpHandler PlayerJump;
    
   public void OnPointerDown (PointerEventData eventData)
   {
       PlayerJump.Jump();
   }
}
