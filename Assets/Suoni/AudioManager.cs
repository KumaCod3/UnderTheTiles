using UnityEngine;

public class AudioManager: MonoBehaviour
{
	public Suono[] suoni;

	public static AudioManager instance;

	bool tema = false;
	public static bool tm = false;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;

		}
		else
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);

		foreach (Suono s in suoni)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
			s.source.playOnAwake = s.playOnAwake;
		}
		PlaySound("intro");
	}

	private void Update()
	{
		if (tema != tm)
		{
			cambiaTema();
		}
	}

	public void PlaySound(string nome)
	{
		foreach (Suono s in suoni)
		{
			if (s.name.Equals(nome))
			{
				s.source.Play();
				return;
			}
		}
		Debug.Log("suono " + nome + " non trovato");
	}
	public void StopSound(string nome)
	{
		foreach (Suono s in suoni)
		{
			if (s.name.Equals(nome))
			{
				s.source.Stop();
				return;
			}
		}
		Debug.Log("suono " + nome + " non trovato");
	}

	public void cambiaTema()
	{
		if (tema)
		{
			PlaySound("tema2");
			StopSound("tema1");
			tema = false;
		}
		else if (!tema)
		{
			PlaySound("tema1");
			StopSound("tema2");
			tema = true;
		}
	}

}
