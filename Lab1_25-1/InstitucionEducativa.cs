using System.Collections.Generic;
using System;

public class InstitucionEducativa{
    /*
         las instituciones educativas es un identificador, el RUC y el nombre
    */

    //Atributos
    private int idInstitucionEducativa;
    private string ruc;
    private string nombreInstitucionEducativa;
    public List<Sede> Sedes;

    //Constructor
    public InstitucionEducativa(int idInstitucionEducativa, string ruc, string nombreInstitucionEducativa){
        this.idInstitucionEducativa = idInstitucionEducativa;
        this.ruc = ruc;
        this.nombreInstitucionEducativa = nombreInstitucionEducativa;
    }

    public void agregarSede(Sede sede){
        Sedes.Add(sede);
    }

    public string consultarProgramasDeSede(int index){
        string reporte = "Programas disponibles para " + Sedes[index].getNombreSede() + "\n";
        foreach(ProgramaAcademico programa in Sedes[index].ProgramasAcademicos){
            reporte += programa.consultarDatos() + "\n";
        }
        return reporte;
    }
}