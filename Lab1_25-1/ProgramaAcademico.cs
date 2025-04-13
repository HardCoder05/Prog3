public abstract class ProgramaAcademico : IConsultable{
    /*
        Todo programa académico debe contar con un identificador numérico correlativo que debe ser generado de forma
        automática por el sistema informático. Asimismo, para todo programa académico es necesario que el sistema
        contemple el nombre del programa, la clave del programa (que consiste un código de 6 dígitos alfanuméricos), la
        modalidad del programa (que debe manejarse como carácter [V: en caso de que sea virtual y P: en caso de que sea
        presencial]) y el precio con el cual es ofrecido el programa al mercado. 
    */

    //Atributos
    private int idProgramaAcademico = 0;
    private string nombrePrograma;
    private string clavePrograma;
    private char modalidadPrograma;
    private double precioPrograma;

    //Constructor
    public ProgramaAcademico(string nombrePrograma, string clavePrograma, 
        char modalidadPrograma, double precioPrograma){
        this.idProgramaAcademico++;
        this.nombrePrograma = nombrePrograma;
        this.clavePrograma = clavePrograma;
        this.modalidadPrograma = modalidadPrograma;
        this.precioPrograma = precioPrograma;
    }

    public ProgramaAcademico(){
        this.idProgramaAcademico++;
    }

    //Getters
    public int getIdProgramaAcademico(){
        return idProgramaAcademico;
    }

    public string getNombrePrograma(){
        return nombrePrograma;
    }

    public string getClavePrograma(){
        return clavePrograma;
    }

    public char getModalidadPrograma(){
        return modalidadPrograma;
    }

    public double getPrecioPrograma(){
        return precioPrograma;
    }

    public abstract string consultarDatos();

}