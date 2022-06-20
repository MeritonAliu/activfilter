/* 
 * Filter.cs
 * Activ filter OOP Project
 * BFSU 29.05.2022 
 * Meriton Aliu / Dario Casciato
 * This file contains the mother class for all other filters.
 */

using CsvHelper;
using System.Text;
using System.IO;
using System;

namespace activfilter
{
    public abstract class Filter
    {
        //Attributes
        protected double dblFrequency; //saves the frequency of the filter
        protected double dblResistorOne; //saves the resistor value of the filter
        protected double dblResistorTwo; //saves the resistor value of the filter
        protected double dblCapacitorOne; //saves the capacitor value of the filter
        protected double dblCapacitorTwo; //saves the capacitor value of the filter
        protected double dblVoltageGain; //saves the voltage gain of the filter
        protected double dblPhaseshift; //saves the phaseshift of the filter
        protected double dblMaxFreqBodePlot = 10000000; //sets the max frequency to 10Mhz for the bode plot
        protected double dblTransitFrequency = 1000000; //saves the Transitfrequency of the filter 1Mhz standard
        protected double dblOpenLoopGain = 100000; //saves the OpenLoopGain of the filter 100kV/V
        protected double dblMaxGainFilter; //saves the max gain of the filter
        protected string strFilterTypeName = "FitlerName"; //saves the Type of the filter

        //Properties
        public string FilterTypeName 
        { 
            get { return strFilterTypeName; }
            set { strFilterTypeName = value; }
        }

        public double TransitFrequency
        {
            get { return dblTransitFrequency; }
            set { dblTransitFrequency = value; }
        }

        public double OpenLoopGain
        {
            get { return dblOpenLoopGain; }
            set { dblOpenLoopGain = value; }
        }

        public double MaxFreqBodePlot
        {
            get { return dblMaxFreqBodePlot; }
            set { dblMaxFreqBodePlot = value; }
        }
        public double Frequency 
        {
            get { return dblFrequency; }
            set 
            { 
                if(value > 0) //checks if frequency is over 0 to avoid errors
                {
                    dblFrequency = value;
                }
                else
                {
                    throw new Exception("Frequency must be greater than 0");
                }
            }
        }

        public double MaxGainFilter
        {
            get { return dblMaxGainFilter; }
            protected set { dblMaxGainFilter = value; }
        }
        public double ResistorOne 
        {
            get{ return dblResistorOne; }
            set
            { 
                if(value > 0) // checks if resistor is over 0 to avoid errors
                {
                    dblResistorOne = value;
                }
                else
                {
                    throw new Exception("ResistorOne must be greater than 0");
                }
            }
        }
        public double ResistorTwo 
        {
            get{ return dblResistorTwo; }
            set
            { 
                if(value > 0) // checks if resistor is over 0 to avoid errors
                {
                    dblResistorTwo = value;
                }
                else
                {
                    throw new Exception("ResistorTwo must be greater than 0");
                }
            }
        }
        public double CapacitorOne
        {
            get{ return dblCapacitorOne; }
            set 
            {
                if(value > 0)  // checks if capacitor is over 0 to avoid errors
                {
                    dblCapacitorOne = value;
                }
                else
                {
                    throw new Exception("CapacitorOne must be greater than 0");
                }
            }
        }
        public double CapacitorTwo // checks if capacitor is over 0 to avoid errors
        {
            get{ return dblCapacitorTwo; }
            set 
            { 
                if(value > 0) // checks if capacitor is over 0 to avoid errors
                {
                    dblCapacitorTwo = value;
                }
                else
                {
                    throw new Exception("CapacitorTwo must be greater than 0");
                }
            }
        }
        public double ReactanceOne
        {
            get{ return (1 / (2 * Math.PI * Frequency * CapacitorOne)); } 
        }
        public double ReactanceTwo
        {
            get { return (1 / (2 * Math.PI * Frequency * CapacitorTwo)); } 
        }
        public double ImpedanceOne
        { 
            get { return Math.Sqrt((Math.Pow(ResistorOne, 2)) + (Math.Pow(ReactanceOne, 2))); }
        }
        public double ImpedanceTwo
        {
            get { return (ReactanceTwo * ResistorTwo)/(Math.Sqrt(Math.Pow(ReactanceTwo, 2) + Math.Pow(ResistorTwo, 2))); }
        }
        public virtual double VoltageGain
        {
            get{ return dblVoltageGain; }
        }
        public virtual double Phaseshift
        {
            get { return Phaseshift; }
        }
        public double LowerCutoffFrequency
        {
            get{ return 1 / (2 * Math.PI * ResistorTwo * CapacitorTwo); }
        }
        public double UpperCutoffFrequency
        {
            get{ return 1 / (2 * Math.PI * ResistorOne * CapacitorOne); }
        }

        //Methodes 
        public double runGainCalculation(double randomFrequency) //Gives the gain on any frequency
        {
            Frequency = randomFrequency;
            return VoltageGain;
        }
        public double runPhaseCalculation(double randomFrequency) //Gives the Phase on any frequency
        {
            Frequency = randomFrequency;
            return Phaseshift;
        }

        public void runBodePlot() //runs bode plot simulation on csv file and on the console
        {
            var csv = new StringBuilder(); //creates a new stringbuilder
            for (int iDekade = 1; iDekade <= dblMaxFreqBodePlot; iDekade *= 10) { //loops through all dekades
                for (int i = 1; (i <= 9) && ((iDekade * i) <= dblMaxFreqBodePlot); ++i) { //loops through all numbers in a dekade
                    Frequency = iDekade * i; //sets the frequency to the current dekade and number
                    Console.WriteLine(FilterTypeName + ": Frequenz: " + Frequency + " Amplification: " + VoltageGain + " Phasing: " + Phaseshift); //prints the current frequency and gain on the console
                    var newLine = string.Format("{0};{1};{2}", Frequency, VoltageGain, Phaseshift); //creates a new line in the csv file
                    csv.AppendLine(newLine); //adds the new line to the csv file
                }
            }
            string filePath = "../../CSV/BodePlot_" +FilterTypeName + ".csv"; //sets the filepath to the csv file
            File.WriteAllText(filePath, csv.ToString()); //writes the csv file to the filepath
        }

        protected double controlVoltageGain(double dblFilterGain)
        {

            if(dblFilterGain >= OpenLoopGain)
            {
                dblFilterGain = OpenLoopGain; // if the voltage gain is higher than the open loop gain, the voltage gain is the open loop gain
            }

            double dblVirtualGain = 1 / (Math.Sqrt(Math.Pow((OpenLoopGain/TransitFrequency),2)+1));
            double dblTotalGain = dblFilterGain * dblVirtualGain;

            return dblTotalGain; 
        }
        
    }
}