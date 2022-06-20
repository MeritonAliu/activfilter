/* 
 * HighPassFilterNonInverting.cs
 * Activ filter OOP Project
 * BFSU 29.05.2022 
 * Meriton Aliu / Dario Casciato
 * This file contains the child class for the active non inverting high pass filter.
 */
using System;

namespace activfilter
{
    class HighPassFilterNonInverting : Filter
    {   
        //Properties
        public override double VoltageGain //overrides the VoltageGain methode from the filter class
        {
            get
            { 
                double dblVoltageGain = 1 + (ResistorTwo / ImpedanceOne); // calculate the voltage gain
                dblVoltageGain = controlVoltageGain(dblVoltageGain); // controls the voltage gain
                return dblVoltageGain; 
            }
        }
        public override double Phaseshift //overrides the Phaseshift methode from the filter class
        {
            get 
            {   //                          R2 ///////// 2pic2f * (R12 +R1*R2) + 1/2picf
                double phase = Math.Atan( ResistorTwo / ((2 * Math.PI * CapacitorOne * Frequency) * ((Math.Pow(ResistorOne, 2) + ResistorOne * ResistorTwo)) + (1 / (2 * Math.PI * CapacitorOne * Frequency))));
                return (180 / Math.PI) * phase;
                //return dblPhaseshift = (180/Math.PI)* (Math.Atan(ReactanceOne/ResistorOne) - Math.Atan((1/ResistorTwo)*ResistorTwo)); 
            }
        }
        
        //Constructor
        public HighPassFilterNonInverting()
        {
            //default constructor, set on random working values
            Frequency = 1000;
            ResistorOne = 1592;
            ResistorTwo = 1592;
            CapacitorOne = 0.0000001;
            FilterTypeName = "HPnonINV";
            MaxGainFilter = 1 + (ResistorTwo / ResistorOne);
        }

        public HighPassFilterNonInverting(double firstresistor, double firstcapacitor, double secondresistor)
        {
            //specific constructor, set on given working values
            ResistorOne = firstresistor;
            ResistorTwo = secondresistor;
            CapacitorOne = firstcapacitor;
            FilterTypeName = "HPnonINV";
            MaxGainFilter = 1 + (ResistorTwo / ResistorOne);
        }
    }
}