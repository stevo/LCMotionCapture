using System;
using System.Collections;

namespace FinalApp1
{
	/// <summary>
	/// Class defining neural network layer
	/// </summary>
	public class NeuralNetworkLayer
	{
		public ArrayList        Neurons;

		public NeuralNetworkLayer(int NeuronCount, iActivationFunction f)
		{
			Neurons = new ArrayList();

			for (int i=0; i<NeuronCount; i++) 
			 { AddNeuron(new Neuron(f)); }
		}


		public void AddNeuron(Neuron N)
		{
			Neurons.Add(N);
		}


		public void AttachToLayer(NeuralNetworkLayer W)
		{
            //laczy z nizsza warstwa od tej ktora wywolywuje metode
			foreach(Neuron N in Neurons)
			{
				N.AddInputs(W);
			}
		}


		public void DrawWeights(double Min, double Max, Random R)
		{
			foreach(Neuron N in Neurons)
			{
				N.DrawWeights(Min, Max, R);
			}
		}
		

		public void SetOutput(double []Outputs)
		{
			//Function implementuje warstwe wejsciowa
			for (int i=0; i<Neurons.Count; i++)
			{
				((Neuron)Neurons[i]).Output = Outputs[i];
			}
		}


		public double[] returnOutput()
		{
			//Fukcja implementuje warstwe wyjsciowa
			//Zwrocona zostanie tablica double'ów (o ilosci el. = ilosci neuronow)
			double []Outputs = new double[Neurons.Count];

			for (int i=0; i<Neurons.Count; i++)
			{
				Outputs[i] = ((Neuron)Neurons[i]).Output;
			}

			return Outputs;
		}


		public void CalculateLayerOutput()
		{
			foreach(Neuron N in Neurons)
			{
				N.CalculateOutput();
			}
		}


		public void ClearErrors()
		{
			foreach(Neuron N in Neurons)
			{
				N.Error = 0.0;
			}
		}


		public void CalculateErros(double []CorrectOutputs)
		{
			for (int i=0; i<Neurons.Count; i++)
			{
				((Neuron)Neurons[i]).CalculateError(CorrectOutputs[i]);
			}
		}


		public void CorrectWeights(double TrainingFactor)
		{
			foreach (Neuron N in Neurons)
			{
				N.CorrectWeights(TrainingFactor);
			}
		}


		public void BackPropagateErrors()
		{
			foreach(Neuron N in Neurons)
			{
				N.BackPropagateErrors();
			}
		}
	}
}
