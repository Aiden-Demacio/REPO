using UnityEngine;

[RequireComponent(
	typeof(CharacterController),
	typeof(PlayerLook)
)]
public class PlayerController : MonoBehaviour
{
	[SerializeField] float m_Speed = 2;

	private CharacterController m_Controller;
	private PlayerLook m_Look;

	void Awake()
	{
		m_Controller = GetComponent<CharacterController>();
		m_Look = GetComponent<PlayerLook>();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 moveDir = m_Look.RotateYaw(new Vector3(h, 0, v));

		m_Controller.SimpleMove(moveDir * m_Speed);
	}
}
