using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(
	typeof(CharacterController),
	typeof(PlayerLook)
)]
public class PlayerController : MonoBehaviour
{
	[SerializeField] float m_Speed = 2;
	[SerializeField] Animator m_Animator;

	private CharacterController m_Controller;
	private PlayerLook m_Look;

	void Awake()
	{
		m_Controller = GetComponent<CharacterController>();
		m_Look = GetComponent<PlayerLook>();

		Assert.IsNotNull(m_Animator);
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		// Blend tree
		Vector2 animMoveDir = new Vector2(h, v);
		m_Animator.SetFloat("WalkX", animMoveDir.x);
		m_Animator.SetFloat("WalkY", animMoveDir.y);

		Vector3 moveDir = m_Look.RotateYaw(new Vector3(h, 0, v));
		Vector3 velocity = moveDir * m_Speed;

		m_Animator.SetFloat("Speed", velocity.magnitude);

		m_Controller.SimpleMove(velocity);
	}
}
