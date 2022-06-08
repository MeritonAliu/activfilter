/* 
 * BandPassFilterInverting.cs
 * Activ filter OOP Project
 * BFSU 29.05.2022 
 * Meriton Aliu / Dario Casciato
 * This file contains the child class for the active inverting bandpass filter.
 */
using System;

namespace activfilter.classlib.FilterClass
{
    class BandPassFilterInverting : Filter
    {       
        //Properties
        public override double VoltageGain //overrides the VoltageGain methode from the filter class
        {
            get
            { 
                double dblVoltageGain = (ImpedanceTwo / ImpedanceOne);
                dblVoltageGain = controlVoltageGain(dblVoltageGain); // control the voltage gain
                return dblVoltageGain; 
            }
        }
        public override double Phaseshift //overrides the Phaseshift methode from the filter class
        {
            get 
            {
                return (180 / Math.PI) * Math.Atan(-Frequency * (MaxGainFilter / TransitFrequency) + -(2 * Math.PI * Frequency * CapacitorTwo * ResistorTwo) + 1 / (2 * Math.PI * Frequency * CapacitorOne * ResistorOne)) - 180;
                //return dblPhaseshift = (180/Math.PI)* (Math.Atan(ReactanceOne/ResistorOne) - Math.Atan((1/ReactanceTwo)*ResistorTwo)) - 180;
            }
        }

        //Constructors
        public BandPassFilterInverting()
        {
            //default constructor, set on random working values
            Frequency = 1000;
            ResistorOne = 1592;
            ResistorTwo = 1592;
            CapacitorOne = 0.0000001;
            CapacitorTwo = 0.000000001;
            FilterTypeName = "BPINV";
            MaxGainFilter = ResistorTwo / ResistorOne;
        }

        public BandPassFilterInverting(double firstresistor, double firstcapacitor, double secondresistor, double secondcapacitor)
        {
            //specific constructor, set on given working values
            ResistorOne = firstresistor;
            ResistorTwo = secondresistor;
            CapacitorOne = firstcapacitor;
            CapacitorTwo = secondcapacitor;
            FilterTypeName = "BPINV";
            MaxGainFilter = ResistorTwo / ResistorOne;            
        }
    }
}