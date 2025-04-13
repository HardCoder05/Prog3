using System.Collections.Generic;
using System;

public class Sede{
    /*
        las sedes de cada institución es indispensable también un identificador, el nombre y la dirección.
    */

    //Atributos
    private int idSede;
    private string nombreSede;
    private string direccion;
    public List<ProgramaAcademico> ProgramasAcademicos;

    //Constructor
    public Sede(int idSede, string nombreSede, string direccion){
        this.idSede = idSede;
        this.nombreSede = nombreSede;
        this.direccion = direccion;
    }

    public string getNombreSede(){
        return nombreSede;
    }

    public string getDireccion(){
        return direccion;
    }

    public void agregarProgramaAcademico(ProgramaAcademico programa){
        ProgramasAcademicos.Add(programa);
    }
    
}