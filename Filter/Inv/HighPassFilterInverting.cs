/* 
 * HighPassFilterInverting.cs
 * Activ filter OOP Project
 * BFSU 29.05.2022 
 * Meriton Aliu / Dario Casciato
 * This file contains the child class for the active inverting high pass filter.
 */
using System;

namespace activfilter
{
    class HighPassFilterInverting : Filter
    {   
        //Properties
        public override double VoltageGain //overrides the VoltageGain methode from the filter class
        {
            get
            { 
                dblVoltageGain = (ResistorTwo / ImpedanceOne); // calculate the voltage gain
                dblVoltageGain = controlVoltageGain(dblVoltageGain); // control the voltage gain
                return dblVoltageGain; 
            }
        }
        public override double Phaseshift //overrides the Phaseshift methode from the filter class
        {
            get 
            {
                return (180 / Math.PI) * Math.Atan(-Frequency * (MaxGainFilter / TransitFrequency) + 1 / (2 * Math.PI * Frequency * CapacitorOne * ResistorOne)) - 180;
                //return dblPhaseshift = (180/Math.PI)* (Math.Atan(ReactanceOne/ResistorOne) - Math.Atan((1/ResistorTwo)*ResistorTwo)) - 180; 
            }
        }
        //Constructors
        public HighPassFilterInverting()
        {
            //default constructor, set on random working values
            Frequency = 1000;
            ResistorOne = 1592;
            ResistorTwo = 1592;
            CapacitorOne = 0.0000001;
            FilterTypeName = "HPINV";
            MaxGainFilter = ResistorTwo / ResistorOne;
        }

        public HighPassFilterInverting(double firstresistor, double firstcapacitor, double secondresistor)
        {
            //specific constructor, set on given working values
            ResistorOne = firstresistor;
            ResistorTwo = secondresistor;
            CapacitorOne = firstcapacitor;
            FilterTypeName = "HPINV";
            MaxGainFilter = ResistorTwo / ResistorOne;
        }

    }
}