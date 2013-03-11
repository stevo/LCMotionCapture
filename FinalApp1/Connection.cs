using System;

namespace FinalApp1
{
	/// <summary>
	/// Klasa definiujaca polaczenia pomiedzy neuronami
	/// </summary>
	public class Connection
	{

		public Neuron           N;
        public double           Weight;

		public Connection(Neuron N, double W)
		{
			this.N  = N;
			Weight  = W;
		}

	}
}
