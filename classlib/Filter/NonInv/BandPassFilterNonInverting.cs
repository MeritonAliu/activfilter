/* 
 * BandPassFilterNonInverting.cs
 * Activ filter OOP Project
 * BFSU 29.05.2022 
 * Meriton Aliu / Dario Casciato
 * This file contains the child class for the active non inverting band pass filter.
 */
using System;

namespace activfilter.classlib.FilterClass
{
    class BandPassFilterNonInverting : Filter
    {   
        //Properties
        public override double VoltageGain //overrides the VoltageGain methode from the filter class
        {
            get
            { 
                double dblVoltageGain = 1 + (ImpedanceTwo / ImpedanceOne);
                dblVoltageGain = controlVoltageGain(dblVoltageGain); // control the voltage gain
                return dblVoltageGain; 
            }
        }
        public override double Phaseshift //overrides the Phaseshift methode from the filter class
        {
            get
            {
                double low = (-2 * Math.PI * Frequency * CapacitorTwo) / ((1 / ResistorTwo) + Math.Pow(2 * Math.PI * Frequency * CapacitorTwo, 2));
                double high = ResistorTwo / ((2 * Math.PI * CapacitorOne * Frequency) * ((Math.Pow(ResistorOne, 2) + ResistorOne * ResistorTwo)) + (1 / (2 * Math.PI * CapacitorOne * Frequency)));
                double end = Math.Atan(low + high);
                //return (180 / Math.PI) * end;
                return dblPhaseshift = (180/Math.PI)* (Math.Atan(ReactanceOne/ResistorOne) - Math.Atan((1/ReactanceTwo)*ResistorTwo)); 
            }
        }

        //Constructors
        public BandPassFilterNonInverting()
        {
            //default constructor, set on random working values
            Frequency = 1000;
            ResistorOne = 1592;
            ResistorTwo = 1592;
            CapacitorOne = 0.0000001;
            CapacitorTwo = 0.000000001;
            FilterTypeName = "BPnonINV";
            MaxGainFilter = 1 + (ResistorTwo / ResistorOne);
        }

        public BandPassFilterNonInverting(double firstresistor, double firstcapacitor, double secondresistor, double secondcapacitor)
        {
            //specific constructor, set on given values
            ResistorOne = firstresistor;
            ResistorTwo = secondresistor;
            CapacitorOne = firstcapacitor;
            CapacitorTwo = secondcapacitor;
            FilterTypeName = "BPnonINV";
            MaxGainFilter = 1 + (ResistorTwo / ResistorOne);
        }
        
    }
}