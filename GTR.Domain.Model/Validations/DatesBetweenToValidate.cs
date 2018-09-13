using System;

namespace GTR.Domain.Model.Validations
{
    public class DatesBetweenToValidate
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string NombreCampo { get; set; }
        public long NumeroDias { get; set; }
        public int NumeroMeses { get; set; }
        public string MensajeError { get; set; }
        public bool IsAnual { get; set; }
        public bool IsOnDemand { get; set; }
    }
}