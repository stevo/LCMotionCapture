using System;
using System.Collections;


namespace FinalApp1
{
	/// <summary>
	/// Klasa definujaca neuron - bedacy skladnikiem sieci neuronowej
	/// </summary>
	public class Neuron
	{
		
		public iActivationFunction     Function;
        public double                Output;
		public ArrayList             Inputs;
        public double                BiasWeight;
		public double                Error;

		public Neuron(iActivationFunction f)
		{
			Error        = 0.0;

			Output     = 0.0;

			Inputs     = new ArrayList();

			Function     = f;

			BiasWeight   = 0.0;
		}


		public void AddInputs(Neuron N)
		{
			Inputs.Add(new Connection(N, 1.0));
		}          


		public void AddInputs(Neuron N, double W)
		{
			Inputs.Add(new Connection(N, W));
		}


		public void AddInputs(NeuralNetworkLayer W)
		{        
			foreach(Neuron N in W.Neurons)
			{
				AddInputs(N);
			}
		}
		

		public void DrawWeights(double Min, double Max, Random R)
		{
			//dla kazdego Inputs ustalamy losowa wartosc wagi z przedzialu Min-Max
			foreach (Connection Conn in Inputs)
			{
				Conn.Weight = (R.NextDouble() * (Max - Min)) + Min;
			}
			//To samo robimy dla biasu
			BiasWeight = (R.NextDouble() * (Max - Min)) + Min;
		}


		public void CalculateOutput()
		{
			Output = 0.0;
			//najpierw obliczamy wartosc potencjalu membranowego
			foreach (Connection Conn in Inputs)
			{
				Output += Conn.Weight * Conn.N.Output;
			}

			//wzbogacamy te wartosc o iloczyn biasu i wagi jego polaczenia
			Output += BiasWeight * 1.0;

			//przepuszczamy uzyskana wartosc przez blok aktywacji neuronu
			Output = Function.CalculateFunctionValue(Output);
		}


		public void CalculateError(double PreviousOutput)
		{
			Error = PreviousOutput - Output;
		}


		public void CorrectWeights(double TrainingFactor)
		{


			foreach (Connection p in Inputs)
			{
				p.Weight += TrainingFactor * Error * Function.CalculateFunctionDerivative(Output) * p.N.Output;
			}

			BiasWeight +=  TrainingFactor * Error * Function.CalculateFunctionDerivative(Output) * 1.0;

		}


		public void BackPropagateErrors()
		{
			foreach(Connection p in Inputs)
			{
				p.N.Error += Error * p.Weight;
			}
		}
	}
}
