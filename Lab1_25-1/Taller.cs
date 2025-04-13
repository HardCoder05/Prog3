using System;

public class Taller : ProgramaAcademico{
    /*
        los talleres se requiere manejar la fecha de realización
        del taller, así como la hora de inicio y la hora fin del taller.
    */

    //Atributos
    private DateTime fechaRealizacion;
    private TimeSpan horaInicio;
    private TimeSpan horaFin;

    //Constructor
    public Taller(string nombrePrograma, string clavePrograma, char modalidadPrograma, double precioPrograma, 
        DateTime fechaRealizacion, TimeSpan horaInicio, TimeSpan horaFin) :
        base(nombrePrograma, clavePrograma, modalidadPrograma, precioPrograma){
        this.fechaRealizacion = fechaRealizacion;
        this.horaInicio = horaInicio;
        this.horaFin = horaFin;
    }

    public Taller(){
        
    }

    public override string consultarDatos(){
        return "TALLER: " + base.getClavePrograma() + " - " + base.getNombrePrograma() + " - S/. " + 
            ((decimal)base.getPrecioPrograma()).ToString("0.00") + " - Fecha: " + 
            fechaRealizacion.ToString("dd/MM/yyyy"); 
    }
}