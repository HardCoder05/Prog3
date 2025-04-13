using System;

public class Funcion : InfoProvider{
	private DateTime fecha; 
	private TimeSpan hora; 
	
	public Funcion(DateTime fecha, TimeSpan hora){
		this.fecha = fecha; 
		this.hora = hora; 
	}

	public string devolverDatos(){
        return "FECHA: " + fecha.ToString("dd-MM-yyyy") + " " + hora.ToString(@"hh\:mm") + "\n";
	}
	
	
}