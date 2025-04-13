using System;

public class Local : InfoProvider{
	private string nombre; 
	private string direccion; 
	private int capacidad; 
	private TipoLocal tipoLocal; 

	public Local(string nombre,string direccion,int capacidad,TipoLocal tipoLocal){
		this.nombre = nombre; 
		this.direccion = direccion; 
		this.capacidad = capacidad; 
		this.tipoLocal = tipoLocal; 
	}
	
	public string devolverDatos(){
		return "LOCAL: " + nombre +  " - CAPACIDAD: " + capacidad + "\n";
	}
	
}