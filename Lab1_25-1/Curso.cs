using System;

public class Curso : ProgramaAcademico{
    /*
        los cursos se requieren manejar datos adicionales tales como: la cantidad de horas de clase por semana 
        del curso, la cantidad de créditos del curso, la fecha de inicio de clases del curso, la fecha fin de 
        las clases del curso, el día de la semana en que se dictan las clases del curso (que puede ser Lunes, 
        Martes, Miércoles, Jueves, Viernes o Sabado), la hora de inicio de las clases del curso y la hora fin 
        de las clases del curso. 
    */
    
    //Atributos
    private int horasClasePorSemana;
    private double creditosCurso;
    private DateTime fechaInicioClases;
    private DateTime fechaFinClases;
    private DiaSemana diaSemana;
    private TimeSpan horaInicioClases;
    private TimeSpan horaFinClases;

    //Constructor
    public Curso(string nombrePrograma, string clavePrograma, char modalidadPrograma, 
        double precioPrograma, int horasClasePorSemana, double creditosCurso, DateTime fechaInicioClases, 
        DateTime fechaFinClases, DiaSemana diaSemana, TimeSpan horaInicioClases, TimeSpan horaFinClases) :
        base(nombrePrograma, clavePrograma, modalidadPrograma, precioPrograma){
        this.horasClasePorSemana = horasClasePorSemana;
        this.creditosCurso = creditosCurso;
        this.fechaInicioClases = fechaInicioClases;
        this.fechaFinClases = fechaFinClases;
        this.diaSemana = diaSemana;
        this.horaInicioClases = horaInicioClases;
        this.horaFinClases = horaFinClases;
    }

    public Curso(){

    }

    public override string consultarDatos(){
        return "CURSO: " + base.getClavePrograma() + " - " + base.getNombrePrograma() + " - S/. " + 
            ((decimal)base.getPrecioPrograma()).ToString("0.00") + " - CRED: " +  
            ((decimal)creditosCurso).ToString("0.0"); 
    }


}